using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace school_admin_api.ActionFilters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var username = (string)context.HttpContext.Items["username"];
        if (username == null)
        {
            context.Result = new UnauthorizedResult();
        }
    }
}