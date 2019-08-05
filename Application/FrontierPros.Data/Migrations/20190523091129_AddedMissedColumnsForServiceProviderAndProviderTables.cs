using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class AddedMissedColumnsForServiceProviderAndProviderTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ServiceProvider",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Provider",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "ServiceProvider");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Provider");
        }
    }
}
