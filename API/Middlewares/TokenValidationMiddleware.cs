using JWT.Exceptions;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;

namespace school_admin_api.Middlewares;

public class TokenValidationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILoggerService _logger;
    // private readonly IAuthService _authService;
    private readonly IJWTService _jwtService;

    public TokenValidationMiddleware(
        RequestDelegate next,
        ILoggerService logger,
        // IAuthService authService
        IJWTService jwtService
        )
    {
        _next = next;
        _logger = logger;
        // _authService = authService;
        _jwtService = jwtService;
    }

    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
            await attachUserToContext(context, token);

        await _next(context);
    }

    private async Task attachUserToContext(HttpContext context, string token)
    {
        try
        {
            // Validate token
            // AuthInfoDTO authInfoDTO = await _authService.ValidateToken(token);
            TokenInfoDTO authInfoDTO = _jwtService.Decode<TokenInfoDTO>(token);

            // Optional: Get data from DB. (session data on DB)

            // attach user to context on successful jwt validation
            context.Items["username"] = authInfoDTO.Username;
            context.Items["profile"] = authInfoDTO.ProfileId;
            context.Items["userProfileId"] = authInfoDTO.UserProfileId;
        }
        catch (Exception ex)
        {
            // do nothing if jwt validation fails
            // user is not attached to context so request won't have access to secure routes

            // Verify if Exception is out of range of JWT Validations
            if (ex is not SignatureVerificationException
                && ex is not TokenExpiredException
                && ex is not TokenNotYetValidException
                && ex is not FormatException
            )
            {
                _logger.Error(ex);
            }
        }
    }

}
