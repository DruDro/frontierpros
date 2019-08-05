using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class RenamedGroupIdColumnToServiceCategoryIdForServiceCategoryAndServiceInfoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCategoryAndServiceInfo_ServiceCategory_GroupId",
                table: "ServiceCategoryAndServiceInfo");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "ServiceCategoryAndServiceInfo",
                newName: "ServiceCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceCategoryAndServiceInfo_GroupId",
                table: "ServiceCategoryAndServiceInfo",
                newName: "IX_ServiceCategoryAndServiceInfo_ServiceCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCategoryAndServiceInfo_ServiceCategory_ServiceCategoryId",
                table: "ServiceCategoryAndServiceInfo",
                column: "ServiceCategoryId",
                principalTable: "ServiceCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCategoryAndServiceInfo_ServiceCategory_ServiceCategoryId",
                table: "ServiceCategoryAndServiceInfo");

            migrationBuilder.RenameColumn(
                name: "ServiceCategoryId",
                table: "ServiceCategoryAndServiceInfo",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceCategoryAndServiceInfo_ServiceCategoryId",
                table: "ServiceCategoryAndServiceInfo",
                newName: "IX_ServiceCategoryAndServiceInfo_GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCategoryAndServiceInfo_ServiceCategory_GroupId",
                table: "ServiceCategoryAndServiceInfo",
                column: "GroupId",
                principalTable: "ServiceCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
