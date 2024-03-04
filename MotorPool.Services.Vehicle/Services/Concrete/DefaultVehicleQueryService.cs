using AutoMapper;

using Microsoft.EntityFrameworkCore;

using MotorPool.Domain;
using MotorPool.Persistence;
using MotorPool.Persistence.QueryObjects;
using MotorPool.Services.Manager;
using MotorPool.Services.Utils;
using MotorPool.Services.Vehicles.Models;

namespace MotorPool.Services.Vehicles.Services.Concrete;

public class DefaultVehicleQueryService(AppDbContext dbContext, IMapper mapper) : VehicleQueryService
{

    public async ValueTask<PagedViewModel<VehicleViewModel>> GetAllAsync(int managerId, PageOptions pageOptions)
    {
        IQueryable<Vehicle> managerVehiclesQuery = dbContext.Vehicles
                                                   .AsNoTracking()
                                                   .Include(vehicle => vehicle.VehicleBrand)
                                                   .Include(vehicle => vehicle.DriverVehicles)
                                                   .Include(vehicle => vehicle.Enterprise)
                                                   .Include(vehicle => vehicle.Enterprise!.ManagerLinks)
                                                   .ForManager(managerId);

        int managerVehiclesCount = await managerVehiclesQuery.CountAsync();

        List<VehicleViewModel> pagedVehicleModels = await managerVehiclesQuery
                                                           .Page(pageOptions)
                                                           .Select(vehicle => mapper.Map<VehicleViewModel>(vehicle))
                                                           .ToListAsync();

        return new ()
        {
            PagesAfter = pageOptions.GetPagesAfter(managerVehiclesCount),
            Elements = pagedVehicleModels
        };
    }

    public async ValueTask<VehicleViewModel?> GetByIdAsync(int vehicleId)
    {
        var foundVehicle = await dbContext.Vehicles
                                          .Include(vehicle => vehicle.VehicleBrand)
                                          .Include(vehicle => vehicle.Enterprise)
                                          .Include(vehicle => vehicle.Enterprise!.ManagerLinks)
                                          .Include(vehicle => vehicle.DriverVehicles)
                                          .FirstOrDefaultAsync(m => m.VehicleId == vehicleId);

        return mapper.Map<VehicleViewModel>(foundVehicle);
    }

}