using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class FixedColumnNamesForServiceItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FinishHoursUtc",
                table: "ServiceItem",
                newName: "FinishHours");

            migrationBuilder.RenameColumn(
                name: "BeginHoursUtc",
                table: "ServiceItem",
                newName: "BeginHours");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FinishHours",
                table: "ServiceItem",
                newName: "FinishHoursUtc");

            migrationBuilder.RenameColumn(
                name: "BeginHours",
                table: "ServiceItem",
                newName: "BeginHoursUtc");
        }
    }
}
