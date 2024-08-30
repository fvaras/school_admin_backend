using AutoMapper;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;
using Profile = school_admin_api.Model.Profile;

namespace school_admin_api.Services;

public class AuthService : IAuthService
{
    private readonly IUserService _userService;
    private readonly ITeacherService _teacherService;
    private readonly IStudentService _studentService;
    private readonly IGuardianService _guardianService;
    // private readonly IUserService _userService;
    private readonly IJWTService _jwtService;

    public AuthService(
        IUserService userService,
        IJWTService jwtService,
        ITeacherService teacherService,
        IStudentService studentService,
        IGuardianService guardianService
        )
    {
        _userService = userService;
        _jwtService = jwtService;
        _teacherService = teacherService;
        _studentService = studentService;
        _guardianService = guardianService;
    }

    public async Task<AuthInfoDTO?> ValidateUser(string username, string password, Guid profileId)
    {
        (UserInfoDTO? userInfo, Guid userId) = await _userService.Validate(username, password, profileId);
        if (userInfo == null)
            return null;
        userInfo.ProfileId = profileId;

        Guid userProfileId = Guid.Empty;
        if (profileId == Profile.ADMINISTRATOR)
        {
            userProfileId = userId;
        }
        if (profileId == Profile.TEACHER)
        {
            userProfileId = (await _teacherService.RetrieveIdByUser(userId)).FirstOrDefault();
        }
        else if (profileId == Profile.STUDENT)
        {
            userProfileId = (await _studentService.RetrieveByUserId(userId)).Id;
        }
        else if (profileId == Profile.GUARDIAN)
        {
            userProfileId = (await _guardianService.RetrieveByUserId(userId)).Id;
        }

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

    public async Task<AuthInfoDTO?> ValidateToken(string token)
    {
        TokenInfoDTO authInfo = _jwtService.Decode<TokenInfoDTO>(token);
        UserInfoDTO? userInfo = await _userService.RetrieveByUserName(authInfo.Username);

        // TODO: Get from DB and validate consistency
        userInfo.ProfileId = authInfo.ProfileId;

        AuthInfoDTO authInfoDTO = new AuthInfoDTO()
        {
            User = userInfo,
            Token = token
        };
        return authInfoDTO;
    }
}
