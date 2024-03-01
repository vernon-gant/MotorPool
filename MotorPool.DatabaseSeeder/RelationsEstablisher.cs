using MotorPool.Domain;

namespace MotorPool.DatabaseSeeder;

public interface RelationsEstablisher
{

    void AddDriversToVehicles(List<Driver> drivers, List<Vehicle> vehicles);

    void AddActiveDriversToVehicles(List<Driver> drivers, List<Vehicle> vehicles, List<DriverVehicle> driverVehicles);

}

public class RandomRelationsEstablisher(MotorPoolRandomizer randomizer) : RelationsEstablisher
{

    public void AddDriversToVehicles(List<Driver> drivers, List<Vehicle> vehicles)
    {
        foreach (Vehicle sampleVehicle in randomizer.GetSample(vehicles))
        {
            foreach (Driver sampleDriver in randomizer.GetSample(drivers))
            {
                DriverVehicle
            }
        }
    }

    public void AddActiveDriversToVehicles(List<Driver> drivers, List<Vehicle> vehicles, List<DriverVehicle> driverVehicles)
    {
        throw new NotImplementedException();
    }

}