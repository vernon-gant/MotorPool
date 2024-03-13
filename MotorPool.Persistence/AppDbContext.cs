﻿using System.Reflection;

using Microsoft.EntityFrameworkCore;

using MotorPool.Domain;

namespace MotorPool.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{

    public DbSet<Vehicle> Vehicles { get; set; }

    public DbSet<VehicleBrand> VehicleBrands { get; set; }

    public DbSet<Driver> Drivers { get; set; }

    public DbSet<Enterprise> Enterprises { get; set; }

    public DbSet<Manager> Managers { get; set; }

    public DbSet<EnterpriseManager> EnterpriseManagers { get; set; }

    public DbSet<GeoPoint> GeoPoints { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<VehicleBrand>().HasData(SeedingData.VehicleBrands);

        modelBuilder.Entity<Enterprise>().HasData(SeedingData.Enterprises);

        modelBuilder.Entity<Manager>().HasData(SeedingData.Managers);

        modelBuilder.Entity<EnterpriseManager>().HasData(SeedingData.EnterpriseManagers);

        modelBuilder.Entity<GeoPoint>().HasData(SeedingData.GeoPoints);
    }

}