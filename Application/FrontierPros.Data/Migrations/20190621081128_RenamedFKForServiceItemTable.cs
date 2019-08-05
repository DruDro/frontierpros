using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class RenamedFKForServiceItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoverageArea_ServiceItem_ServiceId",
                table: "CoverageArea");

            migrationBuilder.DropForeignKey(
                name: "FK_ProviderOptionPrice_ServiceItem_ServiceId",
                table: "ProviderOptionPrice");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "ProviderOptionPrice",
                newName: "ServiceItemId");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderOptionPrice_ServiceId",
                table: "ProviderOptionPrice",
                newName: "IX_ProviderOptionPrice_ServiceItemId");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "CoverageArea",
                newName: "ServiceItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CoverageArea_ServiceId",
                table: "CoverageArea",
                newName: "IX_CoverageArea_ServiceItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoverageArea_ServiceItem_ServiceItemId",
                table: "CoverageArea",
                column: "ServiceItemId",
                principalTable: "ServiceItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderOptionPrice_ServiceItem_ServiceItemId",
                table: "ProviderOptionPrice",
                column: "ServiceItemId",
                principalTable: "ServiceItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoverageArea_ServiceItem_ServiceItemId",
                table: "CoverageArea");

            migrationBuilder.DropForeignKey(
                name: "FK_ProviderOptionPrice_ServiceItem_ServiceItemId",
                table: "ProviderOptionPrice");

            migrationBuilder.RenameColumn(
                name: "ServiceItemId",
                table: "ProviderOptionPrice",
                newName: "ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderOptionPrice_ServiceItemId",
                table: "ProviderOptionPrice",
                newName: "IX_ProviderOptionPrice_ServiceId");

            migrationBuilder.RenameColumn(
                name: "ServiceItemId",
                table: "CoverageArea",
                newName: "ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_CoverageArea_ServiceItemId",
                table: "CoverageArea",
                newName: "IX_CoverageArea_ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoverageArea_ServiceItem_ServiceId",
                table: "CoverageArea",
                column: "ServiceId",
                principalTable: "ServiceItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderOptionPrice_ServiceItem_ServiceId",
                table: "ProviderOptionPrice",
                column: "ServiceId",
                principalTable: "ServiceItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
