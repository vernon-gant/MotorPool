using AutoMapper;

using MotorPool.Services.VehicleBrand.Models;
using MotorPool.Utils;

namespace MotorPool.Services.VehicleBrand;

public class VehicleBrandProfile : Profile
{

    public VehicleBrandProfile()
    {
        CreateMap<Domain.VehicleBrand, VehicleBrandViewModel>()
            .ForMember(viewModel => viewModel.Type, opt => opt.MapFrom(vehicleBrand => vehicleBrand.Type.GetDisplayName()));
    }

}