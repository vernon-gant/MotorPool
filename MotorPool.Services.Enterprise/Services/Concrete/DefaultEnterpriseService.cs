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
        return await dbContext.Enterprises
                              .AsNoTracking()
                              .Select(enterprise => new EnterpriseViewModel
                              {
                                  EnterpriseId = enterprise.EnterpriseId,
                                  Name = enterprise.Name,
                                  City = enterprise.City,
                                  Street = enterprise.Street,
                                  VAT = enterprise.VAT,
                                  FoundedOn = enterprise.FoundedOn,
                                  Vehicles = enterprise.Vehicles
                                                       .Select(vehicle => new VehicleSummaryViewModel
                                                       {
                                                           VehicleId = vehicle.VehicleId,
                                                           CompanyName = vehicle.VehicleBrand.CompanyName,
                                                           ModelName = vehicle.VehicleBrand.ModelName,
                                                           VIN = vehicle.MotorVIN
                                                       })
                                                       .ToList(),
                                  Drivers = enterprise.Drivers
                                                      .Select(driver => new DriverSummaryViewModel
                                                      {
                                                          DriverId = driver.DriverId,
                                                          FullName = driver.FirstName + " " + driver.LastName,
                                                          Salary = driver.Salary
                                                      })
                                                      .ToList()
                              })
                              .ToListAsync();
    }

}