using MotorPool.Domain;

namespace MotorPool.DatabaseSeeder;

public interface RelationsGenerator
{

    void BetweenVehiclesAndDrivers(List<Driver> drivers, List<Vehicle> vehicles);

    void AddActiveDrivers(List<Vehicle> vehicles, List<Driver> drivers);

}

public class RandomRelationsGenerator(MotorPoolRandomizer randomizer) : RelationsGenerator
{

    public void BetweenVehiclesAndDrivers(List<Driver> drivers, List<Vehicle> vehicles)
    {
        Console.WriteLine("-".PadRight(50, '-'));
        Console.WriteLine("Generating relations between vehicles and drivers...\n");

        foreach (Vehicle vehicle in randomizer.GetSample(vehicles))
        {
            foreach (Driver driver in randomizer.GetSample(drivers))
            {
                Console.WriteLine($"Added relation between vehicle {vehicle.MotorVIN} and driver {driver.FirstName} {driver.LastName}");

                DriverVehicle newRelation = new ()
                {
                    VehicleId = vehicle.VehicleId,
                    DriverId = driver.DriverId
                };
                vehicle.DriverVehicles.Add(newRelation);
                driver.DriverVehicles.Add(newRelation);
            }
        }

        Console.WriteLine("\nRelations between vehicles and drivers generated successfully!");
        Console.WriteLine("-".PadRight(50, '-') + "\n\n");
    }

    public void AddActiveDrivers(List<Vehicle> vehicles, List<Driver> drivers)
    {
        const double VEHICLE_WITH_ACTIVE_DRIVER_PROBABILITY = 0.12;

        List<Vehicle> vehiclesWithDrivers = vehicles.Where(vehicle => vehicle.DriverVehicles.Count != 0).ToList();
        HashSet<Driver> activeDrivers = new ();

        Console.WriteLine("-".PadRight(50, '-'));
        Console.WriteLine("Adding active drivers to vehicles...\n");

        foreach (Vehicle vehicle in randomizer.GetSample(vehiclesWithDrivers, VEHICLE_WITH_ACTIVE_DRIVER_PROBABILITY))
        {
            List<Driver> potentialActiveDrivers = drivers
                                                  .Where(driver => driver.DriverVehicles.Any(driverVehicle => driverVehicle.VehicleId == vehicle.VehicleId) &&
                                                                   !activeDrivers.Contains(driver))
                                                  .ToList();
            Driver newActiveDriver = potentialActiveDrivers[randomizer.FromRange(0, potentialActiveDrivers.Count - 1)];
            activeDrivers.Add(newActiveDriver);
            newActiveDriver.ActiveVehicleId = vehicle.VehicleId;
            Console.WriteLine($"Added active driver {newActiveDriver.FirstName} {newActiveDriver.LastName} to vehicle {vehicle.MotorVIN}");
        }

        if (activeDrivers.Count == 0) Console.WriteLine("No active drivers added to vehicles.");

        Console.WriteLine("\nActive drivers added to vehicles successfully!");
        Console.WriteLine("-".PadRight(50, '-') + "\n\n");
    }

}