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

    public async ValueTask<List<VehicleViewModel>> GetAllAsync(VehicleQueryOptions? queryOptions)
    {
        IQueryable<Vehicle> allVehiclesQuery = VehicleQueryBase().WithQueryOptions(queryOptions);

        return await allVehiclesQuery.Select(vehicle => mapper.Map<VehicleViewModel>(vehicle)).ToListAsync();
    }

    public async ValueTask<PagedViewModel<VehicleViewModel>> GetAllAsync(PageOptions pageOptions, VehicleQueryOptions? queryOptions)
    {
        IQueryable<Vehicle> allVehiclesQuery = VehicleQueryBase().WithQueryOptions(queryOptions);

        List<VehicleViewModel> pagedVehicleModels = await allVehiclesQuery
                                                          .Page(pageOptions)
                                                          .Select(vehicle => mapper.Map<VehicleViewModel>(vehicle))
                                                          .ToListAsync();

        int allVehiclesQueryCount = await allVehiclesQuery.CountAsync();

        return PagedViewModel<VehicleViewModel>.FromOptionsAndElements(pageOptions, pagedVehicleModels, allVehiclesQueryCount);
    }

    public async ValueTask<VehicleViewModel?> GetByIdAsync(int vehicleId)
    {
        Vehicle? foundVehicle = await VehicleQueryBase().FirstOrDefaultAsync(vehicle => vehicle.VehicleId == vehicleId);

        return mapper.Map<VehicleViewModel>(foundVehicle);
    }

    private IQueryable<Vehicle> VehicleQueryBase() => dbContext.Vehicles
                                                                        .AsNoTracking()
                                                                        .Include(vehicle => vehicle.VehicleBrand)
                                                                        .Include(vehicle => vehicle.DriverVehicles)
                                                                        .Include(vehicle => vehicle.Enterprise)
                                                                        .Include(vehicle => vehicle.Enterprise!.ManagerLinks);

}