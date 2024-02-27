using AutoMapper;

using Microsoft.EntityFrameworkCore;

using MotorPool.Domain;
using MotorPool.Persistence;
using MotorPool.Services.VehicleBrand.Models;
using MotorPool.Services.VehicleBrand.Services;
using MotorPool.Services.Vehicles.Exceptions;
using MotorPool.Services.Vehicles.Models;

namespace MotorPool.Services.Vehicles.Services.Concrete;

public class DefaultVehicleActionService(AppDbContext dbContext, IMapper mapper, VehicleBrandService vehicleBrandService) : VehicleActionService
{

    public async ValueTask<VehicleViewModel> CreateAsync(VehicleDTO vehicleDto)
    {
        await EnsureVehicleBrandExistsAsync(vehicleDto.VehicleBrandId);

        Vehicle newVehicle = mapper.Map<Vehicle>(vehicleDto);

        await dbContext.Vehicles.AddAsync(newVehicle);

        await dbContext.SaveChangesAsync();

        return mapper.Map<VehicleViewModel>(newVehicle);
    }

    public async ValueTask UpdateAsync(VehicleDTO vehicleDto)
    {
        await EnsureVehicleBrandExistsAsync(vehicleDto.VehicleBrandId);

        Vehicle oldVehicle = await dbContext.Vehicles.FirstAsync(vehicle => vehicle.VehicleId == vehicleDto.VehicleId);

        mapper.Map(vehicleDto, oldVehicle);

        dbContext.Update(oldVehicle);

        await dbContext.SaveChangesAsync();
    }

    public async ValueTask DeleteAsync(int vehicleId)
    {
        Vehicle vehicle = await dbContext.Vehicles.FirstAsync(vehicle => vehicle.VehicleId == vehicleId);

        dbContext.Vehicles.Remove(vehicle);

        await dbContext.SaveChangesAsync();
    }

    private async Task EnsureVehicleBrandExistsAsync(int vehicleBrandId)
    {
        VehicleBrandViewModel? vehicleBrand = await vehicleBrandService.GetByIdAsync(vehicleBrandId);

        if (vehicleBrand == null) throw new VehicleBrandNotFoundException("Vehicle brand not found");
    }

}