using System.Net;
using System.Text.Json;

namespace MotorPool.TrackGenerator;

public class GraphHopperClient(string apiKey)
{
    private const string _baseUrl = "https://graphhopper.com/api/1/route";

    private static readonly HttpClient _httpClient = new();

    private readonly JsonSerializerOptions _jsonSerializerOptions = new()
                                                                    {
                                                                        PropertyNameCaseInsensitive = true
                                                                    };

    public GraphHopperResponse GetTrack(Point start, Point end)
    {
        string url = $"{_baseUrl}?point={start}&point={end}&profile=car&key={apiKey}&calc_points=true&instructions=false&points_encoded=false";
        HttpResponseMessage response = _httpClient.GetAsync(url).Result;
        response.EnsureSuccessStatusCode();
        string responseBody = response.Content.ReadAsStringAsync().Result;

        return JsonSerializer.Deserialize<GraphHopperResponse>(responseBody, _jsonSerializerOptions);
    }

    public double GetPointsDistance(Point start, Point end)
    {
        try
        {
            return GetTrack(start, end).Paths[0].Distance;
        }
        catch (HttpRequestException e) when (e.StatusCode == HttpStatusCode.TooManyRequests)
        {
            Console.WriteLine("\nToo many requests. Waiting for 5 seconds.\n");

            Thread.Sleep(5000);

            return GetPointsDistance(start, end);
        }
    }
}

public struct GraphHopperResponse
{
    public List<Path> Paths { get; set; }
}

public struct Path
{
    public double Distance { get; set; }

    public PointsInfo Points { get; set; }
}

public struct PointsInfo
{
    public List<List<double>> Coordinates { get; set; }
}