namespace MotorPool.TrackGenerator;
public class Point(double latitude, double longitude)
{

    public double Latitude { get; set; } = latitude;

    public double Longitude { get; set; } = longitude;

    public static Point FromString(string pointString)
    {
        string[] coordinates = pointString.Split(',');
        coordinates = coordinates.Select(c => c.Replace(".", ",")).ToArray();
        return new Point(double.Parse(coordinates[0]), double.Parse(coordinates[1]));
    }

}
