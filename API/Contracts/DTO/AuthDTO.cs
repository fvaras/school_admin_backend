namespace school_admin_api.Contracts.DTO;

public record ValidateUserDTO
{
    public string Username { get; init; }
    
    public string Password { get; init; }
    
    public Guid ProfileId { get; init; }
}
