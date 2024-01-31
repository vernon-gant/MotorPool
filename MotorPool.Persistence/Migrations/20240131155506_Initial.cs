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
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VIN = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ManufactureYear = table.Column<int>(type: "int", nullable: false),
                    ManufactureLand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: false),
                    Mileage = table.Column<decimal>(type: "decimal(13,3)", precision: 13, scale: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "Cost", "ManufactureLand", "ManufactureYear", "Manufacturer", "Mileage", "Model", "VIN" },
                values: new object[,]
                {
                    { 1, 20000m, "Japan", 2020, "Toyota", 15000m, "Corolla", "1HGBH41JXMN109186" },
                    { 2, 18000m, "Japan", 2019, "Honda", 20000m, "Civic", "2HGBH41JXMN109187" },
                    { 3, 17000m, "USA", 2018, "Ford", 25000m, "Focus", "3CZRE4H56BG704113" },
                    { 4, 22000m, "USA", 2021, "Chevrolet", 10000m, "Impala", "1HGCM82633A004352" },
                    { 5, 24000m, "Japan", 2022, "Nissan", 5000m, "Altima", "19XFB2F59CE308872" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_Manufacturer",
                table: "Vehicles",
                column: "Manufacturer");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VIN",
                table: "Vehicles",
                column: "VIN",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
