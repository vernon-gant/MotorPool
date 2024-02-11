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
                                  EnterpriseId = driver.EnterpriseLink != null ? driver.EnterpriseLink.EnterpriseId : null,
                                  DriverEnterpriseSummary = driver.EnterpriseLink != null
                                      ? new DriverEnterpriseSummary
                                      {
                                          AssignedVehiclesCount = driver.EnterpriseLink.EnterpriseVehicleLinks.Count,
                                          ActiveVehicleId = driver.EnterpriseLink
                                                                  .EnterpriseVehicleLinks
                                                                  .Where(enterpriseVehicleDriver => enterpriseVehicleDriver.ActiveDriver != null)
                                                                  .Select(enterpriseVehicleDriver => (int?)enterpriseVehicleDriver.ActiveDriver.EnterpriseVehicleDriver.EnterpriseVehicle.VehicleId)
                                                                  .FirstOrDefault()
                                      }
                                      : null
                              })
                              .ToListAsync();
    }

}