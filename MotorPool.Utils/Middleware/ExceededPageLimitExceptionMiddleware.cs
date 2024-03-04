using System.Text.Json;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MotorPool.Utils.Exceptions;

namespace MotorPool.Utils.Middleware;

public class ExceededPageLimitExceptionMiddleware(RequestDelegate next)
{

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (ExceededPageLimitException ex)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Page limit exceeded",
                Detail = ex.Message,
            };

            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = problemDetails.Status.Value;

            await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
        }
    }

}