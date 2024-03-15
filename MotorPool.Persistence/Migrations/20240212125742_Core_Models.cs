using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MotorPool.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Core_Models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnterpriseId",
                table: "Vehicles",
                type: "int",
                nullable: true);

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
                name: "Drivers",
                columns: table => new
                {
                    DriverId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(9,3)", precision: 9, scale: 3, nullable: false),
                    EnterpriseId = table.Column<int>(type: "int", nullable: true),
                    ActiveVehicleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverId);
                    table.ForeignKey(
                        name: "FK_Drivers_Enterprises_EnterpriseId",
                        column: x => x.EnterpriseId,
                        principalTable: "Enterprises",
                        principalColumn: "EnterpriseId");
                    table.ForeignKey(
                        name: "FK_Drivers_Vehicles_ActiveVehicleId",
                        column: x => x.ActiveVehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId");
                });

            migrationBuilder.CreateTable(
                name: "DriverVehicle",
                columns: table => new
                {
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverVehicle", x => new { x.DriverId, x.VehicleId });
                    table.ForeignKey(
                        name: "FK_DriverVehicle_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriverVehicle_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "DriverId", "ActiveVehicleId", "EnterpriseId", "FirstName", "LastName", "Salary" },
                values: new object[] { 10, null, null, "Jocelyn", "Doe", 6500m });

            migrationBuilder.InsertData(
                table: "Enterprises",
                columns: new[] { "EnterpriseId", "City", "FoundedOn", "Name", "Street", "VAT" },
                values: new object[,]
                {
                    { 1, "New York", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MotorPool1", "5th Avenue", "US123456789" },
                    { 2, "Los Angeles", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MotorPool2", "Hollywood Boulevard", "US987654321" },
                    { 3, "Chicago", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MotorPool3", "Michigan Avenue", "US123789456" },
                    { 4, "Houston", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MotorPool4", "Texas Avenue", "US456123789" },
                    { 5, "Philadelphia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MotorPool5", "Benjamin Franklin Parkway", "US789456123" }
                });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                column: "EnterpriseId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                column: "EnterpriseId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                column: "EnterpriseId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                column: "EnterpriseId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                column: "EnterpriseId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6,
                column: "EnterpriseId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7,
                column: "EnterpriseId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8,
                column: "EnterpriseId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9,
                column: "EnterpriseId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10,
                column: "EnterpriseId",
                value: 3);

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "Cost", "EnterpriseId", "ManufactureLand", "ManufactureYear", "Mileage", "MotorVIN", "VehicleBrandId" },
                values: new object[,]
                {
                    { 13, 130000m, null, "Sweden", 2018, 24000m, "3SCANPSE2MN309187", 3 },
                    { 14, 120000m, null, "Germany", 2021, 33000m, "4MBNZCTR2MN309186", 4 },
                    { 15, 34000m, null, "USA", 2022, 12000m, "5FORDTRN2MN309185", 5 },
                    { 16, 24000m, null, "Japan", 2020, 14000m, "6HGBH41JXMN409186", 1 },
                    { 17, 115000m, null, "Sweden", 2019, 65000m, "7VOLVOB7R3MN40918", 2 },
                    { 18, 135000m, null, "Sweden", 2018, 26000m, "8SCANPSE3MN409187", 3 },
                    { 19, 125000m, null, "Germany", 2021, 34000m, "9MBNZCTR3MN409186", 4 },
                    { 20, 36000m, null, "USA", 2022, 13000m, "0FORDTRN3MN409185", 5 }
                });

            migrationBuilder.InsertData(
                table: "DriverVehicle",
                columns: new[] { "DriverId", "VehicleId" },
                values: new object[,]
                {
                    { 10, 13 },
                    { 10, 14 },
                    { 10, 15 },
                    { 10, 16 },
                    { 10, 17 },
                    { 10, 18 },
                    { 10, 19 },
                    { 10, 20 }
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "DriverId", "ActiveVehicleId", "EnterpriseId", "FirstName", "LastName", "Salary" },
                values: new object[,]
                {
                    { 1, null, 1, "John", "Doe", 2000m },
                    { 2, null, 1, "Jane", "Doe", 2500m },
                    { 3, null, 1, "Jack", "Doe", 3000m },
                    { 4, null, 1, "Jill", "Doe", 3500m },
                    { 5, null, 2, "Jim", "Doe", 4000m },
                    { 6, null, 2, "Jenny", "Doe", 4500m },
                    { 7, null, 2, "Jasper", "Doe", 5000m },
                    { 8, null, 3, "Jasmine", "Doe", 5500m },
                    { 9, null, 3, "Jared", "Doe", 6000m }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "Cost", "EnterpriseId", "ManufactureLand", "ManufactureYear", "Mileage", "MotorVIN", "VehicleBrandId" },
                values: new object[,]
                {
                    { 11, 23000m, 3, "Japan", 2020, 13000m, "1HGBH41JXMN309186", 1 },
                    { 12, 110000m, 3, "Sweden", 2019, 60000m, "2VOLVOB7R2MN30918", 2 }
                });

            migrationBuilder.InsertData(
                table: "DriverVehicle",
                columns: new[] { "DriverId", "VehicleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 2, 2 },
                    { 2, 5 },
                    { 3, 1 },
                    { 3, 3 },
                    { 3, 4 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 3 },
                    { 4, 4 },
                    { 4, 5 },
                    { 5, 6 },
                    { 5, 7 },
                    { 5, 8 },
                    { 5, 9 },
                    { 6, 6 },
                    { 6, 7 },
                    { 6, 8 },
                    { 6, 9 },
                    { 7, 6 },
                    { 7, 7 },
                    { 7, 8 },
                    { 7, 9 },
                    { 8, 10 },
                    { 8, 11 },
                    { 8, 12 },
                    { 9, 10 },
                    { 9, 11 },
                    { 9, 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_EnterpriseId",
                table: "Vehicles",
                column: "EnterpriseId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_ActiveVehicleId",
                table: "Drivers",
                column: "ActiveVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_EnterpriseId",
                table: "Drivers",
                column: "EnterpriseId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverVehicle_VehicleId",
                table: "DriverVehicle",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Enterprises_EnterpriseId",
                table: "Vehicles",
                column: "EnterpriseId",
                principalTable: "Enterprises",
                principalColumn: "EnterpriseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Enterprises_EnterpriseId",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "DriverVehicle");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Enterprises");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_EnterpriseId",
                table: "Vehicles");

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

            migrationBuilder.DropColumn(
                name: "EnterpriseId",
                table: "Vehicles");
        }
    }
}
