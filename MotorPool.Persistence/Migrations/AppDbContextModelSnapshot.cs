﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MotorPool.Persistence;

#nullable disable

namespace MotorPool.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MotorPool.Domain.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleId"));

                    b.Property<decimal>("Cost")
                        .HasPrecision(15, 5)
                        .HasColumnType("decimal(15,5)");

                    b.Property<string>("ManufactureLand")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ManufactureYear")
                        .HasColumnType("int");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Mileage")
                        .HasPrecision(13, 3)
                        .HasColumnType("decimal(13,3)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("VIN")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.HasKey("VehicleId");

                    b.HasIndex("Manufacturer");

                    b.HasIndex("VIN")
                        .IsUnique();

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            VehicleId = 1,
                            Cost = 20000m,
                            ManufactureLand = "Japan",
                            ManufactureYear = 2020,
                            Manufacturer = "Toyota",
                            Mileage = 15000m,
                            Model = "Corolla",
                            VIN = "1HGBH41JXMN109186"
                        },
                        new
                        {
                            VehicleId = 2,
                            Cost = 18000m,
                            ManufactureLand = "Japan",
                            ManufactureYear = 2019,
                            Manufacturer = "Honda",
                            Mileage = 20000m,
                            Model = "Civic",
                            VIN = "2HGBH41JXMN109187"
                        },
                        new
                        {
                            VehicleId = 3,
                            Cost = 17000m,
                            ManufactureLand = "USA",
                            ManufactureYear = 2018,
                            Manufacturer = "Ford",
                            Mileage = 25000m,
                            Model = "Focus",
                            VIN = "3CZRE4H56BG704113"
                        },
                        new
                        {
                            VehicleId = 4,
                            Cost = 22000m,
                            ManufactureLand = "USA",
                            ManufactureYear = 2021,
                            Manufacturer = "Chevrolet",
                            Mileage = 10000m,
                            Model = "Impala",
                            VIN = "1HGCM82633A004352"
                        },
                        new
                        {
                            VehicleId = 5,
                            Cost = 24000m,
                            ManufactureLand = "Japan",
                            ManufactureYear = 2022,
                            Manufacturer = "Nissan",
                            Mileage = 5000m,
                            Model = "Altima",
                            VIN = "19XFB2F59CE308872"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
