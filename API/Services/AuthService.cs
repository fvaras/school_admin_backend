using AutoMapper;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;
using Profile = school_admin_api.Model.Profile;

namespace school_admin_api.Services;

public class AuthService : IAuthService
{
    private readonly IUserService _userService;
    private readonly ITeacherService _teacherService;
    private readonly IGuardianService _guardianService;
    // private readonly IUserService _userService;
    private readonly IJWTService _jwtService;

    public AuthService(
        IUserService userService,
        IJWTService jwtService,
        ITeacherService teacherService,
        IGuardianService guardianService
        )
    {
        _userService = userService;
        _jwtService = jwtService;
        _teacherService = teacherService;
        _guardianService = guardianService;
    }

    public async Task<AuthInfoDTO?> ValidateUser(string username, string password, Guid profileId)
    {
        (UserInfoDTO? userInfo, Guid userId) = await _userService.Validate(username, password, profileId);
        if (userInfo == null)
            return null;
        userInfo.ProfileId = profileId;

        Guid userProfileId = Guid.Empty;
        if (profileId == Profile.TEACHER || profileId == Profile.ADMINISTRATOR) // TODO: Remove Profile.ADMINISTRATOR for this condition and add futher validations (Student, Guardian, Admin)
        {
            userProfileId = (await _teacherService.RetrieveIdByUser(userId)).FirstOrDefault();
        }
        else if (profileId == Profile.GUARDIAN)
        {
            userProfileId = (await _guardianService.RetrieveByUserId(userId)).Id;
        }

        // TODO: Remove it. Was written just for test
        userProfileId = (await _guardianService.RetrieveByUserId(userId)).Id;


        TokenInfoDTO tokenInfo = new TokenInfoDTO()
        {
            Username = userInfo.UserName,
            ProfileId = profileId,
            UserProfileId = userProfileId
        };

        string token = _jwtService.Encode(tokenInfo);

        AuthInfoDTO authInfoDTO = new AuthInfoDTO()
        {
            User = userInfo,
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
