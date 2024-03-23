using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace MotorPool.Domain;

public class GeoPoint
{

    [Key]
    public int GeoPointId { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public int VehicleId { get; set; }

    public Vehicle? Vehicle { get; set; }

    public DateTime RecordedAt { get; set; }

    [NotMapped]
    public DateTime RecordedAtInEnterpriseTimeZone
    {
        get
        {
            string enterpriseTimeZoneId = Vehicle?.Enterprise?.TimeZoneId ?? throw new InvalidOperationException("Enterprise Time zone could not be reached");
            TimeZoneInfo enterpriseTimeZone = TimeZoneInfo.FindSystemTimeZoneById(enterpriseTimeZoneId);
            return TimeZoneInfo.ConvertTimeFromUtc(RecordedAt, enterpriseTimeZone);
        }
    }

    public string Coordinates => $"{Latitude.ToString("F6", CultureInfo.InvariantCulture)},{Longitude.ToString("F6", CultureInfo.InvariantCulture)}";

    public override string ToString() => $"GeoPointId: {GeoPointId}, Latitude: {Latitude}, Longitude: {Longitude}, VehicleId: {VehicleId}, RecordedAt: {RecordedAt}";

}