using AutoMapper;

using MotorPool.Domain;
using MotorPool.Services.Vehicles.Models;
using MotorPool.Services.Vehicles.ViewModels;

namespace MotorPool.Services.Vehicles;

public class VehicleProfile : Profile
{

    public VehicleProfile()
    {
        CreateMap<Vehicle, VehicleViewModel>()
            .ForMember(vehicleViewModel => vehicleViewModel.CompanyName, opt => opt.MapFrom(vehicle => vehicle.VehicleBrand.CompanyName))
            .ForMember(vehicleViewModel => vehicleViewModel.ModelName, opt => opt.MapFrom(vehicle => vehicle.VehicleBrand.ModelName))
            .ForMember(vehicleViewModel => vehicleViewModel.DriverIds, opt => opt.MapFrom(vehicle => vehicle.DriverVehicles.Select(driverVehicle => driverVehicle.DriverId)));

        CreateMap<VehicleDTO, Vehicle>();
    }

}