using MotorPool.Domain;
using MotorPool.Persistence;

namespace MotorPool.TrackGenerator;

public class TrackGenerator(AppDbContext dbContext, Track track)
{
    private const double MINIMAL_DRIVING_TIME_s = 8;

    private readonly List<Point> _wholeTrack = new List<Point> { track.StartPoint }.Concat(track.Hops).Concat(new List<Point> { track.EndPoint }).ToList();

    private double AverageSpeed_mps => track.AverageSpeed_kmh / 3.6;

    private double GetDrivingTime_s(double distance_m) => distance_m / AverageSpeed_mps;

    private (int, double) GetNextHopIndexWithDelay(Point currentLocation, int nextHopIndex)
    {
        double distance_m = Haversine.GetPointsDistance(currentLocation, _wholeTrack[nextHopIndex]);
        for (; GetDrivingTime_s(distance_m) < MINIMAL_DRIVING_TIME_s; distance_m = Haversine.GetPointsDistance(currentLocation, _wholeTrack[nextHopIndex]))
        {
            if (nextHopIndex == _wholeTrack.Count - 1) break;

            nextHopIndex++;
        }

        return (nextHopIndex, GetDrivingTime_s(distance_m));
    }

    public void Generate()
    {
        using var transaction = dbContext.Database.BeginTransaction();

        try
        {
            GeoPoint startGeoPoint = track.StartPoint.ToGeoPoint(track.StartTime, track.VehicleId);
            List<GeoPoint> routePoints = [startGeoPoint];

            GeoPoint currentGeoPoint = startGeoPoint;
            for (int i = 0; i < _wholeTrack.Count - 1;)
            {
                (int nextHopIdx, double drivingTime_s) = GetNextHopIndexWithDelay(_wholeTrack[i], i + 1);
                i = nextHopIdx;
                currentGeoPoint = _wholeTrack[i].ToGeoPoint(currentGeoPoint.RecordedAt.AddSeconds(drivingTime_s), track.VehicleId);
                routePoints.Add(currentGeoPoint);
            }

            dbContext.GeoPoints.AddRange(routePoints);
            dbContext.SaveChanges();

            Trip generatedTrip = new Trip
                                 {
                                     VehicleId = track.VehicleId,
                                     StartTime = track.StartTime,
                                     EndTime = routePoints.Last().RecordedAt,
                                     StartGeoPointId = routePoints.First().GeoPointId,
                                     EndGeoPointId = routePoints.Last().GeoPointId
                                 };

            dbContext.Trips.Add(generatedTrip);
            dbContext.SaveChanges();

            foreach (var point in routePoints)
            {
                point.TripId = generatedTrip.TripId;
            }

            dbContext.GeoPoints.UpdateRange(routePoints);
            dbContext.SaveChanges();

            transaction.Commit();

            Console.WriteLine($"Trip {generatedTrip.TripId} for vehicle {track.VehicleId} has been generated.");
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            Console.WriteLine($"An error occurred while generating the trip: {ex.Message}");
        }
    }
}