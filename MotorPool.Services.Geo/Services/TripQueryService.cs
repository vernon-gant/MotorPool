using MotorPool.Services.Geo.Models;

namespace MotorPool.Services.Geo.Services;

public interface TripQueryService
{

    ValueTask<List<GeoPointViewModel>> GetVehicleTrip(int vehicleId, DateTime startTime, DateTime endTime);

    ValueTask<List<GeoPointViewModel>> GetTrips(DateTime startTime, DateTime endTime);

}