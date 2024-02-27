using System.Security.Claims;

using Microsoft.AspNetCore.Mvc;

using MotorPool.Auth.EndpointFilters;
using MotorPool.Auth.Manager;
using MotorPool.Services.Manager;
using MotorPool.Services.Vehicles.Exceptions;
using MotorPool.Services.Vehicles.Models;
using MotorPool.Services.Vehicles.Services;

namespace MotorPool.API;

public static class VehicleEndpoints
{

    public static void MapVehicleEndpoints(this IEndpointRouteBuilder managerResourcesGroupBuilder)
    {
        RouteGroupBuilder vehiclesGroupBuilder = managerResourcesGroupBuilder.MapGroup("vehicles");

        vehiclesGroupBuilder.MapGetAll();
        vehiclesGroupBuilder.MapGet();
        vehiclesGroupBuilder.MapPost();
    }

    private static void MapGetAll(this IEndpointRouteBuilder vehiclesGroupBuilder)
    {
        vehiclesGroupBuilder.MapGet("/", async (VehicleQueryService vehicleQueryService, ClaimsPrincipal user) =>
        {
            int managerId = user.GetManagerId();

            List<VehicleViewModel> vehicles = await vehicleQueryService.GetAllAsync();

            return vehicles.ForManager(managerId);
        });
    }

    private static void MapGet(this IEndpointRouteBuilder vehiclesGroupBuilder)
    {
        vehiclesGroupBuilder.MapGet("{vehicleId}", async (VehicleQueryService vehicleQueryService, int vehicleId) =>
        {
            VehicleViewModel? vehicle = await vehicleQueryService.GetById(vehicleId);

            return vehicle == null
                ? Results.NotFound()
                : Results.Ok(vehicle);
        });
    }

    private static void MapPost(this IEndpointRouteBuilder vehiclesGroupBuilder)
    {
        vehiclesGroupBuilder.MapPost("/", async (VehicleActionService vehicleActionService, VehicleDTO vehicleDTO) =>
                            {
                                try
                                {
                                    VehicleViewModel result = await vehicleActionService.CreateAsync(vehicleDTO);

                                    return Results.Created($"/vehicles/{result.VehicleId}", result);
                                }
                                catch (VehicleBrandNotFoundException)
                                {
                                    return Results.Problem(new ProblemDetails
                                    {
                                        Title = "Vehicle brand not found",
                                        Status = 400
                                    });
                                }
                            })
                            .AddEndpointFilter<EnterpriseIsManagerAccessibleFilter>()
                            .Produces<VehicleViewModel>();
    }

}