using AutoMapper;

using Microsoft.EntityFrameworkCore;

using MotorPool.Domain;
using MotorPool.Persistence;
using MotorPool.Services.VehicleBrand.Models;
using MotorPool.Services.VehicleBrand.Services;
using MotorPool.Services.Vehicles.Exceptions;
using MotorPool.Services.Vehicles.Models;

namespace MotorPool.Services.Vehicles.Services.Concrete;

public class DefaultVehicleActionService(AppDbContext dbContext, IMapper mapper, VehicleQueryService vehicleQueryService, VehicleBrandService vehicleBrandService) : VehicleActionService
{

    public async ValueTask<VehicleViewModel> CreateAsync(VehicleDTO vehicleDto)
    {
        await EnsureVehicleBrandExistsAsync(vehicleDto.VehicleBrandId);

        if (await VINExists(vehicleDto.MotorVIN)) throw new VINAlreadyExistsException("VIN already exists");

        Vehicle newVehicle = mapper.Map<Vehicle>(vehicleDto);

        await dbContext.Vehicles.AddAsync(newVehicle);

        await dbContext.SaveChangesAsync();

        return await vehicleQueryService.GetByIdAsync(newVehicle.VehicleId)!;
    }

    private async ValueTask<bool> VINExists(string VIN) => await dbContext.Vehicles.AnyAsync(vehicle => vehicle.MotorVIN == VIN);

    public async ValueTask UpdateAsync(VehicleViewModel vehicleViewModel)
    {
        await EnsureVehicleBrandExistsAsync(vehicleViewModel.VehicleBrandId);

        dbContext.Vehicles.Update(mapper.Map<Vehicle>(vehicleViewModel));

        await dbContext.SaveChangesAsync();
    }

    public async ValueTask DeleteAsync(int vehicleId)
    {
        Vehicle vehicle = await dbContext.Vehicles.FindAsync(vehicleId) ?? throw new VehicleNotFoundException("Vehicle not found");

        dbContext.Vehicles.Remove(vehicle);

        await dbContext.SaveChangesAsync();
    }

    private async Task EnsureVehicleBrandExistsAsync(int vehicleBrandId)
    {
        VehicleBrandViewModel? vehicleBrand = await vehicleBrandService.GetByIdAsync(vehicleBrandId);

        if (vehicleBrand == null) throw new VehicleBrandNotFoundException("Vehicle brand not found");
    }

}