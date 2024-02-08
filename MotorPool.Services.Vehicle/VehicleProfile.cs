using AutoMapper;

using MotorPool.Domain;
using MotorPool.Services.Vehicles.ViewModels;

namespace MotorPool.Services.Vehicles;

public class AutoMapperProfile : Profile
{

    public AutoMapperProfile()
    {
        CreateMap<Vehicle, VehicleViewModel>()
            .ForMember(vehicleViewModel => vehicleViewModel.CompanyName, opt => opt.MapFrom(vehicle => vehicle.VehicleBrand.CompanyName))
            .ForMember(vehicleViewModel => vehicleViewModel.ModelName, opt => opt.MapFrom(vehicle => vehicle.VehicleBrand.ModelName));

        CreateMap<VehicleDTO, Vehicle>();
    }

}