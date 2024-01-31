﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MotorPool.Domain;

namespace MotorPool.Persistence.Configurations;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{

    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.HasIndex(vehicle => vehicle.Manufacturer);
        builder.HasIndex(vehicle => vehicle.VIN).IsUnique();
        builder.Property(vehicle => vehicle.Mileage).HasPrecision(13, 3);
        builder.Property(vehicle => vehicle.Cost).HasPrecision(15, 5);
    }

}