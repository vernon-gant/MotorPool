using AutoMapper;

using Microsoft.EntityFrameworkCore;

using MotorPool.Domain;
using MotorPool.Persistence;
using MotorPool.Services.Vehicles.Models;
using MotorPool.Services.Vehicles.ViewModels;

namespace MotorPool.Services.Vehicles.Services.Concrete;

public class DefaultVehicleService(AppDbContext dbContext, IMapper mapper) : VehicleService
{

    public async Task EditVehicleAsync(VehicleDTO vehicleDto)
    {
        Vehicle oldVehicle = await dbContext.Vehicles
                                           .FirstAsync(vehicle => vehicle.VehicleId == vehicleDto.VehicleId);

        mapper.Map(vehicleDto, oldVehicle);

        dbContext.Update(oldVehicle);

        await dbContext.SaveChangesAsync();
    }

    public async ValueTask<List<VehicleViewModel>> GetAllAsync()
    {
        List<Vehicle> rawVehicles = await dbContext.Vehicles
                                                .AsNoTracking()
                                                .Include(vehicle => vehicle.VehicleBrand)
                                                .Include(vehicle => vehicle.DriverVehicles)
                                                .ToListAsync();

        return mapper.Map<List<VehicleViewModel>>(rawVehicles);
    }

    public async Task CreateVehicleAsync(VehicleDTO vehicleDto)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<VehicleViewModel?> GetVehicleById(int id)
    {
        Vehicle? foundVehicle = await dbContext.Vehicles
                                              .Include(vehicle => vehicle.VehicleBrand)
                                              .FirstOrDefaultAsync(m => m.VehicleId == id);

        return mapper.Map<VehicleViewModel>(foundVehicle);
    }

    public async ValueTask<List<VehicleViewModel>> GetByManagerAsync(int managerId)
    {
        List<Vehicle> rawVehicles = await dbContext.Vehicles
                                                .AsNoTracking()
                                                .Include(vehicle => vehicle.VehicleBrand)
                                                .Include(vehicle => vehicle.DriverVehicles)
                                                .Where(vehicle => vehicle.Enterprise != null)
                                                .Where(vehicle => vehicle.Enterprise!.ManagerLinks.Any(manager => manager.ManagerId == managerId))
                                                .ToListAsync();

        return mapper.Map<List<VehicleViewModel>>(rawVehicles);
    }

}