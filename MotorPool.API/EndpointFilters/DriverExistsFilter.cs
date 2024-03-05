using MotorPool.Services.Drivers.Models;
using MotorPool.Services.Drivers.Services;

namespace MotorPool.API.EndpointFilters;

public class DriverExistsFilter(DriverQueryService driverQueryService) : IEndpointFilter
{

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        int driverId = int.Parse(context.HttpContext.Request.RouteValues["driverId"]!.ToString());

        DriverViewModel? driver = await driverQueryService.GetByIdAsync(driverId);

        if (driver is not null)
        {
            context.HttpContext.Items["Driver"] = driver;
            return await next(context);
        }

        context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
        return null;
    }

}