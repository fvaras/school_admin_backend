using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using school_admin_api.Contracts.Exceptions;
using school_admin_api.Contracts.Services;

namespace school_admin_api.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionHandler(this WebApplication app, ILoggerService logger)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    bool isBusinessEx = contextFeature.Error is BusinessException;
                    string message = contextFeature.Error.Message;

                    if (isBusinessEx)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            EntityNotFoundException => (int)HttpStatusCode.NotFound,
                            _ => (int)HttpStatusCode.BadRequest
                        };
                    }
                    else
                        logger.Error(contextFeature.Error);

                    await context.Response.WriteAsync(
                        new
                        {
                            Code = isBusinessEx ? 1 : 2,
                            ErrorMessage = isBusinessEx ? message : "Error interno.",
                            Data = ""
                        }.ToString());

                }
            });
        });
    }

}