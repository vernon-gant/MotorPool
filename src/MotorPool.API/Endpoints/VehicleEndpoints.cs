using System.Security.Claims;
using AutoMapper;
using MotorPool.API.EndpointFilters;
using MotorPool.Domain;
using MotorPool.Persistence.QueryObjects;
using MotorPool.Repository.Vehicle;
using MotorPool.Services.Geo;
using MotorPool.Services.Geo.Models;
using MotorPool.Services.Geo.Services;
using MotorPool.Services.Manager;
using MotorPool.Services.Vehicles.Exceptions;
using MotorPool.Services.Vehicles.Models;

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

        vehicleWithIdGroupBuilder.MapGet("trips/{startDateTime:datetime}/{endDateTime:datetime}", GetTripsInDateRange)
                                 .WithName("GetTripsInDateRange")
                                 .Produces<List<TripViewModel>>()
                                 .Produces(StatusCodes.Status404NotFound)
                                 .Produces(StatusCodes.Status403Forbidden);

        vehicleWithIdGroupBuilder.MapGet("trips/{startDateTime:datetime}/{endDateTime:datetime}/points", GetFullTripsInDateRange)
                                 .WithName("GetFullTripsInDateRange")
                                 .Produces<List<GeoPointViewModel>>()
                                 .Produces(StatusCodes.Status404NotFound)
                                 .Produces(StatusCodes.Status403Forbidden);

        vehicleWithIdGroupBuilder.MapGet("geoPoints/{startDateTime:datetime}/{endDateTime:datetime}", GetGeoPoints)
                                 .WithName("GetGeoPoints")
                                 .Produces<List<GeoPointViewModel>>()
                                 .Produces(StatusCodes.Status404NotFound)
                                 .Produces(StatusCodes.Status403Forbidden);
    }

    private static async Task<IResult> GetAll(VehicleQueryRepository vehicleQueryRepository, IMapper mapper, ClaimsPrincipal user, [AsParameters] PageOptionsDTO pageOptionsDto)
    {
        int managerId = user.GetManagerId();

        var vehicles = await vehicleQueryRepository.GetAllAsync(pageOptionsDto.ToPageOptions(), new VehicleQueryOptions { ManagerId = managerId });

        return Results.Ok(mapper.Map<List<VehicleViewModel>>(vehicles));
    }

    private static Task<IResult> GetById(int vehicleId, HttpContext httpContext)
    {
        VehicleViewModel vehicle = httpContext.Items["Vehicle"] as VehicleViewModel ?? throw new InvalidOperationException("Vehicle not found in the request context.");

        return Task.FromResult(Results.Ok(vehicle));
    }

    private static async Task<IResult> Create(VehicleChangeRepository vehicleChangeRepository, IMapper mapper, VehicleDTO vehicleDTO)
    {
        try
        {
            Vehicle newVehicle = mapper.Map<Vehicle>(vehicleDTO);

            await vehicleChangeRepository.CreateAsync(newVehicle);

            return Results.Created($"/vehicles/{newVehicle.VehicleId}", mapper.Map<VehicleViewModel>(newVehicle));
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

    private static async Task<IResult> Update(VehicleChangeRepository vehicleChangeRepository, VehicleQueryRepository vehicleQueryRepository, IMapper mapper, VehicleDTO vehicleDTO, int vehicleId)
    {
        try
        {
            Vehicle? toUpdate = await vehicleQueryRepository.GetByIdAsync(vehicleId);

            if (toUpdate is null) return Results.NotFound();

            await vehicleChangeRepository.UpdateAsync(mapper.Map(vehicleDTO, toUpdate));

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

    private static async Task<IResult> Delete(VehicleChangeRepository vehicleChangeRepository, int vehicleId)
    {
        await vehicleChangeRepository.DeleteAsync(vehicleId);

        return Results.NoContent();
    }

    private static async Task<IResult> GetTripsInDateRange(TripQueryService tripQueryService, [AsParameters] GetTripsInDateRangeParameters parameters)
    {
        if (!parameters.IsValid) return Results.BadRequest("Invalid date range");

        IEnumerable<TripViewModel> vehicleTrips = await tripQueryService.GetVehicleTrips(parameters.VehicleId, parameters.StartDateTime, parameters.EndDateTime);

        return Results.Ok(vehicleTrips);
    }

    private static async Task<IResult> GetFullTripsInDateRange(TripQueryService tripQueryService, [AsParameters] GetTripsInDateRangeParameters parameters)
    {
        if (!parameters.IsValid) return Results.BadRequest("Invalid date range");

        IEnumerable<GeoPointViewModel> geoPoints = await tripQueryService.GetVehicleTripsInGeoPoints(parameters.VehicleId, parameters.StartDateTime, parameters.EndDateTime);

        return Results.Ok(geoPoints);
    }

    private static async Task<IResult> GetGeoPoints(TripQueryService tripQueryService, [AsParameters] GetGeoPointsParameters parameters)
    {
        if (!parameters.IsValid) return Results.BadRequest("Invalid date range");

        IEnumerable<GeoPointViewModel> geoPoints = await tripQueryService.GetVehicleGeoPoints(parameters.VehicleId, parameters.StartDateTime, parameters.EndDateTime);

        return parameters.ReturnGeoJSON.HasValue && parameters.ReturnGeoJSON.Value ? Results.Ok(geoPoints.ToGeoJSON()) : Results.Ok(geoPoints);
    }

    private class GetTripsInDateRangeParameters
    {

        public int VehicleId { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public bool IsValid => StartDateTime < EndDateTime;

    }

    private class GetGeoPointsParameters : GetTripsInDateRangeParameters
    {

        public bool? ReturnGeoJSON { get; set; }

    }

}