using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class RenamedCategoryInfoIdColumnToServiceInfoIfForServiceCategoryAndServiceInfoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCategoryAndServiceInfo_ServiceInfo_CategoryInfoId",
                table: "ServiceCategoryAndServiceInfo");

            migrationBuilder.RenameColumn(
                name: "CategoryInfoId",
                table: "ServiceCategoryAndServiceInfo",
                newName: "ServiceInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceCategoryAndServiceInfo_CategoryInfoId",
                table: "ServiceCategoryAndServiceInfo",
                newName: "IX_ServiceCategoryAndServiceInfo_ServiceInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCategoryAndServiceInfo_ServiceInfo_ServiceInfoId",
                table: "ServiceCategoryAndServiceInfo",
                column: "ServiceInfoId",
                principalTable: "ServiceInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCategoryAndServiceInfo_ServiceInfo_ServiceInfoId",
                table: "ServiceCategoryAndServiceInfo");

            migrationBuilder.RenameColumn(
                name: "ServiceInfoId",
                table: "ServiceCategoryAndServiceInfo",
                newName: "CategoryInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceCategoryAndServiceInfo_ServiceInfoId",
                table: "ServiceCategoryAndServiceInfo",
                newName: "IX_ServiceCategoryAndServiceInfo_CategoryInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCategoryAndServiceInfo_ServiceInfo_CategoryInfoId",
                table: "ServiceCategoryAndServiceInfo",
                column: "CategoryInfoId",
                principalTable: "ServiceInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
