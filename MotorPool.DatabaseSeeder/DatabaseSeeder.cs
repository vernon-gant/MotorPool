using MotorPool.Domain;
using MotorPool.Persistence;

namespace MotorPool.DatabaseSeeder;

public class DatabaseSeeder(VehicleDriversGenerator dataGenerator, RelationsGenerator relationsGenerator, AppDbContext dbContext)
{

    public void Seed(SeedingOptions options)
    {
        EnsureAllEnterprisesExist(options.EnterpriseIds.ToHashSet());
        List<int> vehicleBrandIds = GetVehicleBrandIds();

        foreach (int enterpriseId in options.EnterpriseIds)
        {
            Console.WriteLine("#".PadRight(50, '#'));
            Console.WriteLine($"Seeding enterprise with id {enterpriseId}...\n\n");
            List<Vehicle> vehicles = dataGenerator.GenerateVehicles(options.VehiclesPerEnterprise, enterpriseId, vehicleBrandIds);
            List<Driver> drivers = dataGenerator.GenerateDrivers(options.DriversPerEnterprise, enterpriseId);

            dbContext.Vehicles.AddRange(vehicles);
            dbContext.Drivers.AddRange(drivers);
            dbContext.SaveChanges();

            relationsGenerator.BetweenVehiclesAndDrivers(drivers, vehicles);
            relationsGenerator.AddActiveDrivers(vehicles, drivers);
            dbContext.SaveChanges();
            Console.WriteLine($"\n\nEnterprise with id {enterpriseId} seeded successfully!");
            Console.WriteLine("#".PadRight(50, '#'));
        }
    }

    private void EnsureAllEnterprisesExist(HashSet<int> inputEnterpriseIds)
    {
        HashSet<int> existingEnterprises = dbContext.Enterprises.Select(enterprise => enterprise.EnterpriseId).ToHashSet();
        HashSet<int> nonExistingEnterprises = inputEnterpriseIds.Except(existingEnterprises).ToHashSet();

        if (nonExistingEnterprises.Count == 0) return;

        Console.WriteLine("The following enterprise ids do not exist in the database:");
        foreach (int enterpriseId in nonExistingEnterprises) Console.WriteLine(enterpriseId);
        Console.WriteLine("Please provide valid enterprise ids.");

        throw new ArgumentException("Invalid enterprise ids provided.");
    }

    private List<int> GetVehicleBrandIds() => dbContext.VehicleBrands.Select(brand => brand.VehicleBrandId).ToList();

}