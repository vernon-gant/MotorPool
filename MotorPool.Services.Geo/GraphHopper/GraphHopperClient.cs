using System.Net.Http.Json;

using MotorPool.Domain;

namespace MotorPool.Services.Geo.GraphHopper;

public class GraphHopperClient(HttpClient httpClient, GraphHopperConfiguration graphHopperConfiguration)
{
    public async ValueTask<string> GetReverseGeocodingAsync(GeoPoint geoPoint)
    {
        HttpResponseMessage response = await httpClient.GetAsync($"geocode?reverse=true&point={geoPoint.Coordinates}&key={graphHopperConfiguration.ApiKey}");
        response.EnsureSuccessStatusCode();
        ReverseGeocodingResponse? responseBody = await response.Content.ReadFromJsonAsync<ReverseGeocodingResponse>();

        if (responseBody is null) return "Address not found";

        return responseBody.Hits.First().ToString();
    }

    public async ValueTask<decimal> GetDistanceAsync_m(GeoPoint start, GeoPoint end)
    {
        string url =
            $"route?point={start.Coordinates}&point={end.Coordinates}&profile=car&key={graphHopperConfiguration.ApiKey}&calc_points=true&instructions=false&points_encoded=false";
        HttpResponseMessage response = await httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        RouteResponse responseBody = await response.Content.ReadFromJsonAsync<RouteResponse>();

        return responseBody.Paths.First().Distance;
    }
}

internal struct RouteResponse
{
    public List<Path> Paths { get; set; }
}

internal struct Path
{
    public decimal Distance { get; set; }

    public PointsInfo Points { get; set; }
}

internal struct PointsInfo
{
    public List<List<double>> Coordinates { get; set; }
}

internal class ReverseGeocodingResponse
{
    public List<AddressHit> Hits { get; set; } = new ();
}

internal class AddressHit
{
    public string Name { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string State { get; set; } = string.Empty;

    public string Street { get; set; } = string.Empty;

    public int Postcode { get; set; }

    private string FormatValue(string value, bool isEnd = false) => string.IsNullOrEmpty(value) ? "" : value + (isEnd ? "" : ", ");

    public override string ToString() =>
        $"{FormatValue(Country)}{FormatValue(State)}{FormatValue(City)}{FormatValue(Street)}{FormatValue(Name)}{FormatValue(Postcode.ToString(), true)}";
}