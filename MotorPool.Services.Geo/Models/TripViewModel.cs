namespace MotorPool.Services.Geo.Models;

public class TripViewModel
{

    public int TripId { get; set; }

    public string StartPoint { get; set; }

    public string StartPointDescription { get; set; } = string.Empty;

    public string EndPoint { get; set; }

    public string EndPointDescription { get; set; } = string.Empty;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

}