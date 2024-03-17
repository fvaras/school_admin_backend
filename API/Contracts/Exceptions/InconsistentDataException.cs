namespace school_admin_api.Contracts.Exceptions;

public class InconsistentDataException : BusinessException
{
    public InconsistentDataException() : base() { }
    public InconsistentDataException(string message) : base(message) { }
}
