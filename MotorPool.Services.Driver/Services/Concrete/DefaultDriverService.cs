using System.Runtime.CompilerServices;

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

}