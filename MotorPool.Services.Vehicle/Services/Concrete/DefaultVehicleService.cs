using AutoMapper;

using Microsoft.EntityFrameworkCore;

using MotorPool.Domain;
using MotorPool.Persistence;
using MotorPool.Services.Vehicles.Exceptions;
using MotorPool.Services.Vehicles.Models;

namespace MotorPool.Services.Vehicles.Services.Concrete;

public class DefaultVehicleService(AppDbContext dbContext, IMapper mapper) : VehicleService
{

    public async ValueTask<VehicleViewModel> CreateAsync(VehicleDTO vehicleDto)
    {
        if (await dbContext.VehicleBrands.FindAsync(vehicleDto.VehicleBrandId) == null) throw new VehicleBrandNotFoundException("Vehicle brand not found");

        Vehicle newVehicle = mapper.Map<Vehicle>(vehicleDto);

        await dbContext.Vehicles.AddAsync(newVehicle);

        await dbContext.SaveChangesAsync();

        return mapper.Map<VehicleViewModel>(newVehicle);
    }

    public async ValueTask<VehicleViewModel?> GetById(int vehicleId)
    {
        var foundVehicle = await dbContext.Vehicles
                                          .Include(vehicle => vehicle.VehicleBrand)
                                          .Include(vehicle => vehicle.Enterprise)
                                          .Include(vehicle => vehicle.Enterprise!.ManagerLinks)
                                          .Include(vehicle => vehicle.DriverVehicles)
                                          .FirstOrDefaultAsync(m => m.VehicleId == vehicleId);

        return mapper.Map<VehicleViewModel>(foundVehicle);
    }

    public async ValueTask EditAsync(VehicleDTO vehicleDto)
    {
        var oldVehicle = await dbContext.Vehicles.FirstAsync(vehicle => vehicle.VehicleId == vehicleDto.VehicleId);

        mapper.Map(vehicleDto, oldVehicle);

        dbContext.Update(oldVehicle);

        await dbContext.SaveChangesAsync();
    }

    public async ValueTask DeleteAsync(int vehicleId)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<List<VehicleViewModel>> GetAllAsync()
    {
        var rawVehicles = await dbContext.Vehicles
                                         .AsNoTracking()
                                         .Include(vehicle => vehicle.VehicleBrand)
                                         .Include(vehicle => vehicle.DriverVehicles)
                                         .ToListAsync();

        return mapper.Map<List<VehicleViewModel>>(rawVehicles);
    }

    public async ValueTask<List<VehicleViewModel>> GetAllByManagerIdAsync(int managerId)
    {
        var rawVehicles = await dbContext.Vehicles
                                         .AsNoTracking()
                                         .Include(vehicle => vehicle.VehicleBrand)
                                         .Include(vehicle => vehicle.DriverVehicles)
                                         .Include(vehicle => vehicle.Enterprise)
                                         .Include(vehicle => vehicle.Enterprise!.ManagerLinks)
                                         .Where(vehicle => vehicle.Enterprise != null)
                                         .Where(vehicle => vehicle.Enterprise!.ManagerLinks.Any(manager => manager.ManagerId == managerId))
                                         .ToListAsync();

        return mapper.Map<List<VehicleViewModel>>(rawVehicles);
    }

}