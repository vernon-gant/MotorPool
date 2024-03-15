using CommandLine;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using MotorPool.Persistence;
using MotorPool.TrackGenerator;

ConfigurationBuilder configurationBuilder = new ();
configurationBuilder.AddUserSecrets<Program>();
IConfigurationRoot configuration = configurationBuilder.Build();
string graphHopperApiKey = configuration["GraphHopper:APIKey"] ?? throw new InvalidOperationException("GraphHopper API key is missing.");

ParserResult<TrackOptions> parsedResult = Parser.Default.ParseArguments<TrackOptions>(args);

if (parsedResult.Errors.Any())
{
    foreach (Error error in parsedResult.Errors) Console.WriteLine(error);
    return;
}


TrackOptions options = parsedResult.Value;

Console.WriteLine($"Start: {options.StartPoint.Latitude}, {options.StartPoint.Longitude}");

const string connectionString = "Server=localhost,1433;Database=motorpool;User Id=sa;Password=SuperSecret123321;Encrypt=Yes;TrustServerCertificate=Yes;Trusted_Connection=False;";

AppDbContext dbContext = new (new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(connectionString).Options);

internal partial class Program {}