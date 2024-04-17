using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MotorPool.Domain;

namespace MotorPool.Persistence.Configurations;

public class TripConfiguration : IEntityTypeConfiguration<Trip>
{

    public void Configure(EntityTypeBuilder<Trip> builder)
    {
        builder.HasOne(trip => trip.Vehicle)
               .WithMany()
               .HasForeignKey(trip => trip.VehicleId)
               .OnDelete(DeleteBehavior.Cascade);
    }

}