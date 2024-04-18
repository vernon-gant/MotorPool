﻿using AutoMapper;

using Microsoft.EntityFrameworkCore;

using MotorPool.Domain;
using MotorPool.Persistence;
using MotorPool.Persistence.QueryObjects;
using MotorPool.Services.Geo.GraphHopper;
using MotorPool.Services.Geo.Models;

namespace MotorPool.Services.Geo.Services.Concrete;

public class DefaultTripQueryService(AppDbContext dbContext, IMapper mapper, GraphHopperClient graphHopperClient) : TripQueryService
{

    public async ValueTask<IEnumerable<GeoPointViewModel>> GetVehicleGeoPoints(int vehicleId, DateTime startTime, DateTime endTime)
    {
        if (startTime > endTime) throw new ArgumentException("Start date cannot be greater than end date");

        TimeZoneInfo enterpriseTimeZone = dbContext.Vehicles.GetVehicleTimeZoneInfo(vehicleId);

        List<GeoPoint> rawGeoPoints = await dbContext.GeoPoints
                                                     .Include(geoPoint => geoPoint.Vehicle)
                                                     .Include(geoPoint => geoPoint.Vehicle!.Enterprise)
                                                     .Where(geoPoint => geoPoint.RecordedAt > TimeZoneInfo.ConvertTimeToUtc(startTime, enterpriseTimeZone) &&
                                                                        geoPoint.RecordedAt < TimeZoneInfo.ConvertTimeToUtc(endTime, enterpriseTimeZone))
                                                     .ToListAsync();

        return rawGeoPoints.Select(geoPoint => mapper.Map<GeoPointViewModel>(geoPoint, options => { options.Items["EnterpriseTimeZone"] = enterpriseTimeZone; }));
    }

    public async ValueTask<IEnumerable<GeoPointViewModel>> GetVehicleTripsInGeoPoints(int vehicleId, DateTime startTime, DateTime endTime)
    {
        if (startTime > endTime) throw new ArgumentException("Start date cannot be greater than end date");

        TimeZoneInfo enterpriseTimeZone = dbContext.Vehicles.GetVehicleTimeZoneInfo(vehicleId);

        List<GeoPoint> rawGeoPoints = await dbContext.Trips
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
                                                     .ToListAsync();

        return rawGeoPoints.Select(geoPoint => mapper.Map<GeoPointViewModel>(geoPoint, options => { options.Items["EnterpriseTimeZone"] = enterpriseTimeZone; }));
    }

    public async ValueTask<IEnumerable<TripViewModel>> GetVehicleTrips(int vehicleId, DateTime startTime, DateTime endTime)
    {
        TimeZoneInfo enterpriseTimeZone = dbContext.Vehicles.GetVehicleTimeZoneInfo(vehicleId);

        List<Trip> vehicleTrips = await dbContext.Trips
                                                 .Where(trip => trip.StartTime >= TimeZoneInfo.ConvertTimeToUtc(startTime, enterpriseTimeZone) &&
                                                                trip.EndTime <= TimeZoneInfo.ConvertTimeToUtc(endTime, enterpriseTimeZone) && trip.VehicleId == vehicleId)
                                                 .OrderBy(trip => trip.StartTime)
                                                 .ToListAsync();

        List<GeoPoint> allTripsGeoPoints = vehicleTrips.SelectMany(trip => dbContext.GeoPoints
                                                                                    .Where(geoPoint => geoPoint.VehicleId == trip.VehicleId &&
                                                                                                       geoPoint.RecordedAt >= trip.StartTime &&
                                                                                                       geoPoint.RecordedAt <= trip.EndTime)
                                                                                    .OrderBy(geoPoint => geoPoint.RecordedAt))
                                                       .ToList();

        List<Task<TripViewModel>> tripToViewModelTasks = vehicleTrips.Select(async trip =>
                                                                     {
                                                                         List<GeoPoint> tripGeoPoints = allTripsGeoPoints.Where(geoPoint =>
                                                                                 geoPoint.RecordedAt >= trip.StartTime && geoPoint.RecordedAt <= trip.EndTime)
                                                                             .ToList();
                                                                         GeoPoint startPoint = tripGeoPoints.First();
                                                                         GeoPoint endPoint = tripGeoPoints.Last();

                                                                         return await TripToViewModel(trip, enterpriseTimeZone, startPoint, endPoint);
                                                                     })
                                                                     .ToList();

        return await Task.WhenAll(tripToViewModelTasks);
    }

    public async ValueTask<IEnumerable<(TripViewModel, List<GeoPointViewModel>)>> GetTripsWithRoutes(int vehicleId, IEnumerable<int> tripIds)
    {
        TimeZoneInfo enterpriseTimeZone = dbContext.Vehicles.GetVehicleTimeZoneInfo(vehicleId);

        List<Trip> vehicleTrips = await dbContext.Trips.Where(trip => tripIds.Contains(trip.TripId)).ToListAsync();

        List<(Trip trip, List<GeoPoint>)> tripsWithGeoPoints = vehicleTrips.Select(trip => (trip, dbContext.GeoPoints
                                                                                                           .Include(geoPoint => geoPoint.Vehicle)
                                                                                                           .Include(geoPoint => geoPoint.Vehicle!.Enterprise)
                                                                                                           .Where(geoPoint =>
                                                                                                                      geoPoint.RecordedAt >= trip.StartTime &&
                                                                                                                      geoPoint.RecordedAt <= trip.EndTime && geoPoint.VehicleId == trip.VehicleId)
                                                                                                           .OrderBy(geoPoint => geoPoint.RecordedAt)
                                                                                                           .ToList()))
                                                                           .ToList();

        var tripToViewModelTasks = tripsWithGeoPoints.Select(async tripWithGeoPoints =>
                                                     {
                                                         GeoPoint startPoint = tripWithGeoPoints.Item2.First();
                                                         GeoPoint endPoint = tripWithGeoPoints.Item2.Last();

                                                         List<GeoPointViewModel> geoPointViewModels =
                                                             mapper.Map<List<GeoPointViewModel>>(tripWithGeoPoints.Item2,
                                                                                                 options => { options.Items["EnterpriseTimeZone"] = enterpriseTimeZone; });

                                                         TripViewModel tripViewModel = await TripToViewModel(tripWithGeoPoints.trip, enterpriseTimeZone, startPoint, endPoint);

                                                         return (tripViewModel, geoPointViewModels);
                                                     })
                                                     .ToList();

        return await Task.WhenAll(tripToViewModelTasks);
    }

    private async ValueTask<TripViewModel> TripToViewModel(Trip trip, TimeZoneInfo enterpriseTimeZone, GeoPoint startPoint, GeoPoint endPoint)
    {
        TripViewModel tripViewModel = mapper.Map<TripViewModel>(trip, options => { options.Items["EnterpriseTimeZone"] = enterpriseTimeZone; });

        tripViewModel.StartPoint = new () { LatitudeDouble = startPoint.Latitude, LongitudeDouble = startPoint.Longitude };
        tripViewModel.StartPointDescription = await graphHopperClient.GetReverseGeocodingAsync(startPoint);
        tripViewModel.EndPoint = new () { LatitudeDouble = endPoint.Latitude, LongitudeDouble = endPoint.Longitude };
        tripViewModel.EndPointDescription = await graphHopperClient.GetReverseGeocodingAsync(endPoint);

        return tripViewModel;
    }

}