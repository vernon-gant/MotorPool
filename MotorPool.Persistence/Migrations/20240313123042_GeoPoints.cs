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
