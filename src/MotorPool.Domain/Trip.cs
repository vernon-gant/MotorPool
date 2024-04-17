namespace MotorPool.Domain;

public class Trip
{

    public int TripId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public int VehicleId { get; set; }

    public Vehicle? Vehicle { get; set; }

}