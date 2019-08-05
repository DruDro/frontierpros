using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class ChangeDataTypeForLatitudeAndLongitude : Migration
    {
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<double>(
				name: "Longitude",
				table: "CoverageArea",
				nullable: false,
				oldClrType: typeof(decimal),
				oldType: "decimal(11,8)");

			migrationBuilder.AlterColumn<double>(
				name: "Latitude",
				table: "CoverageArea",
				nullable: false,
				oldClrType: typeof(decimal),
				oldType: "decimal(10,8)");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<decimal>(
				name: "Longitude",
				table: "CoverageArea",
				type: "decimal(11,8)",
				nullable: false,
				oldClrType: typeof(double));

			migrationBuilder.AlterColumn<decimal>(
				name: "Latitude",
				table: "CoverageArea",
				type: "decimal(10,8)",
				nullable: false,
				oldClrType: typeof(double));
		}
	}
}
