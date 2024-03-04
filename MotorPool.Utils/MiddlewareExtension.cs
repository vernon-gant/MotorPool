using Microsoft.AspNetCore.Builder;

using MotorPool.Utils.Middleware;

namespace MotorPool.Utils;

public static class MiddlewareExtension
{

    public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder) => builder.UseMiddleware<ExceededPageLimitExceptionMiddleware>();

}