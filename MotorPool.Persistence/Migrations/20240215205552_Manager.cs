using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MotorPool.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Manager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.ManagerId);
                });

            migrationBuilder.CreateTable(
                name: "EnterpriseManager",
                columns: table => new
                {
                    ManagerId = table.Column<int>(type: "int", nullable: false),
                    EnterpriseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnterpriseManager", x => new { x.ManagerId, x.EnterpriseId });
                    table.ForeignKey(
                        name: "FK_EnterpriseManager_Enterprises_EnterpriseId",
                        column: x => x.EnterpriseId,
                        principalTable: "Enterprises",
                        principalColumn: "EnterpriseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnterpriseManager_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DriverVehicle",
                columns: new[] { "DriverId", "VehicleId" },
                values: new object[,]
                {
                    { 1, 5 },
                    { 2, 1 },
                    { 3, 3 },
                    { 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                column: "ManagerId",
                values: new object[]
                {
                    1,
                    2,
                    3
                });

            migrationBuilder.InsertData(
                table: "EnterpriseManager",
                columns: new[] { "EnterpriseId", "ManagerId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnterpriseManager_EnterpriseId",
                table: "EnterpriseManager",
                column: "EnterpriseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnterpriseManager");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.InsertData(
                table: "DriverVehicle",
                columns: new[] { "DriverId", "VehicleId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 1, 4 },
                    { 3, 1 },
                    { 3, 5 }
                });
        }
    }
}
