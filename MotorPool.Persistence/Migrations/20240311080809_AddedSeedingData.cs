using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorPool.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Enterprises",
                keyColumn: "EnterpriseId",
                keyValue: 1,
                columns: new[] { "Name", "TimeZoneId" },
                values: new object[] { "Garosh industries", "America/New_York" });

            migrationBuilder.UpdateData(
                table: "Enterprises",
                keyColumn: "EnterpriseId",
                keyValue: 2,
                columns: new[] { "Name", "TimeZoneId" },
                values: new object[] { "Apple", "America/Los_Angeles" });

            migrationBuilder.UpdateData(
                table: "Enterprises",
                keyColumn: "EnterpriseId",
                keyValue: 3,
                columns: new[] { "Name", "TimeZoneId" },
                values: new object[] { "Microsoft", "America/Chicago" });

            migrationBuilder.UpdateData(
                table: "Enterprises",
                keyColumn: "EnterpriseId",
                keyValue: 4,
                columns: new[] { "Name", "TimeZoneId" },
                values: new object[] { "Amazon", "America/Chicago" });

            migrationBuilder.UpdateData(
                table: "Enterprises",
                keyColumn: "EnterpriseId",
                keyValue: 5,
                columns: new[] { "City", "Name", "Street", "TimeZoneId", "VAT" },
                values: new object[] { "Vladimir", "Tochmash", "Severnaya Street", "Europe/Moscow", "RU789456123" });

            migrationBuilder.InsertData(
                table: "Enterprises",
                columns: new[] { "EnterpriseId", "City", "FoundedOn", "Name", "Street", "TimeZoneId", "VAT" },
                values: new object[] { 6, "Berlin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SAP", "Wehlistrasse", "Europe/Berlin", "DE3242354325" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Enterprises",
                keyColumn: "EnterpriseId",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Enterprises",
                keyColumn: "EnterpriseId",
                keyValue: 1,
                columns: new[] { "Name", "TimeZoneId" },
                values: new object[] { "MotorPool", "" });

            migrationBuilder.UpdateData(
                table: "Enterprises",
                keyColumn: "EnterpriseId",
                keyValue: 2,
                columns: new[] { "Name", "TimeZoneId" },
                values: new object[] { "MotorPool", "" });

            migrationBuilder.UpdateData(
                table: "Enterprises",
                keyColumn: "EnterpriseId",
                keyValue: 3,
                columns: new[] { "Name", "TimeZoneId" },
                values: new object[] { "MotorPool", "" });

            migrationBuilder.UpdateData(
                table: "Enterprises",
                keyColumn: "EnterpriseId",
                keyValue: 4,
                columns: new[] { "Name", "TimeZoneId" },
                values: new object[] { "MotorPool", "" });

            migrationBuilder.UpdateData(
                table: "Enterprises",
                keyColumn: "EnterpriseId",
                keyValue: 5,
                columns: new[] { "City", "Name", "Street", "TimeZoneId", "VAT" },
                values: new object[] { "Philadelphia", "MotorPool", "Benjamin Franklin Parkway", "", "US789456123" });
        }
    }
}
