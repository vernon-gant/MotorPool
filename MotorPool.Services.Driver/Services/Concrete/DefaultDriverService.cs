using AutoMapper;

using Microsoft.EntityFrameworkCore;

using MotorPool.Domain;
using MotorPool.Persistence;
using MotorPool.Services.Drivers.Models;

namespace MotorPool.Services.Drivers.Services.Concrete;

public class DefaultDriverService(AppDbContext dbContext, IMapper mapper) : DriverService
{

    public async ValueTask<List<DriverViewModel>> GetAllAsync()
    {
        List<Driver> rawDrivers = await dbContext.Drivers
                                                 .AsNoTracking()
                                                 .Include(driver => driver.DriverVehicles)
                                                 .ToListAsync();

        return mapper.Map<List<DriverViewModel>>(rawDrivers);
    }

    public async ValueTask<List<DriverViewModel>> GetByManagerIdAsync(int managerId)
    {
        List<Driver> managerAccessibleDrivers = await dbContext.Drivers
                                                               .AsNoTracking()
                                                               .Include(driver => driver.DriverVehicles)
                                                               .Include(driver => driver.Enterprise)
                                                               .Include(driver => driver.Enterprise!.ManagerLinks)
                                                               .Where(driver => driver.Enterprise != null &&
                                                                                driver.Enterprise.ManagerLinks.Any(link => link.ManagerId == managerId))
                                                               .ToListAsync();

        return mapper.Map<List<DriverViewModel>>(managerAccessibleDrivers);
    }

}