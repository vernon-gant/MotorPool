using AutoMapper;

using MotorPool.Domain;
using MotorPool.Services.Vehicles.ViewModels;

namespace MotorPool.Services.Vehicles;

public class AutoMapperProfile : Profile
{

    public AutoMapperProfile()
    {
        CreateMap<Vehicle, VehicleEditViewModel>();
        CreateMap<VehicleEditViewModel, Vehicle>()
            .ForMember(dest => dest.VehicleId, opt => opt.Ignore());
    }

}