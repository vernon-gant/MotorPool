using CommandLine;

using Microsoft.EntityFrameworkCore;

using MotorPool.DatabaseSeeder;
using MotorPool.Persistence;

ParserResult<SeedingOptions> parsedResult = Parser.Default.ParseArguments<SeedingOptions>(args);

if (parsedResult.Errors.Any())
{
    Console.WriteLine("Invalid arguments. Please provide the enterprise ids, the number of vehicles and drivers per enterprise.");
    foreach (Error error in parsedResult.Errors) Console.WriteLine(error);
    return;
}

SeedingOptions options = parsedResult.Value;

if (options.DriversPerEnterprise < 1 || options.VehiclesPerEnterprise < 1)
{
    Console.WriteLine("Invalid arguments. The number of vehicles and drivers per enterprise must be greater than 0.");
    return;
}

const string connectionString = "Server=localhost,1433;Database=motorpool;User Id=sa;Password=SuperSecret123321;Encrypt=Yes;TrustServerCertificate=Yes;Trusted_Connection=False;";

AppDbContext dbContext = new (new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(connectionString).Options);

MotorPoolRandomizer randomizer = new PseudoMotorPoolRandomizer();

VehicleDriversGenerator dataGenerator = new RandomVehicleDriversGenerator(randomizer);

RelationsGenerator relationsGenerator = new RandomRelationsGenerator(randomizer);

new DatabaseSeeder(dataGenerator, relationsGenerator, dbContext).Seed(parsedResult.Value);