using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MotorPool.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Core_Relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(9,3)", precision: 9, scale: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverId);
                });

            migrationBuilder.CreateTable(
                name: "Enterprises",
                columns: table => new
                {
                    EnterpriseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VAT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FoundedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enterprises", x => x.EnterpriseId);
                });

            migrationBuilder.CreateTable(
                name: "EnterpriseDriver",
                columns: table => new
                {
                    EnterpriseDriverId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    EnterpriseId = table.Column<int>(type: "int", nullable: false),
                    HiredOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnterpriseDriver", x => x.EnterpriseDriverId);
                    table.ForeignKey(
                        name: "FK_EnterpriseDriver_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnterpriseDriver_Enterprises_EnterpriseId",
                        column: x => x.EnterpriseId,
                        principalTable: "Enterprises",
                        principalColumn: "EnterpriseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnterpriseVehicle",
                columns: table => new
                {
                    EnterpriseVehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    EnterpriseId = table.Column<int>(type: "int", nullable: false),
                    AcquiredOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnterpriseVehicle", x => x.EnterpriseVehicleId);
                    table.ForeignKey(
                        name: "FK_EnterpriseVehicle_Enterprises_EnterpriseId",
                        column: x => x.EnterpriseId,
                        principalTable: "Enterprises",
                        principalColumn: "EnterpriseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnterpriseVehicle_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnterpriseVehicleDriver",
                columns: table => new
                {
                    EnterpriseVehicleDriverId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnterpriseVehicleId = table.Column<int>(type: "int", nullable: false),
                    EnterpriseDriverId = table.Column<int>(type: "int", nullable: false),
                    AssignedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnterpriseVehicleDriver", x => x.EnterpriseVehicleDriverId);
                    table.ForeignKey(
                        name: "FK_EnterpriseVehicleDriver_EnterpriseDriver_EnterpriseDriverId",
                        column: x => x.EnterpriseDriverId,
                        principalTable: "EnterpriseDriver",
                        principalColumn: "EnterpriseDriverId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EnterpriseVehicleDriver_EnterpriseVehicle_EnterpriseVehicleId",
                        column: x => x.EnterpriseVehicleId,
                        principalTable: "EnterpriseVehicle",
                        principalColumn: "EnterpriseVehicleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActiveDriver",
                columns: table => new
                {
                    ActiveDriverId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnterpriseVehicleDriverId = table.Column<int>(type: "int", nullable: false),
                    StartedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    StoppedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveDriver", x => x.ActiveDriverId);
                    table.ForeignKey(
                        name: "FK_ActiveDriver_EnterpriseVehicleDriver_EnterpriseVehicleDriverId",
                        column: x => x.EnterpriseVehicleDriverId,
                        principalTable: "EnterpriseVehicleDriver",
                        principalColumn: "EnterpriseVehicleDriverId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "DriverId", "FirstName", "LastName", "Salary" },
                values: new object[,]
                {
                    { 1, "John", "Doe", 2000m },
                    { 2, "Jane", "Doe", 2500m },
                    { 3, "Jack", "Doe", 3000m },
                    { 4, "Jill", "Doe", 3500m },
                    { 5, "Jim", "Doe", 4000m },
                    { 6, "Jenny", "Doe", 4500m },
                    { 7, "Jasper", "Doe", 5000m },
                    { 8, "Jasmine", "Doe", 5500m },
                    { 9, "Jared", "Doe", 6000m },
                    { 10, "Jocelyn", "Doe", 6500m }
                });

            migrationBuilder.InsertData(
                table: "Enterprises",
                columns: new[] { "EnterpriseId", "City", "FoundedOn", "Name", "Street", "VAT" },
                values: new object[,]
                {
                    { 1, "New York", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MotorPool", "5th Avenue", "US123456789" },
                    { 2, "Los Angeles", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MotorPool", "Hollywood Boulevard", "US987654321" },
                    { 3, "Chicago", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MotorPool", "Michigan Avenue", "US123789456" },
                    { 4, "Houston", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MotorPool", "Texas Avenue", "US456123789" },
                    { 5, "Philadelphia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MotorPool", "Benjamin Franklin Parkway", "US789456123" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "Cost", "ManufactureLand", "ManufactureYear", "Mileage", "MotorVIN", "VehicleBrandId" },
                values: new object[,]
                {
                    { 11, 23000m, "Japan", 2020, 13000m, "1HGBH41JXMN309186", 1 },
                    { 12, 110000m, "Sweden", 2019, 60000m, "2VOLVOB7R2MN30918", 2 },
                    { 13, 130000m, "Sweden", 2018, 24000m, "3SCANPSE2MN309187", 3 },
                    { 14, 120000m, "Germany", 2021, 33000m, "4MBNZCTR2MN309186", 4 },
                    { 15, 34000m, "USA", 2022, 12000m, "5FORDTRN2MN309185", 5 },
                    { 16, 24000m, "Japan", 2020, 14000m, "6HGBH41JXMN409186", 1 },
                    { 17, 115000m, "Sweden", 2019, 65000m, "7VOLVOB7R3MN40918", 2 },
                    { 18, 135000m, "Sweden", 2018, 26000m, "8SCANPSE3MN409187", 3 },
                    { 19, 125000m, "Germany", 2021, 34000m, "9MBNZCTR3MN409186", 4 },
                    { 20, 36000m, "USA", 2022, 13000m, "0FORDTRN3MN409185", 5 }
                });

            migrationBuilder.InsertData(
                table: "EnterpriseDriver",
                columns: new[] { "EnterpriseDriverId", "DriverId", "EnterpriseId", "HiredOn" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 1, new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, 1, new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, 1, new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, 2, new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 6, 2, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 7, 2, new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 8, 3, new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "EnterpriseVehicle",
                columns: new[] { "EnterpriseVehicleId", "AcquiredOn", "EnterpriseId", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 3, new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 4, new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 5, new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5 },
                    { 6, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 6 },
                    { 7, new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 7 },
                    { 8, new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 8 },
                    { 9, new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 9 },
                    { 10, new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 10 },
                    { 11, new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 11 },
                    { 12, new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 12 },
                    { 13, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 13 },
                    { 14, new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 14 },
                    { 15, new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 15 }
                });

            migrationBuilder.InsertData(
                table: "EnterpriseVehicleDriver",
                columns: new[] { "EnterpriseVehicleDriverId", "AssignedOn", "EnterpriseDriverId", "EnterpriseVehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 3, new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1 },
                    { 4, new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1 },
                    { 5, new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 6, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 7, new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 },
                    { 8, new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2 },
                    { 9, new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 10, new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 11, new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 },
                    { 12, new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 13, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5 },
                    { 14, new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 6 },
                    { 15, new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 8 },
                    { 16, new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 8 },
                    { 17, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 8 },
                    { 18, new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 9 },
                    { 19, new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 9 },
                    { 20, new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 9 },
                    { 21, new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 10 },
                    { 22, new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 10 },
                    { 23, new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 10 },
                    { 24, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 11 },
                    { 25, new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 13 },
                    { 26, new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 14 }
                });

            migrationBuilder.InsertData(
                table: "ActiveDriver",
                columns: new[] { "ActiveDriverId", "EnterpriseVehicleDriverId", "StartedOn", "StoppedOn" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, 6, new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, 11, new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActiveDriver_EnterpriseVehicleDriverId",
                table: "ActiveDriver",
                column: "EnterpriseVehicleDriverId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnterpriseDriver_DriverId",
                table: "EnterpriseDriver",
                column: "DriverId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnterpriseDriver_EnterpriseId",
                table: "EnterpriseDriver",
                column: "EnterpriseId");

            migrationBuilder.CreateIndex(
                name: "IX_EnterpriseVehicle_EnterpriseId",
                table: "EnterpriseVehicle",
                column: "EnterpriseId");

            migrationBuilder.CreateIndex(
                name: "IX_EnterpriseVehicle_VehicleId",
                table: "EnterpriseVehicle",
                column: "VehicleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnterpriseVehicleDriver_EnterpriseDriverId",
                table: "EnterpriseVehicleDriver",
                column: "EnterpriseDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_EnterpriseVehicleDriver_EnterpriseVehicleId",
                table: "EnterpriseVehicleDriver",
                column: "EnterpriseVehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActiveDriver");

            migrationBuilder.DropTable(
                name: "EnterpriseVehicleDriver");

            migrationBuilder.DropTable(
                name: "EnterpriseDriver");

            migrationBuilder.DropTable(
                name: "EnterpriseVehicle");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Enterprises");

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 20);
        }
    }
}
