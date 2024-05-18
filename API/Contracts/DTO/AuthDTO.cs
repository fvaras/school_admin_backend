using System.ComponentModel.DataAnnotations;

namespace school_admin_api.Contracts.DTO;

public record ValidateUserDTO
{
    public string Username { get; init; }
    
    public string Password { get; init; }
    
    [Range(1, 4)]
    public byte ProfileId { get; init; }
}
