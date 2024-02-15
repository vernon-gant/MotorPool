using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MotorPool.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Changed_VehicleDriver : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 10, 13 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 10, 14 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 10, 15 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 10, 16 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 10, 17 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 10, 18 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 10, 19 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 10, 20 });

            migrationBuilder.InsertData(
                table: "DriverVehicle",
                columns: new[] { "DriverId", "VehicleId" },
                values: new object[,]
                {
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.InsertData(
                table: "DriverVehicle",
                columns: new[] { "DriverId", "VehicleId" },
                values: new object[,]
                {
                    { 1, 5 },
                    { 3, 3 },
                    { 4, 4 },
                    { 10, 13 },
                    { 10, 14 },
                    { 10, 15 },
                    { 10, 16 },
                    { 10, 17 },
                    { 10, 18 },
                    { 10, 19 },
                    { 10, 20 }
                });
        }
    }
}
