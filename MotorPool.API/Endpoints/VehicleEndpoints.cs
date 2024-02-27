using System.Security.Claims;

using MotorPool.API.EndpointFilters;
using MotorPool.Services.Manager;
using MotorPool.Services.Vehicles.Exceptions;
using MotorPool.Services.Vehicles.Models;
using MotorPool.Services.Vehicles.Services;

namespace MotorPool.API.Endpoints;

public static class VehicleEndpoints
{

    public static void MapVehicleEndpoints(this IEndpointRouteBuilder managerResourcesGroupBuilder)
    {
        RouteGroupBuilder vehiclesGroupBuilder = managerResourcesGroupBuilder.MapGroup("vehicles");

        vehiclesGroupBuilder.MapGet("", GetAll)
                            .WithName("GetAllVehicles")
                            .Produces<List<VehicleViewModel>>();

        vehiclesGroupBuilder.MapGet("{vehicleId:int}", GetById)
                            .AddEndpointFilter<VehicleExistsFilter>()
                            .AddEndpointFilter<IsManagerAccessibleVehicleFilter>()
                            .WithName("GetVehicleById")
                            .Produces<VehicleViewModel>()
                            .Produces(StatusCodes.Status404NotFound)
                            .Produces(StatusCodes.Status403Forbidden);

        vehiclesGroupBuilder.MapPost("", Create)
                            .WithParameterValidation()
                            .WithName("CreateVehicle")
                            .AddEndpointFilter<EnterpriseIsManagerAccessibleFilter>()
                            .Produces<VehicleViewModel>()
                            .Produces(StatusCodes.Status400BadRequest)
                            .Produces(StatusCodes.Status201Created);

        vehiclesGroupBuilder.MapPut("{vehicleId:int}", Update)
                            .AddEndpointFilter<VehicleExistsFilter>()
                            .AddEndpointFilter<IsManagerAccessibleVehicleFilter>()
                            .WithName("UpdateVehicle")
                            .Produces(StatusCodes.Status400BadRequest)
                            .Produces(StatusCodes.Status204NoContent)
                            .Produces(StatusCodes.Status404NotFound)
                            .Produces(StatusCodes.Status403Forbidden);

        vehiclesGroupBuilder.MapDelete("{vehicleId:int}", Delete)
                            .AddEndpointFilter<VehicleExistsFilter>()
                            .AddEndpointFilter<IsManagerAccessibleVehicleFilter>()
                            .WithName("DeleteVehicle")
                            .Produces(StatusCodes.Status204NoContent)
                            .Produces(StatusCodes.Status404NotFound)
                            .Produces(StatusCodes.Status403Forbidden);
    }

    private static async Task<IResult> GetAll(VehicleQueryService vehicleQueryService, ClaimsPrincipal user)
    {
        List<VehicleViewModel> vehicles = await vehicleQueryService.GetAllAsync();

        return Results.Ok(vehicles.ForManager(user.GetManagerId()));
    }

    private static async Task<IResult> GetById(int vehicleId, HttpContext httpContext)
    {
        VehicleViewModel vehicle = httpContext.Items["Vehicle"] as VehicleViewModel ?? throw new InvalidOperationException("Vehicle not found in the request context.");

        return Results.Ok(vehicle);
    }

    private static async Task<IResult> Create(VehicleActionService vehicleActionService, VehicleDTO vehicleDTO)
    {
        try
        {
            VehicleViewModel result = await vehicleActionService.CreateAsync(vehicleDTO);

            return Results.Created($"/vehicles/{result.VehicleId}", result);
        }
        catch (VehicleBrandNotFoundException)
        {
            return Results.Problem(statusCode: 400, title: "Vehicle brand not found");
        }
        catch (VINAlreadyExistsException)
        {
            return Results.Problem(statusCode: 400, title: "VIN already exists");
        }
    }

    private static async Task<IResult> Update(VehicleActionService vehicleActionService, int vehicleId, VehicleDTO vehicleDTO, HttpContext httpContext)
    {
        try
        {
            VehicleViewModel updateModel = httpContext.Items["Vehicle"] as VehicleViewModel ?? throw new InvalidOperationException("Vehicle not found in the request context.");

            await vehicleActionService.UpdateAsync(updateModel);

            return Results.NoContent();
        }
        catch (VehicleBrandNotFoundException)
        {
            return Results.Problem(statusCode: 400, title: "Vehicle brand not found");
        }
    }

    private static async Task<IResult> Delete(VehicleActionService vehicleActionService, int vehicleId)
    {
        await vehicleActionService.DeleteAsync(vehicleId);

        return Results.NoContent();
    }

}