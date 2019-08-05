using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class RenamedCategoryGroupTableToServiceCategoryAndServiceInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryGroup_CategoryInfo_CategoryInfoId",
                table: "CategoryGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryGroup_ServiceCategory_GroupId",
                table: "CategoryGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryGroup",
                table: "CategoryGroup");

            migrationBuilder.RenameTable(
                name: "CategoryGroup",
                newName: "ServiceCategoryAndServiceInfo");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryGroup_GroupId",
                table: "ServiceCategoryAndServiceInfo",
                newName: "IX_ServiceCategoryAndServiceInfo_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryGroup_CategoryInfoId",
                table: "ServiceCategoryAndServiceInfo",
                newName: "IX_ServiceCategoryAndServiceInfo_CategoryInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceCategoryAndServiceInfo",
                table: "ServiceCategoryAndServiceInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCategoryAndServiceInfo_CategoryInfo_CategoryInfoId",
                table: "ServiceCategoryAndServiceInfo",
                column: "CategoryInfoId",
                principalTable: "CategoryInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCategoryAndServiceInfo_ServiceCategory_GroupId",
                table: "ServiceCategoryAndServiceInfo",
                column: "GroupId",
                principalTable: "ServiceCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCategoryAndServiceInfo_CategoryInfo_CategoryInfoId",
                table: "ServiceCategoryAndServiceInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCategoryAndServiceInfo_ServiceCategory_GroupId",
                table: "ServiceCategoryAndServiceInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceCategoryAndServiceInfo",
                table: "ServiceCategoryAndServiceInfo");

            migrationBuilder.RenameTable(
                name: "ServiceCategoryAndServiceInfo",
                newName: "CategoryGroup");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceCategoryAndServiceInfo_GroupId",
                table: "CategoryGroup",
                newName: "IX_CategoryGroup_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceCategoryAndServiceInfo_CategoryInfoId",
                table: "CategoryGroup",
                newName: "IX_CategoryGroup_CategoryInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryGroup",
                table: "CategoryGroup",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryGroup_CategoryInfo_CategoryInfoId",
                table: "CategoryGroup",
                column: "CategoryInfoId",
                principalTable: "CategoryInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryGroup_ServiceCategory_GroupId",
                table: "CategoryGroup",
                column: "GroupId",
                principalTable: "ServiceCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
