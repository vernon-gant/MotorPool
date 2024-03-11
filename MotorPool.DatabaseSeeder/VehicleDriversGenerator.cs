using Bogus;

using MotorPool.Domain;

namespace MotorPool.DatabaseSeeder;

public interface VehicleDriversGenerator
{

    List<Vehicle> GenerateVehicles(int count, int enterpriseId, List<int> vehicleBrandIds);

    List<Driver> GenerateDrivers(int count, int enterpriseId);

}

public class RandomVehicleDriversGenerator(MotorPoolRandomizer randomizer) : VehicleDriversGenerator
{
    private static readonly Faker _faker = new ();

    public List<Vehicle> GenerateVehicles(int count, int enterpriseId, List<int> vehicleBrandIds)
    {
        List<Vehicle> vehicles = new ();

        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine($"Generating {count} vehicles for enterprise {enterpriseId}...\n");

        for (int i = 0; i < count; i++)
        {
            Vehicle vehicle = new Vehicle
            {
                MotorVIN = randomizer.MotorVIN(),
                Cost = randomizer.FromRange(1, 10000),
                ManufactureYear = randomizer.FromRange(1990, DateTime.Now.Year),
                ManufactureLand = _faker.Address.Country(),
                Mileage = randomizer.FromRange(0, 1000000),
                EnterpriseId = enterpriseId,
                VehicleBrandId = vehicleBrandIds[randomizer.FromRange(0, vehicleBrandIds.Count - 1)],
                AcquiredOn = _faker.Date.Between(new DateTime(2005,1,1),DateTime.Now)
            };
            vehicles.Add(vehicle);
        }

        Console.WriteLine("\nVehicles generated successfully!");
        Console.WriteLine("-".PadRight(50, '-') + "\n\n");

        return vehicles;
    }

    public List<Driver> GenerateDrivers(int count, int enterpriseId)
    {
        List<Driver> drivers = new ();

        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine($"Generating {count} drivers for enterprise {enterpriseId}...\n");

        for (int i = 0; i < count; i++)
        {
            Driver driver = new ()
            {
                FirstName = _faker.Name.FirstName(),
                LastName = _faker.Name.LastName(),
                Salary = randomizer.FromRange(1000, 10000),
                EnterpriseId = enterpriseId
            };
            drivers.Add(driver);
        }

        Console.WriteLine("\nDrivers generated successfully!");
        Console.WriteLine("-".PadRight(50, '-') + "\n\n");

        return drivers;
    }

}