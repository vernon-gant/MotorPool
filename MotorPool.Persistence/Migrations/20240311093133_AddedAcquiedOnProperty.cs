using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorPool.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedAcquiedOnProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Enterprises_EnterpriseId",
                table: "Vehicles");

            migrationBuilder.AlterColumn<int>(
                name: "EnterpriseId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AcquiredOn",
                table: "Vehicles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Enterprises",
                keyColumn: "EnterpriseId",
                keyValue: 6,
                column: "TimeZoneId",
                value: "Etc/UTC");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Enterprises_EnterpriseId",
                table: "Vehicles",
                column: "EnterpriseId",
                principalTable: "Enterprises",
                principalColumn: "EnterpriseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Enterprises_EnterpriseId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "AcquiredOn",
                table: "Vehicles");

            migrationBuilder.AlterColumn<int>(
                name: "EnterpriseId",
                table: "Vehicles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Enterprises",
                keyColumn: "EnterpriseId",
                keyValue: 6,
                column: "TimeZoneId",
                value: "Europe/Berlin");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Enterprises_EnterpriseId",
                table: "Vehicles",
                column: "EnterpriseId",
                principalTable: "Enterprises",
                principalColumn: "EnterpriseId");
        }
    }
}
