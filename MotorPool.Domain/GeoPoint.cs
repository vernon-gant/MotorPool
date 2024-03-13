namespace MotorPool.Domain;

public class GeoPoint
{

    public int GeoPointId { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public int VehicleId { get; set; }

    public Vehicle? Vehicle { get; set; }

    public DateTime RecordedAt { get; set; }

}