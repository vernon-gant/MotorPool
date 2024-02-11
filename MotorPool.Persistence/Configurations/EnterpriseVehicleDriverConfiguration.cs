using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MotorPool.Domain;

namespace MotorPool.Persistence.Configurations;

public class EnterpriseVehicleDriverConfiguration : IEntityTypeConfiguration<EnterpriseVehicleDriver>
{

    public void Configure(EntityTypeBuilder<EnterpriseVehicleDriver> builder)
    {
        builder.Property(enterpriseVehicleDriver => enterpriseVehicleDriver.AssignedOn).HasColumnType("datetime2").HasDefaultValueSql("getutcdate()");

        builder.HasOne(enterpriseVehicleDriver => enterpriseVehicleDriver.EnterpriseDriver)
               .WithMany(enterpriseDriver => enterpriseDriver.EnterpriseVehicleLinks)
               .HasForeignKey(vehicleDriver => vehicleDriver.EnterpriseDriverId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(enterpriseVehicleDriver => enterpriseVehicleDriver.EnterpriseVehicle)
               .WithMany(enterpriseVehicle => enterpriseVehicle.EnterpriseDriverLinks)
               .HasForeignKey(vehicleDriver => vehicleDriver.EnterpriseVehicleId)
               .OnDelete(DeleteBehavior.Restrict);
    }

}