using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MotorPool.Domain;

namespace MotorPool.Persistence.Configurations;

public class EnterpriseVehicleConfiguration : IEntityTypeConfiguration<EnterpriseVehicle>
{

    public void Configure(EntityTypeBuilder<EnterpriseVehicle> builder)
    {
        builder.HasIndex(enterpriseVehicle => enterpriseVehicle.VehicleId).IsUnique();
        builder.Property(enterpriseVehicle => enterpriseVehicle.AcquiredOn).HasColumnType("datetime2").HasDefaultValueSql("getutcdate()");

        builder.HasOne(enterpriseVehicle => enterpriseVehicle.Enterprise)
               .WithMany(enterprise => enterprise.Vehicles)
               .HasForeignKey(enterpriseVehicle => enterpriseVehicle.EnterpriseId);

        builder.HasOne(enterpriseVehicle => enterpriseVehicle.Vehicle)
               .WithOne(vehicle => vehicle.EnterpriseLink)
               .HasForeignKey((EnterpriseVehicle enterpriseVehicle) => enterpriseVehicle.VehicleId);
    }

}