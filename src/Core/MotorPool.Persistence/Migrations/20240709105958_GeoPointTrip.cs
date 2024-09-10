using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorPool.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class GeoPointTrip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EndGeoPointId",
                table: "Trips",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StartGeoPointId",
                table: "Trips",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TripId",
                table: "GeoPoints",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_EndGeoPointId",
                table: "Trips",
                column: "EndGeoPointId",
                unique: true,
                filter: "[EndGeoPointId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_StartGeoPointId",
                table: "Trips",
                column: "StartGeoPointId",
                unique: true,
                filter: "[StartGeoPointId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GeoPoints_TripId",
                table: "GeoPoints",
                column: "TripId");

            migrationBuilder.AddForeignKey(
                name: "FK_GeoPoints_Trips_TripId",
                table: "GeoPoints",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "TripId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_GeoPoints_EndGeoPointId",
                table: "Trips",
                column: "EndGeoPointId",
                principalTable: "GeoPoints",
                principalColumn: "GeoPointId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_GeoPoints_StartGeoPointId",
                table: "Trips",
                column: "StartGeoPointId",
                principalTable: "GeoPoints",
                principalColumn: "GeoPointId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeoPoints_Trips_TripId",
                table: "GeoPoints");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_GeoPoints_EndGeoPointId",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_GeoPoints_StartGeoPointId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_EndGeoPointId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_StartGeoPointId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_GeoPoints_TripId",
                table: "GeoPoints");

            migrationBuilder.DropColumn(
                name: "EndGeoPointId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "StartGeoPointId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "TripId",
                table: "GeoPoints");
        }
    }
}
