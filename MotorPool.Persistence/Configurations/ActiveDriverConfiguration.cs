using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MotorPool.Domain;

namespace MotorPool.Persistence.Configurations;

public class ActiveDriverConfiguration : IEntityTypeConfiguration<ActiveDriver>
{

    public void Configure(EntityTypeBuilder<ActiveDriver> builder)
    {
        builder.Property(activeDriver => activeDriver.StartedOn).HasColumnType("datetime2").HasDefaultValueSql("getutcdate()");
        builder.Property(activeDriver => activeDriver.StoppedOn).HasColumnType("datetime2").HasDefaultValue(null);

        builder.HasOne(activeDriver => activeDriver.EnterpriseVehicleDriver)
               .WithOne(enterpriseVehicleDriver => enterpriseVehicleDriver.ActiveDriver)
               .HasForeignKey((ActiveDriver activeDriver) => activeDriver.EnterpriseVehicleDriverId);
    }

}