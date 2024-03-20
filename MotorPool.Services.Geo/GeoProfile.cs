using AutoMapper;

using MotorPool.Domain;
using MotorPool.Services.Geo.Models;

namespace MotorPool.Services.Geo;

public class GeoProfile : Profile
{

    public GeoProfile()
    {
        DateTimeToEnterpriseZoneConverter enterpriseZoneConverter = new();

        CreateMap<GeoPoint, GeoPointViewModel>()
            .ForMember(viewModel => viewModel.RecordedAt, options => options.MapFrom(geoPoint => geoPoint.RecordedAtInEnterpriseTimeZone));

        CreateMap<Trip, TripViewModel>()
            .ForMember(viewModel => viewModel.StartTime, opt => opt.ConvertUsing(enterpriseZoneConverter, src => src.StartTime))
            .ForMember(viewModel => viewModel.EndTime, opt => opt.ConvertUsing(enterpriseZoneConverter, src => src.EndTime));
    }

}