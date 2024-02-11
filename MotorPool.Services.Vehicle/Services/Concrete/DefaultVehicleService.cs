using AutoMapper;

using Microsoft.EntityFrameworkCore;

using MotorPool.Domain;
using MotorPool.Persistence;
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
        List<Vehicle> vehicles = await dbContext.Vehicles.Include(vehicle => vehicle.VehicleBrand).ToListAsync();

        return mapper.Map<List<VehicleViewModel>>(vehicles);
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

}