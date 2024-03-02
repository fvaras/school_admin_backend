namespace school_admin_api.Contracts.Services;

public interface ILoggerService
{
    void Info(string message);
    void Warn(string message);
    void Debug(string message);
    void Error(string message);
    void Error(object value);
    void Error(string message, object arg1);
    void Trace(string message);
}
