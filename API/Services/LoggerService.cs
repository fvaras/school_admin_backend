using NLog;
using school_admin_api.Contracts.Services;

namespace school_admin_api.Services;

public class LoggerService : ILoggerService
{
    private static NLog.ILogger logger = LogManager.GetCurrentClassLogger();

    public LoggerService() { }

    public void Debug(string message) => logger.Debug(message);
    public void Error(string message) => logger.Error(message);
    public void Error(object value) => logger.Error(value);
    public void Info(string message) => logger.Info(message);
    public void Warn(string message) => logger.Warn(message);
    public void Trace(string message) => logger.Trace(message);

    public void Error(string message, object arg1) => logger.Error(message, arg1);
}
