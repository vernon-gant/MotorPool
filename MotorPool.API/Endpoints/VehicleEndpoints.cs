using System.Security.Claims;

using MotorPool.API.EndpointFilters;
using MotorPool.Services.Geo;
using MotorPool.Services.Geo.Models;
using MotorPool.Services.Geo.Services;
using MotorPool.Services.Manager;
using MotorPool.Services.Utils;
using MotorPool.Services.Vehicles;
using MotorPool.Services.Vehicles.Exceptions;
using MotorPool.Services.Vehicles.Models;
using MotorPool.Services.Vehicles.Services;

namespace MotorPool.API.Endpoints;

public static class VehicleEndpoints
{

    public static void MapVehicleEndpoints(this IEndpointRouteBuilder managerResourcesGroupBuilder)
    {
        RouteGroupBuilder vehiclesGroupBuilder = managerResourcesGroupBuilder
                                                 .MapGroup("vehicles")
                                                 .WithParameterValidation();

        RouteGroupBuilder vehicleWithIdGroupBuilder = vehiclesGroupBuilder.MapGroup("{vehicleId:int}")
                                                                          .AddEndpointFilter<VehicleExistsFilter>()
                                                                          .AddEndpointFilter<IsManagerAccessibleVehicleFilter>();

        vehiclesGroupBuilder.MapGet("", GetAll)
                            .WithName("GetAllVehicles")
                            .Produces<List<VehicleViewModel>>();

        vehiclesGroupBuilder.MapPost("", Create)
                            .WithName("CreateVehicle")
                            .Produces<VehicleViewModel>()
                            .Produces(StatusCodes.Status400BadRequest)
                            .Produces(StatusCodes.Status201Created);

        vehicleWithIdGroupBuilder.MapGet("", GetById)
                                 .WithName("GetVehicleById")
                                 .Produces<VehicleViewModel>()
                                 .Produces(StatusCodes.Status404NotFound)
                                 .Produces(StatusCodes.Status403Forbidden);

        vehicleWithIdGroupBuilder.MapPut("", Update)
                                 .WithName("UpdateVehicle")
                                 .Produces(StatusCodes.Status400BadRequest)
                                 .Produces(StatusCodes.Status204NoContent)
                                 .Produces(StatusCodes.Status404NotFound)
                                 .Produces(StatusCodes.Status403Forbidden);

        vehicleWithIdGroupBuilder.MapDelete("", Delete)
                                 .WithName("DeleteVehicle")
                                 .Produces(StatusCodes.Status204NoContent)
                                 .Produces(StatusCodes.Status404NotFound)
                                 .Produces(StatusCodes.Status403Forbidden);

        vehicleWithIdGroupBuilder.MapGet("geoPoints/{startDateTime:datetime}/{endDateTime:datetime}", GetGeoPoints)
                                 .WithName("GetGeoPoints")
                                 .Produces(StatusCodes.Status204NoContent)
                                 .Produces(StatusCodes.Status404NotFound)
                                 .Produces(StatusCodes.Status403Forbidden);
    }

    private static async Task<IResult> GetAll(VehicleQueryService vehicleQueryService, ClaimsPrincipal user, [AsParameters] PageOptionsDTO pageOptionsDto)
    {
        int managerId = user.GetManagerId();

        return Results.Ok(await vehicleQueryService.GetAllAsync(pageOptionsDto.ToPageOptions(), new VehicleQueryOptions { ManagerId = managerId }));
    }

    private static Task<IResult> GetById(int vehicleId, HttpContext httpContext)
    {
        VehicleViewModel vehicle = httpContext.Items["Vehicle"] as VehicleViewModel ?? throw new InvalidOperationException("Vehicle not found in the request context.");

        return Task.FromResult(Results.Ok(vehicle));
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

    private static async Task<IResult> Update(VehicleActionService vehicleActionService, VehicleDTO vehicleDTO, int vehicleId)
    {
        try
        {
            await vehicleActionService.UpdateAsync(vehicleDTO, vehicleId);

            return Results.NoContent();
        }
        catch (VehicleBrandNotFoundException)
        {
            return Results.Problem(statusCode: 400, title: "Vehicle brand not found");
        }
        catch (VehicleNotFoundException)
        {
            return Results.Problem(statusCode: 404, title: "Vehicle not found");
        }
    }

    private static async Task<IResult> Delete(VehicleActionService vehicleActionService, int vehicleId)
    {
        await vehicleActionService.DeleteAsync(vehicleId);

        return Results.NoContent();
    }

    private static async Task<IResult> GetGeoPoints(GeoQueryService geoQueryService, [AsParameters] GetGeoPointsParameters parameters, HttpContext httpContext)
    {
        parameters.Format ??= GeoPointFormat.JSON;

        List<GeoPointViewModel> geoPoints = await geoQueryService.GetVehicleGeopoints(parameters.VehicleId, parameters.StartDateTime, parameters.EndDateTime);

        if (geoPoints.Count == 0) return Results.NoContent();

        return parameters.Format switch
        {
            GeoPointFormat.JSON => Results.Ok(geoPoints),
            GeoPointFormat.GeoJSON => Results.Ok(geoPoints.ToGeoJSON()),
            _ => throw new InvalidOperationException("Invalid GeoPointFormat")
        };
    }

    private class GetGeoPointsParameters
    {

        public int VehicleId { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public GeoPointFormat? Format { get; set; } = GeoPointFormat.JSON;

    }

    private enum GeoPointFormat
    {

        JSON,

        GeoJSON

    }

}