using CommandLine;

namespace MotorPool.DatabaseSeeder;

public class SeedingOptions
{

    [Option('e', "enterprise-ids", Required = true, HelpText = "The ids of the enterprises where vehicles and drivers will be seeded.")]
    public IEnumerable<int> EnterpriseIds { get; set; } = Enumerable.Empty<int>();

    [Option('v', "vehicles-per-enterprise", Required = true, HelpText = "The number of vehicles to seed per enterprise.")]
    public int VehiclesPerEnterprise { get; set; }

    [Option('d', "drivers-per-enterprise", Required = true, HelpText = "The number of drivers to seed per enterprise.")]
    public int DriversPerEnterprise { get; set; }

}