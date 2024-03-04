using AutoMapper;

using Microsoft.EntityFrameworkCore;

using MotorPool.Domain;
using MotorPool.Persistence;
using MotorPool.Persistence.QueryObjects;
using MotorPool.Services.Drivers.Models;
using MotorPool.Services.Manager;
using MotorPool.Services.Utils;

namespace MotorPool.Services.Drivers.Services.Concrete;

public class DefaultDriverQueryService(AppDbContext dbContext, IMapper mapper) : DriverQueryService
{

    public async ValueTask<List<DriverViewModel>> GetAllAsync(int managerId)
    {
        return await DriversWithIncludesQuery()
                     .ForManager(managerId)
                     .Select(driver => mapper.Map<DriverViewModel>(driver))
                     .ToListAsync();
    }

    public async ValueTask<PagedViewModel<DriverViewModel>> GetAllAsync(int managerId, PageOptions pageOptions)
    {
        IQueryable<Driver> managerDriversQuery = DriversWithIncludesQuery().ForManager(managerId);

        List<DriverViewModel> pagedDriverModels = await managerDriversQuery
                                                        .Page(pageOptions)
                                                        .OrderBy(driver => driver.DriverId)
                                                        .Select(driver => mapper.Map<DriverViewModel>(driver))
                                                        .ToListAsync();

        int managerDriversCount = await managerDriversQuery.CountAsync();

        return PagedViewModel<DriverViewModel>.FromOptionsAndElements(pageOptions, pagedDriverModels, managerDriversCount);
    }

    public async ValueTask<DriverViewModel> GetByIdAsync(int driverId)
    {
        Driver? driver = await DriversWithIncludesQuery().FirstOrDefaultAsync(driver => driver.DriverId == driverId);

        return mapper.Map<DriverViewModel>(driver);
    }

    private IQueryable<Driver> DriversWithIncludesQuery() => dbContext.Drivers
                                                                      .AsNoTracking()
                                                                      .Include(driver => driver.DriverVehicles)
                                                                      .Include(driver => driver.Enterprise)
                                                                      .Include(driver => driver.Enterprise!.ManagerLinks);

}