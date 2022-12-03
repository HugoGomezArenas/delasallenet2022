using System.Net;
using DeLaSalle.Ecommerce.Api.Controllers;
using DeLaSalle.Ecommerce.Core.Http;
using Microsoft.AspNetCore.Diagnostics;

namespace DeLaSalle.Ecommerce.Api.Middlewares;

public static class ExceptionMiddleware
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler((appError) =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if(contextFeature != null)
                { 
                    var response = new Response<IEnumerable<string>>();

                    if (contextFeature.Error is MyHttpResponseException)
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    }

                    response.Errors.Add(contextFeature.Error.Message);
                    
                    await context.Response.WriteAsJsonAsync(response);
                }
            });
        });
    }

}