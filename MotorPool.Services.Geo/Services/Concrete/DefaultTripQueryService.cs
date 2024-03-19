using AutoMapper;

using Microsoft.EntityFrameworkCore;

using MotorPool.Domain;
using MotorPool.Persistence;
using MotorPool.Services.Geo.Models;

namespace MotorPool.Services.Geo.Services.Concrete;

public class DefaultTripQueryService(AppDbContext dbContext, IMapper mapper) : TripQueryService
{

    public async ValueTask<List<GeoPointViewModel>> GetVehicleTrip(int vehicleId, DateTime startTime, DateTime endTime)
    {
        if (startTime > endTime) throw new ArgumentException("Start date cannot be greater than end date");

        Enterprise vehicleEnterprise = dbContext.Vehicles
                                                .Include(vehicle => vehicle.Enterprise)
                                                .Where(vehicle => vehicle.VehicleId == vehicleId)
                                                .Select(vehicle => vehicle.Enterprise!)
                                                .First();

        TimeZoneInfo enterpriseTimeZone = TimeZoneInfo.FindSystemTimeZoneById(vehicleEnterprise.TimeZoneId);

        return await dbContext.GeoPoints
                              .Include(geoPoint => geoPoint.Vehicle)
                              .Include(geoPoint => geoPoint.Vehicle!.Enterprise)
                              .Where(geoPoint => geoPoint.RecordedAt > TimeZoneInfo.ConvertTimeToUtc(startTime, enterpriseTimeZone) &&
                                                 geoPoint.RecordedAt < TimeZoneInfo.ConvertTimeToUtc(endTime, enterpriseTimeZone))
                              .Select(geoPoint => mapper.Map<GeoPointViewModel>(geoPoint))
                              .ToListAsync();
    }

    public async ValueTask<List<GeoPointViewModel>> GetTrips(DateTime startTime, DateTime endTime)
    {
        if (startTime > endTime) throw new ArgumentException("Start date cannot be greater than end date");

        var tripsWithEnterpriseZoneId = await dbContext.Trips
                                                       .Include(trip => trip.Vehicle)
                                                       .Include(trip => trip.Vehicle!.Enterprise)
                                                       .Select(trip => new { Trip = trip, trip.Vehicle!.Enterprise.TimeZoneId })
                                                       .ToListAsync();

        return tripsWithEnterpriseZoneId
               .Where(tripZoneId => IsTripBetweenEnterpriseTimeZonedStartAndEndTime(tripZoneId.Trip, tripZoneId.TimeZoneId, startTime, endTime))
               .Select(tripZoneId => tripZoneId.Trip)
               .OrderBy(trip => trip.StartTime)
               .SelectMany(trip => dbContext.GeoPoints
                                            .Include(geoPoint => geoPoint.Vehicle)
                                            .Include(geoPoint => geoPoint.Vehicle!.Enterprise)
                                            .Where(geoPoint => geoPoint.VehicleId == trip.VehicleId &&
                                                               geoPoint.RecordedAt >= trip.StartTime &&
                                                               geoPoint.RecordedAt <= trip.EndTime)
                                            .OrderBy(geoPoint => geoPoint.RecordedAt))
               .Select(mapper.Map<GeoPointViewModel>)
               .ToList();
    }

    private bool IsTripBetweenEnterpriseTimeZonedStartAndEndTime(Trip trip, string zoneId, DateTime startTime, DateTime endTime)
    {
        TimeZoneInfo enterpriseTimeZone = TimeZoneInfo.FindSystemTimeZoneById(zoneId);

        return trip.StartTime >= TimeZoneInfo.ConvertTimeToUtc(startTime, enterpriseTimeZone) &&
               trip.EndTime <= TimeZoneInfo.ConvertTimeToUtc(endTime, enterpriseTimeZone);
    }

}