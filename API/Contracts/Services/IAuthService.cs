using school_admin_api.Contracts.DTO;

namespace school_admin_api.Contracts.Services;
public interface IAuthService
{
    Task<string> ValidateUser(string username, string token);
    Task<AuthInfoDTO?> ValidateToken(string token);
}
