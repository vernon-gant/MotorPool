using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MotorPool.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class GeoPoints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeoPoints",
                columns: table => new
                {
                    GeoPointId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<double>(type: "float(9)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<double>(type: "float(9)", precision: 9, scale: 6, nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    RecordedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoPoints", x => x.GeoPointId);
                    table.ForeignKey(
                        name: "FK_GeoPoints_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EnterpriseManagers",
                columns: new[] { "EnterpriseId", "ManagerId" },
                values: new object[] { 6, 3 });

            migrationBuilder.UpdateData(
                table: "Enterprises",
                keyColumn: "EnterpriseId",
                keyValue: 2,
                column: "FoundedOn",
                value: new DateOnly(2004, 4, 1));

            migrationBuilder.InsertData(
                table: "GeoPoints",
                columns: new[] { "GeoPointId", "Latitude", "Longitude", "RecordedAt", "VehicleId" },
                values: new object[,]
                {
                    { 1, 40.730609999999999, -73.935242000000002, new DateTime(2024, 2, 8, 12, 30, 41, 90, DateTimeKind.Utc).AddTicks(6933), 15022 },
                    { 2, 40.731610000000003, -73.935242000000002, new DateTime(2024, 2, 8, 13, 30, 41, 90, DateTimeKind.Utc).AddTicks(6933), 15022 },
                    { 3, 40.732610000000001, -73.935242000000002, new DateTime(2024, 2, 8, 15, 0, 41, 90, DateTimeKind.Utc).AddTicks(6933), 15022 },
                    { 4, 40.733609999999999, -73.935242000000002, new DateTime(2024, 2, 8, 15, 45, 41, 90, DateTimeKind.Utc).AddTicks(6933), 15022 },
                    { 5, 40.734610000000004, -73.935242000000002, new DateTime(2024, 2, 8, 17, 15, 41, 90, DateTimeKind.Utc).AddTicks(6933), 15022 },
                    { 6, 40.735610000000001, -73.935242000000002, new DateTime(2024, 2, 8, 18, 0, 41, 90, DateTimeKind.Utc).AddTicks(6933), 15022 },
                    { 7, 40.736609999999999, -73.935242000000002, new DateTime(2024, 2, 8, 18, 45, 41, 90, DateTimeKind.Utc).AddTicks(6933), 15022 },
                    { 8, 40.737609999999997, -73.935242000000002, new DateTime(2024, 2, 8, 20, 15, 41, 90, DateTimeKind.Utc).AddTicks(6933), 15022 },
                    { 9, 40.738610000000001, -73.935242000000002, new DateTime(2024, 2, 8, 21, 0, 41, 90, DateTimeKind.Utc).AddTicks(6933), 15022 },
                    { 10, 40.739609999999999, -73.935242000000002, new DateTime(2024, 2, 8, 21, 45, 41, 90, DateTimeKind.Utc).AddTicks(6933), 15022 },
                    { 11, 40.740609999999997, -73.935242000000002, new DateTime(2024, 2, 8, 23, 15, 41, 90, DateTimeKind.Utc).AddTicks(6933), 15022 },
                    { 12, 40.741610000000001, -73.935242000000002, new DateTime(2024, 2, 9, 0, 0, 41, 90, DateTimeKind.Utc).AddTicks(6933), 15022 },
                    { 13, 40.742609999999999, -73.935242000000002, new DateTime(2024, 2, 9, 0, 45, 41, 90, DateTimeKind.Utc).AddTicks(6933), 15022 },
                    { 14, 40.743609999999997, -73.935242000000002, new DateTime(2024, 2, 9, 2, 15, 41, 90, DateTimeKind.Utc).AddTicks(6933), 15022 },
                    { 15, 40.744610000000002, -73.935242000000002, new DateTime(2024, 2, 9, 3, 0, 41, 90, DateTimeKind.Utc).AddTicks(6933), 15022 },
                    { 16, 40.745609999999999, -73.935242000000002, new DateTime(2024, 2, 9, 3, 45, 41, 90, DateTimeKind.Utc).AddTicks(6933), 15022 },
                    { 17, 40.746609999999997, -73.935242000000002, new DateTime(2024, 2, 9, 5, 15, 41, 90, DateTimeKind.Utc).AddTicks(6933), 15022 },
                    { 18, 40.747610000000002, -73.935242000000002, new DateTime(2024, 2, 9, 6, 0, 41, 90, DateTimeKind.Utc).AddTicks(6933), 15022 },
                    { 19, 40.748609999999999, -73.935242000000002, new DateTime(2024, 2, 9, 6, 45, 41, 90, DateTimeKind.Utc).AddTicks(6933), 15022 },
                    { 20, 40.749609999999997, -73.935242000000002, new DateTime(2024, 2, 9, 8, 15, 41, 90, DateTimeKind.Utc).AddTicks(6933), 15022 },
                    { 21, 48.208199999999998, 16.373799999999999, new DateTime(2023, 12, 9, 9, 30, 41, 90, DateTimeKind.Utc).AddTicks(7033), 20213 },
                    { 22, 48.209200000000003, 16.3748, new DateTime(2023, 12, 9, 10, 30, 41, 90, DateTimeKind.Utc).AddTicks(7033), 20213 },
                    { 23, 48.2102, 16.375800000000002, new DateTime(2023, 12, 9, 12, 0, 41, 90, DateTimeKind.Utc).AddTicks(7033), 20213 },
                    { 24, 48.211199999999998, 16.376799999999999, new DateTime(2023, 12, 9, 12, 45, 41, 90, DateTimeKind.Utc).AddTicks(7033), 20213 },
                    { 25, 48.212200000000003, 16.377800000000001, new DateTime(2023, 12, 9, 14, 15, 41, 90, DateTimeKind.Utc).AddTicks(7033), 20213 },
                    { 26, 48.213200000000001, 16.378799999999998, new DateTime(2023, 12, 9, 15, 0, 41, 90, DateTimeKind.Utc).AddTicks(7033), 20213 },
                    { 27, 48.214199999999998, 16.379799999999999, new DateTime(2023, 12, 9, 15, 45, 41, 90, DateTimeKind.Utc).AddTicks(7033), 20213 },
                    { 28, 48.215200000000003, 16.380800000000001, new DateTime(2023, 12, 9, 17, 15, 41, 90, DateTimeKind.Utc).AddTicks(7033), 20213 },
                    { 29, 48.216200000000001, 16.381799999999998, new DateTime(2023, 12, 9, 18, 0, 41, 90, DateTimeKind.Utc).AddTicks(7033), 20213 },
                    { 30, 48.217199999999998, 16.3828, new DateTime(2023, 12, 9, 18, 45, 41, 90, DateTimeKind.Utc).AddTicks(7033), 20213 },
                    { 31, 55.755800000000001, 37.617600000000003, new DateTime(2024, 1, 15, 16, 30, 41, 90, DateTimeKind.Utc).AddTicks(7040), 27094 },
                    { 32, 55.756799999999998, 37.618600000000001, new DateTime(2024, 1, 15, 17, 30, 41, 90, DateTimeKind.Utc).AddTicks(7040), 27094 },
                    { 33, 55.757800000000003, 37.619599999999998, new DateTime(2024, 1, 15, 19, 0, 41, 90, DateTimeKind.Utc).AddTicks(7040), 27094 },
                    { 34, 55.758800000000001, 37.620600000000003, new DateTime(2024, 1, 15, 19, 45, 41, 90, DateTimeKind.Utc).AddTicks(7040), 27094 },
                    { 35, 55.759799999999998, 37.621600000000001, new DateTime(2024, 1, 15, 21, 15, 41, 90, DateTimeKind.Utc).AddTicks(7040), 27094 },
                    { 36, 55.760800000000003, 37.622599999999998, new DateTime(2024, 1, 15, 22, 0, 41, 90, DateTimeKind.Utc).AddTicks(7040), 27094 },
                    { 37, 55.761800000000001, 37.623600000000003, new DateTime(2024, 1, 15, 22, 45, 41, 90, DateTimeKind.Utc).AddTicks(7040), 27094 },
                    { 38, 55.762799999999999, 37.624600000000001, new DateTime(2024, 1, 16, 0, 15, 41, 90, DateTimeKind.Utc).AddTicks(7040), 27094 },
                    { 39, 55.763800000000003, 37.625599999999999, new DateTime(2024, 1, 16, 1, 0, 41, 90, DateTimeKind.Utc).AddTicks(7040), 27094 },
                    { 40, 55.764800000000001, 37.626600000000003, new DateTime(2024, 1, 16, 1, 45, 41, 90, DateTimeKind.Utc).AddTicks(7040), 27094 },
                    { 41, 55.765799999999999, 37.627600000000001, new DateTime(2024, 1, 16, 3, 15, 41, 90, DateTimeKind.Utc).AddTicks(7040), 27094 },
                    { 42, 55.766800000000003, 37.628599999999999, new DateTime(2024, 1, 16, 4, 0, 41, 90, DateTimeKind.Utc).AddTicks(7040), 27094 },
                    { 43, 55.767800000000001, 37.629600000000003, new DateTime(2024, 1, 16, 4, 45, 41, 90, DateTimeKind.Utc).AddTicks(7040), 27094 },
                    { 44, 55.768799999999999, 37.630600000000001, new DateTime(2024, 1, 16, 6, 15, 41, 90, DateTimeKind.Utc).AddTicks(7040), 27094 },
                    { 45, 55.769799999999996, 37.631599999999999, new DateTime(2024, 1, 16, 7, 0, 41, 90, DateTimeKind.Utc).AddTicks(7040), 27094 },
                    { 46, 55.770800000000001, 37.632599999999996, new DateTime(2024, 1, 16, 7, 45, 41, 90, DateTimeKind.Utc).AddTicks(7040), 27094 },
                    { 47, 55.771799999999999, 37.633600000000001, new DateTime(2024, 1, 16, 9, 15, 41, 90, DateTimeKind.Utc).AddTicks(7040), 27094 },
                    { 48, 55.772799999999997, 37.634599999999999, new DateTime(2024, 1, 16, 10, 0, 41, 90, DateTimeKind.Utc).AddTicks(7040), 27094 },
                    { 49, 55.773800000000001, 37.635599999999997, new DateTime(2024, 1, 16, 10, 45, 41, 90, DateTimeKind.Utc).AddTicks(7040), 27094 },
                    { 50, 55.774799999999999, 37.636600000000001, new DateTime(2024, 1, 16, 12, 15, 41, 90, DateTimeKind.Utc).AddTicks(7040), 27094 },
                    { 51, 55.775799999999997, 37.637599999999999, new DateTime(2024, 1, 16, 13, 0, 41, 90, DateTimeKind.Utc).AddTicks(7040), 27094 },
                    { 52, 55.776800000000001, 37.638599999999997, new DateTime(2024, 1, 16, 13, 45, 41, 90, DateTimeKind.Utc).AddTicks(7040), 27094 },
                    { 53, 55.777799999999999, 37.639600000000002, new DateTime(2024, 1, 16, 15, 15, 41, 90, DateTimeKind.Utc).AddTicks(7040), 27094 },
                    { 54, 55.778799999999997, 37.640599999999999, new DateTime(2024, 1, 16, 16, 0, 41, 90, DateTimeKind.Utc).AddTicks(7040), 27094 },
                    { 55, 55.779800000000002, 37.641599999999997, new DateTime(2024, 1, 16, 16, 45, 41, 90, DateTimeKind.Utc).AddTicks(7040), 27094 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeoPoints_VehicleId",
                table: "GeoPoints",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeoPoints");

            migrationBuilder.DeleteData(
                table: "EnterpriseManagers",
                keyColumns: new[] { "EnterpriseId", "ManagerId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.UpdateData(
                table: "Enterprises",
                keyColumn: "EnterpriseId",
                keyValue: 2,
                column: "FoundedOn",
                value: new DateOnly(2006, 4, 1));
        }
    }
}
