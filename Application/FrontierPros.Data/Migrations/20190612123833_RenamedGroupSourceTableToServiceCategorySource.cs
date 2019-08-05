using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class RenamedGroupSourceTableToServiceCategorySource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryGroupSource_GroupSource_GroupSourceId",
                table: "CategoryGroupSource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupSource",
                table: "GroupSource");

            migrationBuilder.RenameTable(
                name: "GroupSource",
                newName: "ServiceCategorySource");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceCategorySource",
                table: "ServiceCategorySource",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryGroupSource_ServiceCategorySource_GroupSourceId",
                table: "CategoryGroupSource",
                column: "GroupSourceId",
                principalTable: "ServiceCategorySource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryGroupSource_ServiceCategorySource_GroupSourceId",
                table: "CategoryGroupSource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceCategorySource",
                table: "ServiceCategorySource");

            migrationBuilder.RenameTable(
                name: "ServiceCategorySource",
                newName: "GroupSource");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupSource",
                table: "GroupSource",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryGroupSource_GroupSource_GroupSourceId",
                table: "CategoryGroupSource",
                column: "GroupSourceId",
                principalTable: "GroupSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
