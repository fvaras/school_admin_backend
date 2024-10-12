using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;
using NLog;
using school_admin_api.Contracts.Services;

namespace school_admin_api.Services;

public class LoggerServiceCloudWatch : ILoggerService
{
    private readonly IAmazonCloudWatchLogs _cloudWatchLogsClient;
    private readonly string _logGroupName;
    private readonly ILogger<LoggerServiceCloudWatch> _logger;
    private string _currentLogStreamName;
    private string _currentMonth;

    public LoggerServiceCloudWatch(
        IAmazonCloudWatchLogs cloudWatchLogsClient,
        string logGroupName,
        ILogger<LoggerServiceCloudWatch> logger)
    {
        _cloudWatchLogsClient = cloudWatchLogsClient;
        _logGroupName = logGroupName;
        _logger = logger;

        _currentMonth = DateTime.UtcNow.ToString("yyyy-MM");
        // _currentMonth = string.Empty;
        _currentLogStreamName = $"{_currentMonth}-log-stream";
        EnsureLogGroupAndStreamExist().Wait();
    }

    private async Task EnsureLogGroupAndStreamExist()
    {
        try
        {
            var logGroupsResponse = await _cloudWatchLogsClient.DescribeLogGroupsAsync(new DescribeLogGroupsRequest
            {
                LogGroupNamePrefix = _logGroupName
            });

            if (logGroupsResponse.LogGroups.Count == 0)
            {
                await _cloudWatchLogsClient.CreateLogGroupAsync(new CreateLogGroupRequest
                {
                    LogGroupName = _logGroupName
                });
                _logger.LogInformation($"Created log group: {_logGroupName}");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error describing or creating log group.");
            throw;
        }

        try
        {
            var logStreamsResponse = await _cloudWatchLogsClient.DescribeLogStreamsAsync(new DescribeLogStreamsRequest
            {
                LogGroupName = _logGroupName,
                LogStreamNamePrefix = _currentLogStreamName
            });

            if (logStreamsResponse.LogStreams.Count == 0)
            {
                await _cloudWatchLogsClient.CreateLogStreamAsync(new CreateLogStreamRequest
                {
                    LogGroupName = _logGroupName,
                    LogStreamName = _currentLogStreamName
                });
                _logger.LogInformation($"Created log stream: {_currentLogStreamName}");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error describing or creating log stream.");
            throw;
        }
    }

    private async Task EnsureCurrentLogStream()
    {
        var newMonth = DateTime.UtcNow.ToString("yyyy-MM");
        if (_currentMonth != newMonth)
        {
            _currentMonth = newMonth;
            _currentLogStreamName = $"{_currentMonth}-log-stream";
            await EnsureLogGroupAndStreamExist();
        }
    }

    private async Task LogAsync(string level, string message)
    {
        await EnsureCurrentLogStream();

        var logMessage = $"{DateTime.UtcNow:O} [{level}] {message}\n";

        var putLogEventsRequest = new PutLogEventsRequest
        {
            LogGroupName = _logGroupName,
            LogStreamName = _currentLogStreamName,
            LogEvents = new List<InputLogEvent>
                {
                    new InputLogEvent
                    {
                        Message = logMessage,
                        Timestamp = DateTime.UtcNow
                    }
                }
        };

        await _cloudWatchLogsClient.PutLogEventsAsync(putLogEventsRequest);
    }

    public void Info(string message) => LogAsync("INFO", message).Wait();
    public void Warn(string message) => LogAsync("WARN", message).Wait();
    public void Debug(string message) => LogAsync("DEBUG", message).Wait();
    public void Error(string message) => LogAsync("ERROR", message).Wait();
    public void Error(object value) => LogAsync("ERROR", value.ToString()).Wait();
    public void Error(string message, object arg1) => LogAsync("ERROR", $"{message} {arg1}").Wait();
    public void Trace(string message) => LogAsync("TRACE", message).Wait();
}
