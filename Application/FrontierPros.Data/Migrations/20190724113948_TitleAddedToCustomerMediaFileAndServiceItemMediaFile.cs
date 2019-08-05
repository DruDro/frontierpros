using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class TitleAddedToCustomerMediaFileAndServiceItemMediaFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "tblServiceItemMediaFile",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "tblCustomerMediaFile",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "tblServiceItemMediaFile");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "tblCustomerMediaFile");
        }
    }
}
