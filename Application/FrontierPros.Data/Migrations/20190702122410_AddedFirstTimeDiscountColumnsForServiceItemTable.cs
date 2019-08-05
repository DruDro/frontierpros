using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class AddedFirstTimeDiscountColumnsForServiceItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FirstTimeDiscountEnabled",
                table: "ServiceItem",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "FirstTimeDiscountValue",
                table: "ServiceItem",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstTimeDiscountEnabled",
                table: "ServiceItem");

            migrationBuilder.DropColumn(
                name: "FirstTimeDiscountValue",
                table: "ServiceItem");
        }
    }
}
