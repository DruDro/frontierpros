using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class AddedDescriptionForCustomerMediaFileAndServiceItemMediaFileTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "tblServiceItemMediaFile",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "tblCustomerMediaFile",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "tblServiceItemMediaFile");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "tblCustomerMediaFile");
        }
    }
}
