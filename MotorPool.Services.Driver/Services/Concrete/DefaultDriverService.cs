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
                                  EnterpriseLink = driver.EnterpriseLink != null
                                      ? new EnterpriseSummaryViewModel
                                      {
                                          EnterpriseId = driver.EnterpriseLink.EnterpriseId,
                                          Name = driver.EnterpriseLink.Enterprise.Name,
                                          VAT = driver.EnterpriseLink.Enterprise.VAT,
                                          DriversCount = driver.EnterpriseLink.Enterprise.Drivers.Count,
                                          VehiclesCount = driver.EnterpriseLink.Enterprise.Vehicles.Count
                                      }
                                      : null
                              })
                              .ToListAsync();
    }

}