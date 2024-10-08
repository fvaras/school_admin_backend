using school_admin_api.Contracts.DTO;

namespace school_admin_api.Contracts.Services;
public interface IAuthService
{
    Task<AuthInfoDTO?> ValidateUser(string username, string password, Guid profileId);
    Task<AuthInfoDTO?> ValidateToken(string token);
}
