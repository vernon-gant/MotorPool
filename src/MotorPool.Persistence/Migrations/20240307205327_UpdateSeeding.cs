using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MotorPool.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnterpriseManager_Enterprises_EnterpriseId",
                table: "EnterpriseManager");

            migrationBuilder.DropForeignKey(
                name: "FK_EnterpriseManager_Managers_ManagerId",
                table: "EnterpriseManager");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnterpriseManager",
                table: "EnterpriseManager");

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 1, 2 });

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
                keyValues: new object[] { 2, 2 });

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
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 5, 7 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 6, 7 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 6, 8 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 6, 9 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 7, 6 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 7, 7 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 7, 8 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 7, 9 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 8, 10 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 8, 11 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 8, 12 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 9, 10 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 9, 11 });

            migrationBuilder.DeleteData(
                table: "DriverVehicle",
                keyColumns: new[] { "DriverId", "VehicleId" },
                keyValues: new object[] { 9, 12 });

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 10);

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

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 12);

            migrationBuilder.RenameTable(
                name: "EnterpriseManager",
                newName: "EnterpriseManagers");

            migrationBuilder.RenameIndex(
                name: "IX_EnterpriseManager_EnterpriseId",
                table: "EnterpriseManagers",
                newName: "IX_EnterpriseManagers_EnterpriseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnterpriseManagers",
                table: "EnterpriseManagers",
                columns: new[] { "ManagerId", "EnterpriseId" });

            migrationBuilder.CreateIndex(
                name: "IX_Enterprises_Name",
                table: "Enterprises",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enterprises_VAT",
                table: "Enterprises",
                column: "VAT",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EnterpriseManagers_Enterprises_EnterpriseId",
                table: "EnterpriseManagers",
                column: "EnterpriseId",
                principalTable: "Enterprises",
                principalColumn: "EnterpriseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnterpriseManagers_Managers_ManagerId",
                table: "EnterpriseManagers",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "ManagerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnterpriseManagers_Enterprises_EnterpriseId",
                table: "EnterpriseManagers");

            migrationBuilder.DropForeignKey(
                name: "FK_EnterpriseManagers_Managers_ManagerId",
                table: "EnterpriseManagers");

            migrationBuilder.DropIndex(
                name: "IX_Enterprises_Name",
                table: "Enterprises");

            migrationBuilder.DropIndex(
                name: "IX_Enterprises_VAT",
                table: "Enterprises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnterpriseManagers",
                table: "EnterpriseManagers");

            migrationBuilder.RenameTable(
                name: "EnterpriseManagers",
                newName: "EnterpriseManager");

            migrationBuilder.RenameIndex(
                name: "IX_EnterpriseManagers_EnterpriseId",
                table: "EnterpriseManager",
                newName: "IX_EnterpriseManager_EnterpriseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnterpriseManager",
                table: "EnterpriseManager",
                columns: new[] { "ManagerId", "EnterpriseId" });

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
                    { 9, null, 3, "Jared", "Doe", 6000m },
                    { 10, null, null, "Jocelyn", "Doe", 6500m }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "Cost", "EnterpriseId", "ManufactureLand", "ManufactureYear", "Mileage", "MotorVIN", "VehicleBrandId" },
                values: new object[,]
                {
                    { 1, 20000m, 1, "Japan", 2020, 15000m, "1HGBH41JXMN109186", 1 },
                    { 2, 100000m, 1, "Sweden", 2019, 50000m, "2VOLVOB7R0MN10918", 2 },
                    { 3, 120000m, 1, "Sweden", 2018, 20000m, "3SCANPSE0MN109187", 3 },
                    { 4, 110000m, 1, "Germany", 2021, 30000m, "4MBNZCTR0MN109186", 4 },
                    { 5, 30000m, 1, "USA", 2022, 10000m, "5FORDTRN0MN109185", 5 },
                    { 6, 22000m, 2, "Japan", 2020, 12000m, "6HGBH41JXMN209186", 1 },
                    { 7, 105000m, 2, "Sweden", 2019, 55000m, "7VOLVOB7R1MN20918", 2 },
                    { 8, 125000m, 2, "Sweden", 2018, 22000m, "8SCANPSE1MN209187", 3 },
                    { 9, 115000m, 2, "Germany", 2021, 32000m, "9MBNZCTR1MN209186", 4 },
                    { 10, 32000m, 3, "USA", 2022, 11000m, "0FORDTRN1MN209185", 5 },
                    { 11, 23000m, 3, "Japan", 2020, 13000m, "1HGBH41JXMN309186", 1 },
                    { 12, 110000m, 3, "Sweden", 2019, 60000m, "2VOLVOB7R2MN30918", 2 },
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
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 5 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
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

            migrationBuilder.AddForeignKey(
                name: "FK_EnterpriseManager_Enterprises_EnterpriseId",
                table: "EnterpriseManager",
                column: "EnterpriseId",
                principalTable: "Enterprises",
                principalColumn: "EnterpriseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnterpriseManager_Managers_ManagerId",
                table: "EnterpriseManager",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "ManagerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
