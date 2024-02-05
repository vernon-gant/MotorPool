using AutoMapper;

using MotorPool.Domain;
using MotorPool.Services.Vehicles.ViewModels;

namespace MotorPool.Services.Vehicles;

public class AutoMapperProfile : Profile
{

    public AutoMapperProfile()
    {
        CreateMap<Vehicle, VehicleFormViewModel>();
        CreateMap<VehicleFormViewModel, Vehicle>()
            .ForMember(dest => dest.VehicleId, opt => opt.Ignore());
    }

}