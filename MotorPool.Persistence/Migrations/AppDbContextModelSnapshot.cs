﻿// <auto-generated />
using System;
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

            modelBuilder.Entity("MotorPool.Domain.Driver", b =>
                {
                    b.Property<int>("DriverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DriverId"));

                    b.Property<int?>("ActiveVehicleId")
                        .HasColumnType("int");

                    b.Property<int?>("EnterpriseId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Salary")
                        .HasPrecision(9, 3)
                        .HasColumnType("decimal(9,3)");

                    b.HasKey("DriverId");

                    b.HasIndex("ActiveVehicleId");

                    b.HasIndex("EnterpriseId");

                    b.ToTable("Drivers");

                    b.HasData(
                        new
                        {
                            DriverId = 1,
                            EnterpriseId = 1,
                            FirstName = "John",
                            LastName = "Doe",
                            Salary = 2000m
                        },
                        new
                        {
                            DriverId = 2,
                            EnterpriseId = 1,
                            FirstName = "Jane",
                            LastName = "Doe",
                            Salary = 2500m
                        },
                        new
                        {
                            DriverId = 3,
                            EnterpriseId = 1,
                            FirstName = "Jack",
                            LastName = "Doe",
                            Salary = 3000m
                        },
                        new
                        {
                            DriverId = 4,
                            EnterpriseId = 1,
                            FirstName = "Jill",
                            LastName = "Doe",
                            Salary = 3500m
                        },
                        new
                        {
                            DriverId = 5,
                            EnterpriseId = 2,
                            FirstName = "Jim",
                            LastName = "Doe",
                            Salary = 4000m
                        },
                        new
                        {
                            DriverId = 6,
                            EnterpriseId = 2,
                            FirstName = "Jenny",
                            LastName = "Doe",
                            Salary = 4500m
                        },
                        new
                        {
                            DriverId = 7,
                            EnterpriseId = 2,
                            FirstName = "Jasper",
                            LastName = "Doe",
                            Salary = 5000m
                        },
                        new
                        {
                            DriverId = 8,
                            EnterpriseId = 3,
                            FirstName = "Jasmine",
                            LastName = "Doe",
                            Salary = 5500m
                        },
                        new
                        {
                            DriverId = 9,
                            EnterpriseId = 3,
                            FirstName = "Jared",
                            LastName = "Doe",
                            Salary = 6000m
                        },
                        new
                        {
                            DriverId = 10,
                            FirstName = "Jocelyn",
                            LastName = "Doe",
                            Salary = 6500m
                        });
                });

            modelBuilder.Entity("MotorPool.Domain.DriverVehicle", b =>
                {
                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("DriverId", "VehicleId");

                    b.HasIndex("VehicleId");

                    b.ToTable("DriverVehicle");

                    b.HasData(
                        new
                        {
                            DriverId = 4,
                            VehicleId = 1
                        },
                        new
                        {
                            DriverId = 1,
                            VehicleId = 1
                        },
                        new
                        {
                            DriverId = 3,
                            VehicleId = 1
                        },
                        new
                        {
                            DriverId = 4,
                            VehicleId = 2
                        },
                        new
                        {
                            DriverId = 1,
                            VehicleId = 2
                        },
                        new
                        {
                            DriverId = 2,
                            VehicleId = 2
                        },
                        new
                        {
                            DriverId = 3,
                            VehicleId = 3
                        },
                        new
                        {
                            DriverId = 4,
                            VehicleId = 3
                        },
                        new
                        {
                            DriverId = 1,
                            VehicleId = 3
                        },
                        new
                        {
                            DriverId = 3,
                            VehicleId = 4
                        },
                        new
                        {
                            DriverId = 1,
                            VehicleId = 4
                        },
                        new
                        {
                            DriverId = 4,
                            VehicleId = 4
                        },
                        new
                        {
                            DriverId = 2,
                            VehicleId = 5
                        },
                        new
                        {
                            DriverId = 1,
                            VehicleId = 5
                        },
                        new
                        {
                            DriverId = 4,
                            VehicleId = 5
                        },
                        new
                        {
                            DriverId = 5,
                            VehicleId = 6
                        },
                        new
                        {
                            DriverId = 6,
                            VehicleId = 6
                        },
                        new
                        {
                            DriverId = 7,
                            VehicleId = 6
                        },
                        new
                        {
                            DriverId = 5,
                            VehicleId = 7
                        },
                        new
                        {
                            DriverId = 7,
                            VehicleId = 7
                        },
                        new
                        {
                            DriverId = 6,
                            VehicleId = 7
                        },
                        new
                        {
                            DriverId = 7,
                            VehicleId = 8
                        },
                        new
                        {
                            DriverId = 5,
                            VehicleId = 8
                        },
                        new
                        {
                            DriverId = 6,
                            VehicleId = 8
                        },
                        new
                        {
                            DriverId = 6,
                            VehicleId = 9
                        },
                        new
                        {
                            DriverId = 5,
                            VehicleId = 9
                        },
                        new
                        {
                            DriverId = 7,
                            VehicleId = 9
                        },
                        new
                        {
                            DriverId = 9,
                            VehicleId = 10
                        },
                        new
                        {
                            DriverId = 8,
                            VehicleId = 10
                        },
                        new
                        {
                            DriverId = 9,
                            VehicleId = 11
                        },
                        new
                        {
                            DriverId = 8,
                            VehicleId = 11
                        },
                        new
                        {
                            DriverId = 9,
                            VehicleId = 12
                        },
                        new
                        {
                            DriverId = 8,
                            VehicleId = 12
                        },
                        new
                        {
                            DriverId = 10,
                            VehicleId = 13
                        },
                        new
                        {
                            DriverId = 10,
                            VehicleId = 14
                        },
                        new
                        {
                            DriverId = 10,
                            VehicleId = 15
                        },
                        new
                        {
                            DriverId = 10,
                            VehicleId = 16
                        },
                        new
                        {
                            DriverId = 10,
                            VehicleId = 17
                        },
                        new
                        {
                            DriverId = 10,
                            VehicleId = 18
                        },
                        new
                        {
                            DriverId = 10,
                            VehicleId = 19
                        },
                        new
                        {
                            DriverId = 10,
                            VehicleId = 20
                        });
                });

            modelBuilder.Entity("MotorPool.Domain.Enterprise", b =>
                {
                    b.Property<int>("EnterpriseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnterpriseId"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("FoundedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("VAT")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("EnterpriseId");

                    b.ToTable("Enterprises");

                    b.HasData(
                        new
                        {
                            EnterpriseId = 1,
                            City = "New York",
                            FoundedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "MotorPool",
                            Street = "5th Avenue",
                            VAT = "US123456789"
                        },
                        new
                        {
                            EnterpriseId = 2,
                            City = "Los Angeles",
                            FoundedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "MotorPool",
                            Street = "Hollywood Boulevard",
                            VAT = "US987654321"
                        },
                        new
                        {
                            EnterpriseId = 3,
                            City = "Chicago",
                            FoundedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "MotorPool",
                            Street = "Michigan Avenue",
                            VAT = "US123789456"
                        },
                        new
                        {
                            EnterpriseId = 4,
                            City = "Houston",
                            FoundedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "MotorPool",
                            Street = "Texas Avenue",
                            VAT = "US456123789"
                        },
                        new
                        {
                            EnterpriseId = 5,
                            City = "Philadelphia",
                            FoundedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "MotorPool",
                            Street = "Benjamin Franklin Parkway",
                            VAT = "US789456123"
                        });
                });

            modelBuilder.Entity("MotorPool.Domain.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleId"));

                    b.Property<decimal>("Cost")
                        .HasPrecision(15, 5)
                        .HasColumnType("decimal(15,5)");

                    b.Property<int?>("EnterpriseId")
                        .HasColumnType("int");

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

                    b.HasIndex("EnterpriseId");

                    b.HasIndex("MotorVIN")
                        .IsUnique();

                    b.HasIndex("VehicleBrandId");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            VehicleId = 1,
                            Cost = 20000m,
                            EnterpriseId = 1,
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
                            EnterpriseId = 1,
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
                            EnterpriseId = 1,
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
                            EnterpriseId = 1,
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
                            EnterpriseId = 1,
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
                            EnterpriseId = 2,
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
                            EnterpriseId = 2,
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
                            EnterpriseId = 2,
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
                            EnterpriseId = 2,
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
                            EnterpriseId = 3,
                            ManufactureLand = "USA",
                            ManufactureYear = 2022,
                            Mileage = 11000m,
                            MotorVIN = "0FORDTRN1MN209185",
                            VehicleBrandId = 5
                        },
                        new
                        {
                            VehicleId = 11,
                            Cost = 23000m,
                            EnterpriseId = 3,
                            ManufactureLand = "Japan",
                            ManufactureYear = 2020,
                            Mileage = 13000m,
                            MotorVIN = "1HGBH41JXMN309186",
                            VehicleBrandId = 1
                        },
                        new
                        {
                            VehicleId = 12,
                            Cost = 110000m,
                            EnterpriseId = 3,
                            ManufactureLand = "Sweden",
                            ManufactureYear = 2019,
                            Mileage = 60000m,
                            MotorVIN = "2VOLVOB7R2MN30918",
                            VehicleBrandId = 2
                        },
                        new
                        {
                            VehicleId = 13,
                            Cost = 130000m,
                            ManufactureLand = "Sweden",
                            ManufactureYear = 2018,
                            Mileage = 24000m,
                            MotorVIN = "3SCANPSE2MN309187",
                            VehicleBrandId = 3
                        },
                        new
                        {
                            VehicleId = 14,
                            Cost = 120000m,
                            ManufactureLand = "Germany",
                            ManufactureYear = 2021,
                            Mileage = 33000m,
                            MotorVIN = "4MBNZCTR2MN309186",
                            VehicleBrandId = 4
                        },
                        new
                        {
                            VehicleId = 15,
                            Cost = 34000m,
                            ManufactureLand = "USA",
                            ManufactureYear = 2022,
                            Mileage = 12000m,
                            MotorVIN = "5FORDTRN2MN309185",
                            VehicleBrandId = 5
                        },
                        new
                        {
                            VehicleId = 16,
                            Cost = 24000m,
                            ManufactureLand = "Japan",
                            ManufactureYear = 2020,
                            Mileage = 14000m,
                            MotorVIN = "6HGBH41JXMN409186",
                            VehicleBrandId = 1
                        },
                        new
                        {
                            VehicleId = 17,
                            Cost = 115000m,
                            ManufactureLand = "Sweden",
                            ManufactureYear = 2019,
                            Mileage = 65000m,
                            MotorVIN = "7VOLVOB7R3MN40918",
                            VehicleBrandId = 2
                        },
                        new
                        {
                            VehicleId = 18,
                            Cost = 135000m,
                            ManufactureLand = "Sweden",
                            ManufactureYear = 2018,
                            Mileage = 26000m,
                            MotorVIN = "8SCANPSE3MN409187",
                            VehicleBrandId = 3
                        },
                        new
                        {
                            VehicleId = 19,
                            Cost = 125000m,
                            ManufactureLand = "Germany",
                            ManufactureYear = 2021,
                            Mileage = 34000m,
                            MotorVIN = "9MBNZCTR3MN409186",
                            VehicleBrandId = 4
                        },
                        new
                        {
                            VehicleId = 20,
                            Cost = 36000m,
                            ManufactureLand = "USA",
                            ManufactureYear = 2022,
                            Mileage = 13000m,
                            MotorVIN = "0FORDTRN3MN409185",
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

            modelBuilder.Entity("MotorPool.Domain.Driver", b =>
                {
                    b.HasOne("MotorPool.Domain.Vehicle", "ActiveVehicle")
                        .WithMany()
                        .HasForeignKey("ActiveVehicleId");

                    b.HasOne("MotorPool.Domain.Enterprise", "Enterprise")
                        .WithMany("Drivers")
                        .HasForeignKey("EnterpriseId");

                    b.Navigation("ActiveVehicle");

                    b.Navigation("Enterprise");
                });

            modelBuilder.Entity("MotorPool.Domain.DriverVehicle", b =>
                {
                    b.HasOne("MotorPool.Domain.Driver", "Driver")
                        .WithMany("DriverVehicles")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MotorPool.Domain.Vehicle", "Vehicle")
                        .WithMany("DriverVehicles")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("MotorPool.Domain.Vehicle", b =>
                {
                    b.HasOne("MotorPool.Domain.Enterprise", "Enterprise")
                        .WithMany("Vehicles")
                        .HasForeignKey("EnterpriseId");

                    b.HasOne("MotorPool.Domain.VehicleBrand", "VehicleBrand")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Enterprise");

                    b.Navigation("VehicleBrand");
                });

            modelBuilder.Entity("MotorPool.Domain.Driver", b =>
                {
                    b.Navigation("DriverVehicles");
                });

            modelBuilder.Entity("MotorPool.Domain.Enterprise", b =>
                {
                    b.Navigation("Drivers");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("MotorPool.Domain.Vehicle", b =>
                {
                    b.Navigation("DriverVehicles");
                });

            modelBuilder.Entity("MotorPool.Domain.VehicleBrand", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
