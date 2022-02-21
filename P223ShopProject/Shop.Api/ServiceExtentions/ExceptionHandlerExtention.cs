using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Shop.Service.Exceptions;

namespace Shop.Api.ServiceExtentions
{
    public static class ExceptionHandlerExtention
    {
        public static void UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    int statusCode = 500;
                    string msg = "Internal server error!";

                    if (contextFeature != null)
                    {
                        msg = contextFeature.Error.Message;

                        if (contextFeature.Error is ItemNotFoundException)
                            statusCode = 404;
                        else if (contextFeature.Error is RecordDuplicateException)
                            statusCode = 409;
                        else if (contextFeature.Error is PageIndexIncorrectException)
                            statusCode = 400;
                    }

                    context.Response.StatusCode = statusCode;

                    string responseStr = JsonConvert.SerializeObject(new
                    {
                        code = statusCode,
                        message = msg
                    });

                    await context.Response.WriteAsync(responseStr);
                });
            });

        }
    }
}
