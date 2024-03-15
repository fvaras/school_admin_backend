using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;

namespace school_admin_api.Services;

public class AuthService : IAuthService
{
    private readonly IJWTService _jwtService;
    
    public AuthService(
        IJWTService jwtService
        )
    {
        _jwtService = jwtService;
    }

    public async Task<string> ValidateUser(string username, string token)
    {
        // TODO: Validate in DB
        AuthInfoDTO authInfoDTO = new AuthInfoDTO()
        {
            UserName = "JimMorrison",
            Profile = 1
        };

        return _jwtService.Encode(authInfoDTO);
    }

    public async Task<AuthInfoDTO?> ValidateToken(string token)
    {
        AuthInfoDTO authInfo = _jwtService.Decode<AuthInfoDTO>(token);
        return authInfo;
    }
}
