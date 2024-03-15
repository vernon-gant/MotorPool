using CommandLine;

namespace MotorPool.TrackGenerator;

public class TrackOptions
{

    private string _startPointString = string.Empty;

    [Option('s', "start", Required = true, HelpText = "The starting point of the track. Must be in format 'lat,long'.")]
    public string StartPointString
    {
        get => throw new InvalidOperationException("This property should not be used.");
        set => _startPointString = value;
    }

    public Point StartPoint => Point.FromString(_startPointString);

    private string _endPointString = string.Empty;

    [Option('e', "end", Required = true, HelpText = "The ending point of the track. Must be in format 'lat,long'.")]
    public string EndPointString
    {
        get => throw new InvalidOperationException("This property should not be used.");
        set => _endPointString = value;
    }

    public Point EndPoint => Point.FromString(_endPointString);

    [Option('a', "average-speed", HelpText = "The average speed of the vehicles.", Default = (double)60.0)]
    public double AverageSpeed { get; set; }

}
