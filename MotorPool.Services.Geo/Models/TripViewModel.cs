namespace MotorPool.Services.Geo.Models;

public class TripViewModel
{

    public int TripId { get; set; }

    public PointViewModel StartPoint { get; set; }

    public string StartPointDescription { get; set; } = string.Empty;

    public PointViewModel EndPoint { get; set; }

    public string EndPointDescription { get; set; } = string.Empty;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

}