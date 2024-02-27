using AutoMapper;

using Microsoft.EntityFrameworkCore;

using MotorPool.Domain;
using MotorPool.Persistence;
using MotorPool.Services.Drivers.Models;

namespace MotorPool.Services.Drivers.Services.Concrete;

public class DefaultDriverQueryService(AppDbContext dbContext, IMapper mapper) : DriverQueryService
{

    public async ValueTask<List<DriverViewModel>> GetAllAsync()
    {
        List<Driver> rawDrivers = await dbContext.Drivers
                                        .AsNoTracking()
                                        .Include(driver => driver.DriverVehicles)
                                        .Include(driver => driver.Enterprise)
                                        .Include(driver => driver.Enterprise!.ManagerLinks)
                                        .Include(driver => driver.DriverVehicles)
                                        .ToListAsync();

        return mapper.Map<List<DriverViewModel>>(rawDrivers);
    }

    public async ValueTask<DriverViewModel> GetByIdAsync(int driverId)
    {
        Driver? driver = await dbContext.Drivers
                            .AsNoTracking()
                            .Include(driver => driver.DriverVehicles)
                            .Include(driver => driver.Enterprise)
                            .Include(driver => driver.Enterprise!.ManagerLinks)
                            .Include(driver => driver.DriverVehicles)
                            .FirstOrDefaultAsync(driver => driver.DriverId == driverId);

        return mapper.Map<DriverViewModel>(driver);
    }

}