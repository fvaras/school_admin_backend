using Microsoft.AspNetCore.Mvc;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;

namespace school_admin_api.Controllers.Shared;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{

    private readonly IAuthService _authService;
    public AuthController(
        IAuthService authService
    )
    {
        _authService = authService;
    }

    [HttpPost("tkn")]
    public Task<AuthInfoDTO?> ValidateUser(ValidateUserDTO req)
    {
        return _authService.ValidateUser(req.Username, req.Password, req.ProfileId);
    }
}
