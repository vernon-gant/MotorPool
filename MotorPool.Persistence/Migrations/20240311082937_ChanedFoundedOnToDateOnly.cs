using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorPool.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChanedFoundedOnToDateOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "FoundedOn",
                table: "Enterprises",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Enterprises",
                keyColumn: "EnterpriseId",
                keyValue: 1,
                column: "FoundedOn",
                value: new DateOnly(2012, 1, 1));

            migrationBuilder.UpdateData(
                table: "Enterprises",
                keyColumn: "EnterpriseId",
                keyValue: 2,
                column: "FoundedOn",
                value: new DateOnly(2006, 4, 1));

            migrationBuilder.UpdateData(
                table: "Enterprises",
                keyColumn: "EnterpriseId",
                keyValue: 3,
                column: "FoundedOn",
                value: new DateOnly(2000, 4, 4));

            migrationBuilder.UpdateData(
                table: "Enterprises",
                keyColumn: "EnterpriseId",
                keyValue: 4,
                column: "FoundedOn",
                value: new DateOnly(1994, 7, 5));

            migrationBuilder.UpdateData(
                table: "Enterprises",
                keyColumn: "EnterpriseId",
                keyValue: 5,
                column: "FoundedOn",
                value: new DateOnly(1950, 1, 1));

            migrationBuilder.UpdateData(
                table: "Enterprises",
                keyColumn: "EnterpriseId",
                keyValue: 6,
                column: "FoundedOn",
                value: new DateOnly(1990, 4, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FoundedOn",
                table: "Enterprises",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "Enterprises",
                keyColumn: "EnterpriseId",
                keyValue: 1,
                column: "FoundedOn",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Enterprises",
                keyColumn: "EnterpriseId",
                keyValue: 2,
                column: "FoundedOn",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Enterprises",
                keyColumn: "EnterpriseId",
                keyValue: 3,
                column: "FoundedOn",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Enterprises",
                keyColumn: "EnterpriseId",
                keyValue: 4,
                column: "FoundedOn",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Enterprises",
                keyColumn: "EnterpriseId",
                keyValue: 5,
                column: "FoundedOn",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Enterprises",
                keyColumn: "EnterpriseId",
                keyValue: 6,
                column: "FoundedOn",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
