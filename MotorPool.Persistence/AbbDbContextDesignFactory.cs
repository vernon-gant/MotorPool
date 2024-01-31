using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MotorPool.Persistence;

public class AbbDbContextDesignFactory : IDesignTimeDbContextFactory<AppDbContext>
{

    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        optionsBuilder.UseSqlServer(
            "Server=localhost,1433;Database=motorpool;User Id=sa;Password=SuperSecret123321;Encrypt=Yes;TrustServerCertificate=Yes;Trusted_Connection=False;");

        return new AppDbContext(optionsBuilder.Options);
    }

}