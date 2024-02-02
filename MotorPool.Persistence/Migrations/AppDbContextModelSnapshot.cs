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

                    b.Property<decimal>("Mileage")
                        .HasPrecision(13, 3)
                        .HasColumnType("decimal(13,3)");

                    b.Property<string>("MotorVIN")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.Property<int>("VehicleBrandId")
                        .HasColumnType("int");

                    b.HasKey("VehicleId");

                    b.HasIndex("MotorVIN")
                        .IsUnique();

                    b.HasIndex("VehicleBrandId");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            VehicleId = 1,
                            Cost = 20000m,
                            ManufactureLand = "Japan",
                            ManufactureYear = 2020,
                            Mileage = 15000m,
                            MotorVIN = "1HGBH41JXMN109186",
                            VehicleBrandId = 1
                        },
                        new
                        {
                            VehicleId = 2,
                            Cost = 100000m,
                            ManufactureLand = "Sweden",
                            ManufactureYear = 2019,
                            Mileage = 50000m,
                            MotorVIN = "2VOLVOB7R0MN10918",
                            VehicleBrandId = 2
                        },
                        new
                        {
                            VehicleId = 3,
                            Cost = 120000m,
                            ManufactureLand = "Sweden",
                            ManufactureYear = 2018,
                            Mileage = 20000m,
                            MotorVIN = "3SCANPSE0MN109187",
                            VehicleBrandId = 3
                        },
                        new
                        {
                            VehicleId = 4,
                            Cost = 110000m,
                            ManufactureLand = "Germany",
                            ManufactureYear = 2021,
                            Mileage = 30000m,
                            MotorVIN = "4MBNZCTR0MN109186",
                            VehicleBrandId = 4
                        },
                        new
                        {
                            VehicleId = 5,
                            Cost = 30000m,
                            ManufactureLand = "USA",
                            ManufactureYear = 2022,
                            Mileage = 10000m,
                            MotorVIN = "5FORDTRN0MN109185",
                            VehicleBrandId = 5
                        },
                        new
                        {
                            VehicleId = 6,
                            Cost = 22000m,
                            ManufactureLand = "Japan",
                            ManufactureYear = 2020,
                            Mileage = 12000m,
                            MotorVIN = "6HGBH41JXMN209186",
                            VehicleBrandId = 1
                        },
                        new
                        {
                            VehicleId = 7,
                            Cost = 105000m,
                            ManufactureLand = "Sweden",
                            ManufactureYear = 2019,
                            Mileage = 55000m,
                            MotorVIN = "7VOLVOB7R1MN20918",
                            VehicleBrandId = 2
                        },
                        new
                        {
                            VehicleId = 8,
                            Cost = 125000m,
                            ManufactureLand = "Sweden",
                            ManufactureYear = 2018,
                            Mileage = 22000m,
                            MotorVIN = "8SCANPSE1MN209187",
                            VehicleBrandId = 3
                        },
                        new
                        {
                            VehicleId = 9,
                            Cost = 115000m,
                            ManufactureLand = "Germany",
                            ManufactureYear = 2021,
                            Mileage = 32000m,
                            MotorVIN = "9MBNZCTR1MN209186",
                            VehicleBrandId = 4
                        },
                        new
                        {
                            VehicleId = 10,
                            Cost = 32000m,
                            ManufactureLand = "USA",
                            ManufactureYear = 2022,
                            Mileage = 11000m,
                            MotorVIN = "0FORDTRN1MN209185",
                            VehicleBrandId = 5
                        });
                });

            modelBuilder.Entity("MotorPool.Domain.VehicleBrand", b =>
                {
                    b.Property<int>("VehicleBrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleBrandId"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("FuelTankCapacityLiters")
                        .HasPrecision(10, 4)
                        .HasColumnType("decimal(10,4)");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<decimal>("PayloadCapacityKg")
                        .HasPrecision(11, 5)
                        .HasColumnType("decimal(11,5)");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VehicleBrandId");

                    b.ToTable("VehicleBrands");

                    b.HasData(
                        new
                        {
                            VehicleBrandId = 1,
                            CompanyName = "Toyota",
                            FuelTankCapacityLiters = 50m,
                            ModelName = "Corolla",
                            NumberOfSeats = 5,
                            PayloadCapacityKg = 450m,
                            ReleaseYear = 2020,
                            Type = "PassengerCar"
                        },
                        new
                        {
                            VehicleBrandId = 2,
                            CompanyName = "Volvo",
                            FuelTankCapacityLiters = 300m,
                            ModelName = "B7R",
                            NumberOfSeats = 50,
                            PayloadCapacityKg = 7500m,
                            ReleaseYear = 2019,
                            Type = "Bus"
                        },
                        new
                        {
                            VehicleBrandId = 3,
                            CompanyName = "Scania",
                            FuelTankCapacityLiters = 400m,
                            ModelName = "P Series",
                            NumberOfSeats = 3,
                            PayloadCapacityKg = 15000m,
                            ReleaseYear = 2018,
                            Type = "Truck"
                        },
                        new
                        {
                            VehicleBrandId = 4,
                            CompanyName = "Mercedes-Benz",
                            FuelTankCapacityLiters = 275m,
                            ModelName = "Citaro",
                            NumberOfSeats = 45,
                            PayloadCapacityKg = 18000m,
                            ReleaseYear = 2021,
                            Type = "Bus"
                        },
                        new
                        {
                            VehicleBrandId = 5,
                            CompanyName = "Ford",
                            FuelTankCapacityLiters = 80m,
                            ModelName = "Transit",
                            NumberOfSeats = 3,
                            PayloadCapacityKg = 1200m,
                            ReleaseYear = 2022,
                            Type = "Truck"
                        });
                });

            modelBuilder.Entity("MotorPool.Domain.Vehicle", b =>
                {
                    b.HasOne("MotorPool.Domain.VehicleBrand", "VehicleBrand")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VehicleBrand");
                });

            modelBuilder.Entity("MotorPool.Domain.VehicleBrand", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
