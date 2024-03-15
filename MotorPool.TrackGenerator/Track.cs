namespace MotorPool.TrackGenerator;

public struct Track
{
    public double AverageSpeed_kmh { get; set; }
    public Point StartPoint { get; set; }
    public List<Point> Hops { get; set; }

    public Point EndPoint { get; set; }

    public int VehicleId { get; set; }

    public static Track FromGraphHopperResponseWithOptions(GraphHopperResponse response, TrackOptions options)
    {
        return new Track
        {
            VehicleId = options.VehicleId,
            StartPoint = options.StartPoint,
            EndPoint = options.EndPoint,
            AverageSpeed_kmh = options.AverageSpeed_kmh,
            Hops = response.Paths[0]
                          .Points
                          .Coordinates
                          .Select(point => new Point(point[1], point[0]))
                          .ToList()
        };
    }

}