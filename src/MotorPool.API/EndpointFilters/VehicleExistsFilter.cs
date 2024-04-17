using MotorPool.Services.Vehicles.Models;
using MotorPool.Services.Vehicles.Services;

namespace MotorPool.API.EndpointFilters;

public class VehicleExistsFilter(VehicleQueryService vehicleQueryService) : IEndpointFilter
{

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        string vehicleIdString = context.HttpContext.Request.RouteValues["vehicleId"]?.ToString() ?? throw new InvalidOperationException("VehicleId is not found in route data");
        int vehicleId = int.Parse(vehicleIdString);

        VehicleViewModel? vehicle = await vehicleQueryService.GetByIdAsync(vehicleId);

        if (vehicle is not null)
        {
            context.HttpContext.Items["Vehicle"] = vehicle;
            return await next(context);
        }

        context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
        return null;
    }

}