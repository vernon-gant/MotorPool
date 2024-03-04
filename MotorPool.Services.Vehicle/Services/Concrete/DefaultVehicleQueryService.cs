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

    public async ValueTask<List<VehicleViewModel>> GetAllAsync(int managerId)
    {
        return await VehiclesWithIncludesQuery()
                     .ForManager(managerId)
                     .Select(vehicle => mapper.Map<VehicleViewModel>(vehicle))
                     .ToListAsync();
    }

    public async ValueTask<PagedViewModel<VehicleViewModel>> GetAllAsync(int managerId, PageOptions pageOptions)
    {
        IQueryable<Vehicle> managerVehiclesQuery = VehiclesWithIncludesQuery().ForManager(managerId);

        List<VehicleViewModel> pagedVehicleModels = await managerVehiclesQuery
                                                          .Page(pageOptions)
                                                          .Select(vehicle => mapper.Map<VehicleViewModel>(vehicle))
                                                          .ToListAsync();

        int managerVehiclesCount = await managerVehiclesQuery.CountAsync();

        return PagedViewModel<VehicleViewModel>.FromOptionsAndElements(pageOptions, pagedVehicleModels, managerVehiclesCount);
    }

    public async ValueTask<VehicleViewModel?> GetByIdAsync(int vehicleId)
    {
        Vehicle? foundVehicle = await VehiclesWithIncludesQuery().FirstOrDefaultAsync(vehicle => vehicle.VehicleId == vehicleId);

        return mapper.Map<VehicleViewModel>(foundVehicle);
    }

    private IQueryable<Vehicle> VehiclesWithIncludesQuery() => dbContext.Vehicles
                                                                        .AsNoTracking()
                                                                        .Include(vehicle => vehicle.VehicleBrand)
                                                                        .Include(vehicle => vehicle.DriverVehicles)
                                                                        .Include(vehicle => vehicle.Enterprise)
                                                                        .Include(vehicle => vehicle.Enterprise!.ManagerLinks);

}