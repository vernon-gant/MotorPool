using MotorPool.Domain;
using MotorPool.Persistence;

namespace MotorPool.TrackGenerator;

public class TrackGenerator(AppDbContext dbContext, GraphHopperClient graphHopperClient, Track track)
{

    private const double MINIMAL_DRIVING_TIME_s = 8;

    private readonly List<Point> _wholeTrack = new List<Point> {track.StartPoint}.Concat(track.Hops).Concat(new List<Point> {track.EndPoint}).ToList();

    private double AverageSpeed_mps => track.AverageSpeed_kmh / 3.6;

    private double GetDrivingTime_s(double distance_m) => distance_m / AverageSpeed_mps;

    private void SaveGeoPoint(GeoPoint geoPoint)
    {
        dbContext.GeoPoints.Add(geoPoint);
        dbContext.SaveChanges();
        Console.WriteLine($"----- Recorded point: {geoPoint} -----\n\n");
    }

    private (int, double) GetNextHopIndexWithDelay(Point currentLocation, int nextHopIndex)
    {
        double distance_m = Haversine.GetPointsDistance(currentLocation, _wholeTrack[nextHopIndex]);
        for (;GetDrivingTime_s(distance_m) < MINIMAL_DRIVING_TIME_s; distance_m = Haversine.GetPointsDistance(currentLocation, _wholeTrack[nextHopIndex]))
        {
            if (nextHopIndex == _wholeTrack.Count - 1) break;

            nextHopIndex++;
        }
        return (nextHopIndex, GetDrivingTime_s(distance_m));
    }

    public void Generate()
    {
        Console.WriteLine("\n");
        Console.WriteLine("#".PadRight(50, '#'));
        Console.WriteLine($"Generating track for vehicle {track.VehicleId} from {track.StartPoint} to {track.EndPoint}.");
        Console.WriteLine("#".PadRight(50, '#'));
        Console.WriteLine("\n\n");
        GeoPoint currentGeoPoint = track.StartPoint.ToGeoPoint(DateTime.UtcNow, track.VehicleId);
        for (int i = 0; i < _wholeTrack.Count - 1;)
        {
            SaveGeoPoint(currentGeoPoint);
            (int nextHopIdx, double drivingTime_s) = GetNextHopIndexWithDelay(_wholeTrack[i], i + 1);
            i = nextHopIdx;
            currentGeoPoint = _wholeTrack[i].ToGeoPoint(currentGeoPoint.RecordedAt.AddSeconds(drivingTime_s), track.VehicleId);
        }
        SaveGeoPoint(currentGeoPoint);
        Console.WriteLine("\n");
        Console.WriteLine("#".PadRight(50, '#'));
        Console.WriteLine($"Track for vehicle {track.VehicleId} has been generated.");
        Console.WriteLine("#".PadRight(50, '#'));
    }

}