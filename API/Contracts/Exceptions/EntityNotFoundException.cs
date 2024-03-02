namespace school_admin_api.Contracts.Exceptions;

public class EntityNotFoundException : BusinessException
{
    public EntityNotFoundException() : base() { }
    public EntityNotFoundException(string message) : base(message) { }
}
