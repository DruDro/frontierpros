using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class AddedIsServiceLocationForServiceItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DistanceTravel",
                table: "ServiceItem");

            migrationBuilder.AddColumn<bool>(
                name: "IsServiceLocation",
                table: "CoverageArea",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsServiceLocation",
                table: "CoverageArea");

            migrationBuilder.AddColumn<int>(
                name: "DistanceTravel",
                table: "ServiceItem",
                nullable: false,
                defaultValue: 0);
        }
    }
}
