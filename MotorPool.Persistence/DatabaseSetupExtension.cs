using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MotorPool.Persistence;

public static class DatabaseSetupExtension
{

    public static async Task SetupDatabaseAsync(this IHost webHost)
    {
        using var freshScope = webHost.Services.CreateScope();
        var appDbContext = freshScope.ServiceProvider.GetRequiredService<AppDbContext>();
        var loggerFactory = freshScope.ServiceProvider.GetRequiredService<ILoggerFactory>();
        var logger = loggerFactory.CreateLogger("test");

        try
        {
            logger.LogInformation("Migrating the database...");
            await appDbContext.Database.MigrateAsync();
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error while migrating the database...");

            throw;
        }
    }

}