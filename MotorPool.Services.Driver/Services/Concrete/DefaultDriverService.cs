using Microsoft.EntityFrameworkCore;

using MotorPool.Persistence;
using MotorPool.Services.Drivers.Models;

namespace MotorPool.Services.Drivers.Services.Concrete;

public class DefaultDriverService(AppDbContext dbContext) : DriverService
{

    public async ValueTask<List<DriverViewModel>> GetAllAsync()
    {
        return await dbContext.Drivers
                              .AsNoTracking()
                              .Select(driver => new DriverViewModel
                              {
                                  DriverId = driver.DriverId,
                                  FirstName = driver.FirstName,
                                  LastName = driver.LastName,
                                  Salary = driver.Salary,
                                  EnterpriseId = driver.EnterpriseId,
                                  ActiveVehicleId = driver.ActiveVehicleId,
                                  Vehicles = driver.DriverVehicles.Select(driverVehicle => new VehicleSummary
                                  {
                                      VehicleId = driverVehicle.VehicleId,
                                      CompanyName = driverVehicle.Vehicle.VehicleBrand.CompanyName,
                                      ModelName = driverVehicle.Vehicle.VehicleBrand.ModelName
                                  }).ToList()
                              })
                              .ToListAsync();
    }

}