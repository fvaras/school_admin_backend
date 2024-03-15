using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace school_admin_api.ActionFilters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var indxSession = (string)context.HttpContext.Items["username"];
        if (indxSession == null)
        {
            context.Result = new UnauthorizedResult();
        }
    }
}