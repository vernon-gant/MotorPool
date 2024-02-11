using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MotorPool.Domain;

namespace MotorPool.Persistence.Configurations;

public class EnterpriseConfiguration : IEntityTypeConfiguration<Enterprise>
{

    public void Configure(EntityTypeBuilder<Enterprise> builder)
    {
        builder.Property(enterprise => enterprise.FoundedOn).HasColumnType("datetime2");
    }

}