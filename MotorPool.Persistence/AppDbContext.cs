using System.Reflection;

using Microsoft.EntityFrameworkCore;

using MotorPool.Domain;

namespace MotorPool.Persistence;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{

    public DbSet<Vehicle> Vehicles { get; set; }

    public DbSet<VehicleBrand> VehicleBrands { get; set; }

    public DbSet<Driver> Drivers { get; set; }

    public DbSet<Enterprise> Enterprises { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<VehicleBrand>().HasData(SeedingData.VehicleBrands);

        modelBuilder.Entity<Enterprise>().HasData(SeedingData.Enterprises);

        modelBuilder.Entity<Vehicle>().HasData(SeedingData.Vehicles);

        modelBuilder.Entity<Driver>().HasData(SeedingData.Drivers);

        modelBuilder.Entity<DriverVehicle>().HasData(SeedingData.GenerateDriverVehicleAssignments());
    }

}