using MotorPool.Services.Geo.Models;

namespace MotorPool.Services.Geo.Services;

public interface TripQueryService
{

    ValueTask<List<GeoPointViewModel>> GetVehicleGeoPoints(int vehicleId, DateTime startTime, DateTime endTime);

    ValueTask<List<GeoPointViewModel>> GetVehicleTripsInGeoPoints(int vehicleId, DateTime startTime, DateTime endTime);

}