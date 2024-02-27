using AutoMapper;

using Microsoft.EntityFrameworkCore;

using MotorPool.Persistence;
using MotorPool.Services.Vehicles.Models;

namespace MotorPool.Services.Vehicles.Services.Concrete;

public class DefaultVehicleQueryService(AppDbContext dbContext, IMapper mapper) : VehicleQueryService
{

    public async ValueTask<List<VehicleViewModel>> GetAllAsync()
    {
        var rawVehicles = await dbContext.Vehicles
                                         .AsNoTracking()
                                         .Include(vehicle => vehicle.VehicleBrand)
                                         .Include(vehicle => vehicle.DriverVehicles)
                                         .Include(vehicle => vehicle.Enterprise)
                                         .Include(vehicle => vehicle.Enterprise!.ManagerLinks)
                                         .ToListAsync();

        return mapper.Map<List<VehicleViewModel>>(rawVehicles);
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