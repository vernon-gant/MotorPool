using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MotorPool.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleBrands",
                columns: table => new
                {
                    VehicleBrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuelTankCapacityLiters = table.Column<decimal>(type: "decimal(10,4)", precision: 10, scale: 4, nullable: false),
                    PayloadCapacityKg = table.Column<decimal>(type: "decimal(11,5)", precision: 11, scale: 5, nullable: false),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleBrands", x => x.VehicleBrandId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotorVIN = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: false),
                    ManufactureYear = table.Column<int>(type: "int", nullable: false),
                    ManufactureLand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mileage = table.Column<decimal>(type: "decimal(13,3)", precision: 13, scale: 3, nullable: false),
                    VehicleBrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleBrands_VehicleBrandId",
                        column: x => x.VehicleBrandId,
                        principalTable: "VehicleBrands",
                        principalColumn: "VehicleBrandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "VehicleBrands",
                columns: new[] { "VehicleBrandId", "CompanyName", "FuelTankCapacityLiters", "ModelName", "NumberOfSeats", "PayloadCapacityKg", "ReleaseYear", "Type" },
                values: new object[,]
                {
                    { 1, "Toyota", 50m, "Corolla", 5, 450m, 2020, "PassengerCar" },
                    { 2, "Volvo", 300m, "B7R", 50, 7500m, 2019, "Bus" },
                    { 3, "Scania", 400m, "P Series", 3, 15000m, 2018, "Truck" },
                    { 4, "Mercedes-Benz", 275m, "Citaro", 45, 18000m, 2021, "Bus" },
                    { 5, "Ford", 80m, "Transit", 3, 1200m, 2022, "Truck" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "Cost", "ManufactureLand", "ManufactureYear", "Mileage", "MotorVIN", "VehicleBrandId" },
                values: new object[,]
                {
                    { 1, 20000m, "Japan", 2020, 15000m, "1HGBH41JXMN109186", 1 },
                    { 2, 100000m, "Sweden", 2019, 50000m, "2VOLVOB7R0MN10918", 2 },
                    { 3, 120000m, "Sweden", 2018, 20000m, "3SCANPSE0MN109187", 3 },
                    { 4, 110000m, "Germany", 2021, 30000m, "4MBNZCTR0MN109186", 4 },
                    { 5, 30000m, "USA", 2022, 10000m, "5FORDTRN0MN109185", 5 },
                    { 6, 22000m, "Japan", 2020, 12000m, "6HGBH41JXMN209186", 1 },
                    { 7, 105000m, "Sweden", 2019, 55000m, "7VOLVOB7R1MN20918", 2 },
                    { 8, 125000m, "Sweden", 2018, 22000m, "8SCANPSE1MN209187", 3 },
                    { 9, 115000m, "Germany", 2021, 32000m, "9MBNZCTR1MN209186", 4 },
                    { 10, 32000m, "USA", 2022, 11000m, "0FORDTRN1MN209185", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_MotorVIN",
                table: "Vehicles",
                column: "MotorVIN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleBrandId",
                table: "Vehicles",
                column: "VehicleBrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "VehicleBrands");
        }
    }
}
