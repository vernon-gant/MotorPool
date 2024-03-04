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

    public async ValueTask<PagedViewModel<DriverViewModel>> GetAllAsync(int managerId, PageOptions pageOptions)
    {
        IQueryable<Driver> managerDriversQuery = dbContext.Drivers
                                                      .AsNoTracking()
                                                      .Include(driver => driver.DriverVehicles)
                                                      .Include(driver => driver.Enterprise)
                                                      .Include(driver => driver.Enterprise!.ManagerLinks)
                                                      .ForManager(managerId);

        int managerDriversCount = await managerDriversQuery.CountAsync();

        List<DriverViewModel> pagedDriverModels = await managerDriversQuery
                                                        .Page(pageOptions)
                                                        .Select(driver => mapper.Map<DriverViewModel>(driver))
                                                        .ToListAsync();

        return new ()
        {
            PagesAfter = managerDriversCount / pageOptions.ElementsPerPage - pageOptions.PageNumber - 1,
            Elements = pagedDriverModels
        };
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