namespace school_admin_api.Contracts.Exceptions;

public abstract class BusinessException : Exception
{
    public BusinessException() : base() { }
    public BusinessException(string message) : base(message) { }
    public BusinessException(string message, Exception ex) : base(message, ex) { }
}