using AutoMapper;

using Microsoft.EntityFrameworkCore;

using MotorPool.Domain;
using MotorPool.Persistence;
using MotorPool.Services.Enterprise.Models;

namespace MotorPool.Services.Enterprise.Services.Concrete;

public class DefaultEnterpriseService(AppDbContext dbContext) : EnterpriseService
{

    public async ValueTask<List<EnterpriseViewModel>> GetAllAsync()
    {
        return await dbContext.Enterprises.AsNoTracking()
                                                  .Select(enterprise => new EnterpriseViewModel
                                                  {
                                                      EnterpriseId = enterprise.EnterpriseId,
                                                      Name = enterprise.Name,
                                                      City = enterprise.City,
                                                      Street = enterprise.Street,
                                                      VAT = enterprise.VAT,
                                                      FoundedOn = enterprise.FoundedOn,
                                                      Vehicles = enterprise.Vehicles
                                                                           .Select(enterpriseVehicle => new VehicleSummaryModel
                                                                           {
                                                                               VehicleId = enterpriseVehicle.Vehicle.VehicleId,
                                                                               Cost = enterpriseVehicle.Vehicle.Cost,
                                                                               ModelName = enterpriseVehicle.Vehicle.VehicleBrand.ModelName,
                                                                               CompanyName = enterpriseVehicle.Vehicle.VehicleBrand.CompanyName,
                                                                               AssignedDriversCount = enterpriseVehicle.EnterpriseDriverLinks.Count,
                                                                               ActiveDriverId = enterpriseVehicle.EnterpriseDriverLinks
                                                                                                                 .Where(enterpriseVehicleDriver => enterpriseVehicleDriver.ActiveDriver != null)
                                                                                                                 .Select(enterpriseVehicleDriver =>
                                                                                                                     (int?)enterpriseVehicleDriver.ActiveDriver!.EnterpriseVehicleDriver.EnterpriseDriver.Driver.DriverId)
                                                                                                                 .FirstOrDefault()
                                                                           })
                                                                           .ToList(),
                                                      Drivers = enterprise.Drivers
                                                                          .Select(enterpriseDriver => new DriverSummaryModel
                                                                          {
                                                                              DriverId = enterpriseDriver.Driver.DriverId,
                                                                              FirstName = enterpriseDriver.Driver.FirstName,
                                                                              LastName = enterpriseDriver.Driver.LastName,
                                                                              HiredOn = enterpriseDriver.HiredOn,
                                                                              AssignedVehiclesCount = enterpriseDriver.EnterpriseVehicleLinks.Count,
                                                                              ActiveVehicleId = enterpriseDriver.EnterpriseVehicleLinks
                                                                                                                .Where(enterpriseVehicleDriver => enterpriseVehicleDriver.ActiveDriver != null)
                                                                                                                .Select(enterpriseVehicleDriver =>
                                                                                                                    (int?)enterpriseVehicleDriver.ActiveDriver.EnterpriseVehicleDriver.EnterpriseVehicle.VehicleId)
                                                                                                                .FirstOrDefault()
                                                                          })
                                                                          .ToList()
                                                  })
                                                  .ToListAsync();
    }

}