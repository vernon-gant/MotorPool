using MotorPool.Persistence;

namespace MotorPool.Repository.Vehicle;

using Vehicle = Domain.Vehicle;

public class EfCoreVehicleChangeRepository(AppDbContext dbContext) : VehicleChangeRepository
{
    public async ValueTask<Vehicle> CreateAsync(Vehicle newVehicle)
    {
        await dbContext.Vehicles.AddAsync(newVehicle);

        await dbContext.SaveChangesAsync();

        return newVehicle;
    }

    public async ValueTask DeleteAsync(int vehicleId)
    {
        Vehicle? vehicle = await dbContext.Vehicles.FindAsync(vehicleId);

        if (vehicle is null) return;

        dbContext.Vehicles.Remove(vehicle);

        await dbContext.SaveChangesAsync();
    }

    public async ValueTask UpdateAsync(Vehicle updatedVehicle)
    {
        bool foundVehicle = await dbContext.Vehicles.FindAsync(updatedVehicle.VehicleId) is not null;

        if (!foundVehicle) return;

        dbContext.Vehicles.Update(updatedVehicle);

        await dbContext.SaveChangesAsync();
    }
}