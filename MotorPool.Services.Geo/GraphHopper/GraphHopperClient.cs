using System.Net.Http.Json;

using MotorPool.Domain;

namespace MotorPool.Services.Geo.GraphHopper;

public class GraphHopperClient(HttpClient httpClient, GraphHopperConfiguration graphHopperConfiguration)
{

    public async ValueTask<string> GetPointTextualAddress(GeoPoint geoPoint)
    {
        HttpResponseMessage response = await httpClient.GetAsync($"geocode?reverse=true&point={geoPoint.Coordinates}&key={graphHopperConfiguration.ApiKey}");
        response.EnsureSuccessStatusCode();
        GetGeoPointTextualAddressResponse? responseBody = await response.Content.ReadFromJsonAsync<GetGeoPointTextualAddressResponse>();

        if (responseBody is null) return "Address not found";

        return responseBody.Hits.First().ToString();
    }

}

internal class GetGeoPointTextualAddressResponse
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

    public override string ToString() => $"{FormatValue(Country)}{FormatValue(State)}{FormatValue(City)}{FormatValue(Street)}{FormatValue(Name)}{FormatValue(Postcode.ToString(),true)}";

}