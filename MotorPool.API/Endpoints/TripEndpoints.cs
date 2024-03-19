using MotorPool.Services.Geo.Models;
using MotorPool.Services.Geo.Services;

namespace MotorPool.API.Endpoints;

public static class TripEndpoints
{

    public static void MapTripEndpoints(this IEndpointRouteBuilder managerResourcesGroupBuilder)
    {
        RouteGroupBuilder tripGroup = managerResourcesGroupBuilder.MapGroup("trips");

        tripGroup.MapGet("{startDateTime:datetime}/{endDateTime:datetime}", GetTrips)
                 .WithName("Get trips by start and end dates")
                 .Produces<List<GeoPointViewModel>>();
    }

    private static async Task<IResult> GetTrips(TripQueryService tripQueryService, DateTime startDateTime, DateTime endDateTime) =>
        Results.Ok(await tripQueryService.GetTrips(startDateTime, endDateTime));

}