using AutoMapper;

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

        return await dbContext.GeoPoints
                              .Include(geoPoint => geoPoint.Vehicle)
                              .Include(geoPoint => geoPoint.Vehicle!.Enterprise)
                              .Where(geoPoint => geoPoint.RecordedAt > TimeZoneInfo.ConvertTimeToUtc(startTime, enterpriseTimeZone) &&
                                                 geoPoint.RecordedAt < TimeZoneInfo.ConvertTimeToUtc(endTime, enterpriseTimeZone))
                              .Select(geoPoint => mapper.Map<GeoPointViewModel>(geoPoint))
                              .ToListAsync();
    }

    public async ValueTask<IEnumerable<GeoPointViewModel>> GetVehicleTripsInGeoPoints(int vehicleId, DateTime startTime, DateTime endTime)
    {
        if (startTime > endTime) throw new ArgumentException("Start date cannot be greater than end date");

        TimeZoneInfo enterpriseTimeZone = dbContext.Vehicles.GetVehicleTimeZoneInfo(vehicleId);

        return await dbContext.Trips
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
                              .ToListAsync();
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

    private async ValueTask<TripViewModel> TripToViewModel(Trip trip, TimeZoneInfo enterpriseTimeZone, GeoPoint startPoint, GeoPoint endPoint)
    {
        TripViewModel tripViewModel = mapper.Map<TripViewModel>(trip, options => { options.Items["EnterpriseTimeZone"] = enterpriseTimeZone; });

        tripViewModel.StartPoint = startPoint.Coordinates;
        tripViewModel.StartPointDescription = await graphHopperClient.GetPointTextualAddress(startPoint);
        tripViewModel.EndPoint = endPoint.Coordinates;
        tripViewModel.EndPointDescription = await graphHopperClient.GetPointTextualAddress(endPoint);

        return tripViewModel;
    }

}