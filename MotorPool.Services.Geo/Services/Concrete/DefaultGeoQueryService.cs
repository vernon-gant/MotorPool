using AutoMapper;

using Microsoft.EntityFrameworkCore;

using MotorPool.Domain;
using MotorPool.Persistence;
using MotorPool.Services.Geo.Models;

namespace MotorPool.Services.Geo.Services.Concrete;

public class DefaultGeoQueryService(AppDbContext dbContext, IMapper mapper) : GeoQueryService
{

    public async ValueTask<List<GeoPointViewModel>> GetVehicleGeopoints(int vehicleId, DateTime start, DateTime end)
    {
        if (start > end) throw new ArgumentException("Start date cannot be greater than end date");

        Enterprise vehicleEnterprise = dbContext.Vehicles
                                                .Include(vehicle => vehicle.Enterprise)
                                                .Where(vehicle => vehicle.VehicleId == vehicleId)
                                                .Select(vehicle => vehicle.Enterprise!)
                                                .First();

        TimeZoneInfo enterpriseTimeZone = TimeZoneInfo.FindSystemTimeZoneById(vehicleEnterprise.TimeZoneId);

        return await dbContext.GeoPoints
                              .Include(geoPoint => geoPoint.Vehicle)
                              .Include(geoPoint => geoPoint.Vehicle!.Enterprise)
                              .Where(geoPoint => geoPoint.RecordedAt > TimeZoneInfo.ConvertTimeToUtc(start, enterpriseTimeZone) && geoPoint.RecordedAt < TimeZoneInfo.ConvertTimeToUtc(end, enterpriseTimeZone))
                              .Select(geoPoint => mapper.Map<GeoPointViewModel>(geoPoint))
                              .ToListAsync();
    }

}