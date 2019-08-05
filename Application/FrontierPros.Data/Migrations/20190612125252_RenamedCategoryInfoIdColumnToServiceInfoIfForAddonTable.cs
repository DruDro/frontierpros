using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class RenamedCategoryInfoIdColumnToServiceInfoIfForAddonTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addon_ServiceInfo_CategoryInfoId",
                table: "Addon");

            migrationBuilder.RenameColumn(
                name: "CategoryInfoId",
                table: "Addon",
                newName: "ServiceInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Addon_CategoryInfoId",
                table: "Addon",
                newName: "IX_Addon_ServiceInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addon_ServiceInfo_ServiceInfoId",
                table: "Addon",
                column: "ServiceInfoId",
                principalTable: "ServiceInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addon_ServiceInfo_ServiceInfoId",
                table: "Addon");

            migrationBuilder.RenameColumn(
                name: "ServiceInfoId",
                table: "Addon",
                newName: "CategoryInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Addon_ServiceInfoId",
                table: "Addon",
                newName: "IX_Addon_CategoryInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addon_ServiceInfo_CategoryInfoId",
                table: "Addon",
                column: "CategoryInfoId",
                principalTable: "ServiceInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
