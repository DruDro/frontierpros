using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class RenamedCategoryInfoTableToServiceInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addon_CategoryInfo_CategoryInfoId",
                table: "Addon");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryInfo_Category_CategoryId",
                table: "CategoryInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryNameToken_CategoryInfo_CategoryInfoId",
                table: "CategoryNameToken");

            migrationBuilder.DropForeignKey(
                name: "FK_ProviderQuestion_CategoryInfo_CategoryInfoId",
                table: "ProviderQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_CategoryInfo_CategoryInfoId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_CategoryInfo_CategoryInfoId",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCategoryAndServiceInfo_CategoryInfo_CategoryInfoId",
                table: "ServiceCategoryAndServiceInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialty_CategoryInfo_CategoryInfoId",
                table: "Specialty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryInfo",
                table: "CategoryInfo");

            migrationBuilder.RenameTable(
                name: "CategoryInfo",
                newName: "ServiceInfo");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryInfo_CategoryId",
                table: "ServiceInfo",
                newName: "IX_ServiceInfo_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceInfo",
                table: "ServiceInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addon_ServiceInfo_CategoryInfoId",
                table: "Addon",
                column: "CategoryInfoId",
                principalTable: "ServiceInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryNameToken_ServiceInfo_CategoryInfoId",
                table: "CategoryNameToken",
                column: "CategoryInfoId",
                principalTable: "ServiceInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderQuestion_ServiceInfo_CategoryInfoId",
                table: "ProviderQuestion",
                column: "CategoryInfoId",
                principalTable: "ServiceInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_ServiceInfo_CategoryInfoId",
                table: "Question",
                column: "CategoryInfoId",
                principalTable: "ServiceInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_ServiceInfo_CategoryInfoId",
                table: "Service",
                column: "CategoryInfoId",
                principalTable: "ServiceInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCategoryAndServiceInfo_ServiceInfo_CategoryInfoId",
                table: "ServiceCategoryAndServiceInfo",
                column: "CategoryInfoId",
                principalTable: "ServiceInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceInfo_Category_CategoryId",
                table: "ServiceInfo",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Specialty_ServiceInfo_CategoryInfoId",
                table: "Specialty",
                column: "CategoryInfoId",
                principalTable: "ServiceInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addon_ServiceInfo_CategoryInfoId",
                table: "Addon");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryNameToken_ServiceInfo_CategoryInfoId",
                table: "CategoryNameToken");

            migrationBuilder.DropForeignKey(
                name: "FK_ProviderQuestion_ServiceInfo_CategoryInfoId",
                table: "ProviderQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_ServiceInfo_CategoryInfoId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_ServiceInfo_CategoryInfoId",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCategoryAndServiceInfo_ServiceInfo_CategoryInfoId",
                table: "ServiceCategoryAndServiceInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceInfo_Category_CategoryId",
                table: "ServiceInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialty_ServiceInfo_CategoryInfoId",
                table: "Specialty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceInfo",
                table: "ServiceInfo");

            migrationBuilder.RenameTable(
                name: "ServiceInfo",
                newName: "CategoryInfo");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceInfo_CategoryId",
                table: "CategoryInfo",
                newName: "IX_CategoryInfo_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryInfo",
                table: "CategoryInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addon_CategoryInfo_CategoryInfoId",
                table: "Addon",
                column: "CategoryInfoId",
                principalTable: "CategoryInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryInfo_Category_CategoryId",
                table: "CategoryInfo",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryNameToken_CategoryInfo_CategoryInfoId",
                table: "CategoryNameToken",
                column: "CategoryInfoId",
                principalTable: "CategoryInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderQuestion_CategoryInfo_CategoryInfoId",
                table: "ProviderQuestion",
                column: "CategoryInfoId",
                principalTable: "CategoryInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_CategoryInfo_CategoryInfoId",
                table: "Question",
                column: "CategoryInfoId",
                principalTable: "CategoryInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_CategoryInfo_CategoryInfoId",
                table: "Service",
                column: "CategoryInfoId",
                principalTable: "CategoryInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCategoryAndServiceInfo_CategoryInfo_CategoryInfoId",
                table: "ServiceCategoryAndServiceInfo",
                column: "CategoryInfoId",
                principalTable: "CategoryInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Specialty_CategoryInfo_CategoryInfoId",
                table: "Specialty",
                column: "CategoryInfoId",
                principalTable: "CategoryInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
