using MotorPool.Services.Geo.Models;

namespace MotorPool.Services.Geo.Services;

public interface GeoQueryService
{

    ValueTask<List<GeoPointViewModel>> GetVehicleGeopoints(int vehicleId, DateTime start, DateTime end);

}