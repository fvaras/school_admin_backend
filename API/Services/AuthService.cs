using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;

namespace school_admin_api.Services;

public class AuthService : IAuthService
{
    private readonly IUserService _userService;
    private readonly IJWTService _jwtService;

    public AuthService(
        IUserService userService,
        IJWTService jwtService
        )
    {
        _userService = userService;
        _jwtService = jwtService;
    }

    public async Task<AuthInfoDTO?> ValidateUser(string username, string password, int profileId)
    {
        UserInfoDTO? user = await _userService.Validate(username, password, profileId);
        if (user == null)
            return null;
        user.ProfileId = profileId;

        TokenInfoDTO tokenInfo = new TokenInfoDTO()
        {
            Username = user.UserName,
            ProfileId = profileId
        };

        string token = _jwtService.Encode(tokenInfo);

        AuthInfoDTO authInfoDTO = new AuthInfoDTO()
        {
            User = user,
            Token = token
        };

        return authInfoDTO;
    }

    public async Task<TokenInfoDTO?> ValidateToken(string token)
    {
        TokenInfoDTO authInfo = _jwtService.Decode<TokenInfoDTO>(token);
        return authInfo;
    }
}
