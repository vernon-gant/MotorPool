using AutoMapper;

using MotorPool.Domain;
using MotorPool.Services.Geo.Models;

namespace MotorPool.Services.Geo;

public class GeoProfile : Profile
{

    public GeoProfile()
    {
        CreateMap<GeoPoint, GeoPointViewModel>()
            .ForMember(viewModel => viewModel.RecordedAt, options => options.MapFrom(geoPoint => geoPoint.RecordedAtInEnterpriseTimeZone));
    }

}