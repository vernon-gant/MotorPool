﻿using AutoMapper;

using Microsoft.EntityFrameworkCore;

using MotorPool.Domain;
using MotorPool.Persistence;
using MotorPool.Persistence.QueryObjects;
using MotorPool.Services.Geo.Models;

namespace MotorPool.Services.Geo.Services.Concrete;

public class DefaultTripQueryService(AppDbContext dbContext, IMapper mapper) : TripQueryService
{

    public async ValueTask<List<GeoPointViewModel>> GetVehicleGeoPoints(int vehicleId, DateTime startTime, DateTime endTime)
    {
        if (startTime > endTime) throw new ArgumentException("Start date cannot be greater than end date");

        TimeZoneInfo enterpriseTimeZone = dbContext.Vehicles.GetVehicleTimeZoneInfo(vehicleId);

        return await dbContext.GeoPoints
                              .Include(geoPoint => geoPoint.Vehicle)
                              .Include(geoPoint => geoPoint.Vehicle!.Enterprise)
                              .Where(geoPoint => geoPoint.RecordedAt > TimeZoneInfo.ConvertTimeToUtc(startTime, enterpriseTimeZone) &&
                                                 geoPoint.RecordedAt < TimeZoneInfo.ConvertTimeToUtc(endTime, enterpriseTimeZone))
                              .Select(geoPoint => mapper.Map<GeoPointViewModel>(geoPoint))
                              .ToListAsync();
    }

    public async ValueTask<List<GeoPointViewModel>> GetVehicleTripsInGeoPoints(int vehicleId, DateTime startTime, DateTime endTime)
    {
        if (startTime > endTime) throw new ArgumentException("Start date cannot be greater than end date");

        TimeZoneInfo enterpriseTimeZone = dbContext.Vehicles.GetVehicleTimeZoneInfo(vehicleId);

        return dbContext.Trips
                        .Where(trip => trip.StartTime >= TimeZoneInfo.ConvertTimeToUtc(startTime, enterpriseTimeZone) &&
                                       trip.EndTime <= TimeZoneInfo.ConvertTimeToUtc(endTime, enterpriseTimeZone) && trip.VehicleId == vehicleId)
                        .OrderBy(trip => trip.StartTime)
                        .SelectMany(trip => dbContext.GeoPoints
                                                     .Include(geoPoint => geoPoint.Vehicle)
                                                     .Include(geoPoint => geoPoint.Vehicle!.Enterprise)
                                                     .Where(geoPoint => geoPoint.VehicleId == trip.VehicleId &&
                                                                        geoPoint.RecordedAt >= trip.StartTime &&
                                                                        geoPoint.RecordedAt <= trip.EndTime)
                                                     .OrderBy(geoPoint => geoPoint.RecordedAt))
                        .Select(trip => mapper.Map<GeoPointViewModel>(trip))
                        .ToList();
    }

}