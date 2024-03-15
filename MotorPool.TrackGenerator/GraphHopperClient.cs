namespace MotorPool.TrackGenerator;

public class GraphHopperClient(string apiKey)
{

    private const string _baseUrl = "https://graphhopper.com/api/1/route";

    private readonly string _apiKey = apiKey;

    private static readonly HttpClient _httpClient = new ();

    public Track GetTrack(Point start, Point end)
    {

    }

}