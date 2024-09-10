using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorPool.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedTimeZoneId_Enterprise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TimeZoneId",
                table: "Enterprises",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Enterprises",
                keyColumn: "EnterpriseId",
                keyValue: 1,
                column: "TimeZoneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Enterprises",
                keyColumn: "EnterpriseId",
                keyValue: 2,
                column: "TimeZoneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Enterprises",
                keyColumn: "EnterpriseId",
                keyValue: 3,
                column: "TimeZoneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Enterprises",
                keyColumn: "EnterpriseId",
                keyValue: 4,
                column: "TimeZoneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Enterprises",
                keyColumn: "EnterpriseId",
                keyValue: 5,
                column: "TimeZoneId",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeZoneId",
                table: "Enterprises");
        }
    }
}
