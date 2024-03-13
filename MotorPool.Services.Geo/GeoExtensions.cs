using GeoJSON.Text.Feature;
using GeoJSON.Text.Geometry;

using MotorPool.Services.Geo.Models;

namespace MotorPool.Services.Geo;

public static class GeoExtensions
{

    public static FeatureCollection ToGeoJSON(this List<GeoPointViewModel> geoPoints)
    {
        FeatureCollection featureCollection = new ();

        geoPoints.Select(geoPoint => new Point(new Position(geoPoint.Latitude, geoPoint.Longitude)))
                 .ToList()
                 .ForEach(point => featureCollection.Features.Add(new Feature(point)));

        return featureCollection;
    }

}