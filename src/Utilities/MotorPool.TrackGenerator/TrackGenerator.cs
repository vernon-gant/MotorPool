using MotorPool.Domain;
using MotorPool.Persistence;

namespace MotorPool.TrackGenerator;

public class TrackGenerator(AppDbContext dbContext, Track track)
{
    private const double MINIMAL_DRIVING_TIME_s = 8;

    private readonly List<Point> _wholeTrack = new List<Point> { track.StartPoint }.Concat(track.Hops)
        .Concat(new List<Point> { track.EndPoint }).ToList();

    private double AverageSpeed_mps => track.AverageSpeed_kmh / 3.6;

    private double GetDrivingTime_s(double distance_m) => distance_m / AverageSpeed_mps;

    private (int, double) GetNextHopIndexWithDelay(Point currentLocation, int nextHopIndex)
    {
        double distance_m = Haversine.GetPointsDistance(currentLocation, _wholeTrack[nextHopIndex]);
        for (;
             GetDrivingTime_s(distance_m) < MINIMAL_DRIVING_TIME_s;
             distance_m = Haversine.GetPointsDistance(currentLocation, _wholeTrack[nextHopIndex]))
        {
            if (nextHopIndex == _wholeTrack.Count - 1) break;

            nextHopIndex++;
        }

        return (nextHopIndex, GetDrivingTime_s(distance_m));
    }

    public void Generate()
    {
        GeoPoint currentGeoPoint = track.StartPoint.ToGeoPoint(track.StartTime, track.VehicleId);
        List<GeoPoint> routePoints = [currentGeoPoint];
        for (int i = 0; i < _wholeTrack.Count - 1;)
        {
            (int nextHopIdx, double drivingTime_s) = GetNextHopIndexWithDelay(_wholeTrack[i], i + 1);
            i = nextHopIdx;
            currentGeoPoint = _wholeTrack[i]
                .ToGeoPoint(currentGeoPoint.RecordedAt.AddSeconds(drivingTime_s), track.VehicleId);
            routePoints.Add(currentGeoPoint);
        }
        dbContext.GeoPoints.AddRange(routePoints);
        Trip generatedTrip = new Trip { StartTime = track.StartTime, EndTime = routePoints.Last().RecordedAt, VehicleId = track.VehicleId };
        dbContext.Trips.Add(generatedTrip);
        dbContext.SaveChanges();
        Console.WriteLine($"Trip {generatedTrip.TripId} for vehicle {track.VehicleId} has been generated.");
    }
}