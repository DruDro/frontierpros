using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class AddPublishedAndSourceTypeColumnsForCategoryInfoAndGroupTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Published",
                table: "Group",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SourceType",
                table: "Group",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Published",
                table: "CategoryInfo",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SourceType",
                table: "CategoryInfo",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Published",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "SourceType",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "Published",
                table: "CategoryInfo");

            migrationBuilder.DropColumn(
                name: "SourceType",
                table: "CategoryInfo");
        }
    }
}
