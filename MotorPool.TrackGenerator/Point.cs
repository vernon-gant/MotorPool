using System.Globalization;

using MotorPool.Domain;

namespace MotorPool.TrackGenerator;
public struct Point(double latitude, double longitude)
{

    public double Latitude { get; set; } = latitude;

    public double Longitude { get; set; } = longitude;

    public static Point FromString(string pointString)
    {
        string[] coordinates = pointString.Split(',');
        return new Point(double.Parse(coordinates[0], NumberStyles.Any, CultureInfo.CurrentCulture), double.Parse(coordinates[1], NumberStyles.Any, CultureInfo.CurrentCulture));
    }

    public GeoPoint ToGeoPoint(DateTime recordedAt, int vehicleId)
    {
        return new GeoPoint
        {
            Latitude = Latitude,
            Longitude = Longitude,
            VehicleId = vehicleId,
            RecordedAt = recordedAt
        };
    }

    public override string ToString()
    {
        return $"{Latitude},{Longitude}";
    }

}
