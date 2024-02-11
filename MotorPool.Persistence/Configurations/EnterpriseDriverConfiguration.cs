using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MotorPool.Domain;

namespace MotorPool.Persistence.Configurations;

public class EnterpriseDriverConfiguration : IEntityTypeConfiguration<EnterpriseDriver>
{

    public void Configure(EntityTypeBuilder<EnterpriseDriver> builder)
    {
        builder.HasIndex(enterpriseDriver => enterpriseDriver.DriverId).IsUnique();
        builder.Property(enterpriseDriver => enterpriseDriver.HiredOn).HasColumnType("datetime2").HasDefaultValueSql("getutcdate()");

        builder.HasOne(enterpriseDriver => enterpriseDriver.Enterprise)
               .WithMany(enterprise => enterprise.Drivers)
               .HasForeignKey(enterpriseDriver => enterpriseDriver.EnterpriseId);

        builder.HasOne(enterpriseDriver => enterpriseDriver.Driver)
               .WithOne(driver => driver.EnterpriseLink)
               .HasForeignKey((EnterpriseDriver enterpriseDriver) => enterpriseDriver.DriverId);
    }

}