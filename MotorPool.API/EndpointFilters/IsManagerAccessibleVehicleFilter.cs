using MotorPool.Services.Vehicles.Models;
using MotorPool.Services.Vehicles.Services;

namespace MotorPool.API.EndpointFilters;

public class IsManagerAccessibleVehicleFilter(VehicleQueryService vehicleQueryService) : IEndpointFilter
{

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        VehicleViewModel currentVehicle = context.HttpContext.Items["Vehicle"] as VehicleViewModel ?? throw new InvalidOperationException("Vehicle not found in the request context.");

        if (currentVehicle.ManagerIds.Contains(context.HttpContext.User.GetManagerId())) return await next(context);

        context.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
        return null;
    }

}