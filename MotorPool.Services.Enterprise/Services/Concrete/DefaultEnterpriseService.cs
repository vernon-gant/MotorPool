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
                                  VehicleIds = enterprise.Vehicles
                                                       .Select(vehicle => vehicle.VehicleId).ToList(),
                                  DriverIds = enterprise.Drivers
                                                      .Select(driver => driver.DriverId).ToList()
                              })
                              .ToListAsync();
    }

}