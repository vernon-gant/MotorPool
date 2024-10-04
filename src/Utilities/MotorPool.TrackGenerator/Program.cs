using CommandLine;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using MotorPool.Persistence;
using MotorPool.TrackGenerator;

ConfigurationBuilder configurationBuilder = new ();
configurationBuilder.AddUserSecrets<Program>();
IConfigurationRoot configuration = configurationBuilder.Build();

ParserResult<TrackOptions> parsedResult = Parser.Default.ParseArguments<TrackOptions>(args);

if (parsedResult.Errors.Any())
{
    foreach (Error error in parsedResult.Errors) Console.WriteLine(error);

    return;
}

const string connectionString = "Server=localhost,1433;Database=motorpool;User Id=sa;Password=SuperSecret123321;Encrypt=Yes;TrustServerCertificate=Yes;Trusted_Connection=False;";

AppDbContext dbContext = new (new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(connectionString).Options);

TrackOptions options = parsedResult.Value;

if (dbContext.Vehicles.Find(options.VehicleId) is null)
{
    Console.WriteLine($"Vehicle with ID {options.VehicleId} does not exist.");

    return;
}

string graphHopperApiKey = configuration["GraphHopper:APIKey"] ?? throw new InvalidOperationException("GraphHopper API key is missing.");

GraphHopperClient graphHopperClient = new (graphHopperApiKey);

GraphHopperResponse response = graphHopperClient.GetTrack(options.StartPoint, options.EndPoint);

Track track = Track.FromGraphHopperResponseWithOptions(response, options);

new TrackGenerator(dbContext, track).Generate();

internal partial class Program { }