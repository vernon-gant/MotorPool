using AutoMapper;

using MotorPool.Services.Enterprise.Models;

namespace MotorPool.Services.Enterprise;

public class EnterpriseProfile : Profile
{

    public EnterpriseProfile()
    {
        CreateMap<Domain.Enterprise, EnterpriseViewModel>()
            .ForMember(enterpriseViewModel => enterpriseViewModel.DriverIds, opt => opt.MapFrom(enterprise => enterprise.Drivers.Select(driver => driver.DriverId)))
            .ForMember(enterpriseViewModel => enterpriseViewModel.VehicleIds, opt => opt.MapFrom(enterprise => enterprise.Vehicles.Select(vehicle => vehicle.VehicleId)))
            .ForMember(enterpriseViewModel => enterpriseViewModel.ManagerIds, opt => opt.MapFrom(enterprise => enterprise.ManagerLinks.Select(managerLink => managerLink.ManagerId)));
    }

}