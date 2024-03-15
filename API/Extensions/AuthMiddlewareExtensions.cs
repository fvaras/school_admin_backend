using school_admin_api.Middlewares;

namespace school_admin_api.Extensions;

public static class AuthMiddlewareExtensions
{
    public static void ConfigureCustomAuthorizationMiddleware(this WebApplication app)
    {
        app.UseMiddleware<TokenValidationMiddleware>();
    }
}
