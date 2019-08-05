using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class AddedColumnsToEnableDiscountRates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OneMonthDiscountEnabled",
                table: "tblDiscountRate",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SixMonthDiscountEnabled",
                table: "tblDiscountRate",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TreeMonthDiscountEnabled",
                table: "tblDiscountRate",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TwelveMonthDiscountEnabled",
                table: "tblDiscountRate",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OneMonthDiscountEnabled",
                table: "tblDiscountRate");

            migrationBuilder.DropColumn(
                name: "SixMonthDiscountEnabled",
                table: "tblDiscountRate");

            migrationBuilder.DropColumn(
                name: "TreeMonthDiscountEnabled",
                table: "tblDiscountRate");

            migrationBuilder.DropColumn(
                name: "TwelveMonthDiscountEnabled",
                table: "tblDiscountRate");
        }
    }
}
