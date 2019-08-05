using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class RenamedServiceTableToServiceItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoverageArea_Service_ServiceId",
                table: "CoverageArea");

            migrationBuilder.DropForeignKey(
                name: "FK_ProviderOptionPrice_Service_ServiceId",
                table: "ProviderOptionPrice");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_Product_ProductId",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_Provider_ProviderId",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_ServiceInfo_ServiceInfoId",
                table: "Service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                table: "Service");

            migrationBuilder.RenameTable(
                name: "Service",
                newName: "ServiceItem");

            migrationBuilder.RenameIndex(
                name: "IX_Service_ServiceInfoId",
                table: "ServiceItem",
                newName: "IX_ServiceItem_ServiceInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Service_ProviderId",
                table: "ServiceItem",
                newName: "IX_ServiceItem_ProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_Service_ProductId",
                table: "ServiceItem",
                newName: "IX_ServiceItem_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceItem",
                table: "ServiceItem",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceItem_Product_ProductId",
                table: "ServiceItem",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceItem_Provider_ProviderId",
                table: "ServiceItem",
                column: "ProviderId",
                principalTable: "Provider",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceItem_ServiceInfo_ServiceInfoId",
                table: "ServiceItem",
                column: "ServiceInfoId",
                principalTable: "ServiceInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoverageArea_ServiceItem_ServiceId",
                table: "CoverageArea");

            migrationBuilder.DropForeignKey(
                name: "FK_ProviderOptionPrice_ServiceItem_ServiceId",
                table: "ProviderOptionPrice");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceItem_Product_ProductId",
                table: "ServiceItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceItem_Provider_ProviderId",
                table: "ServiceItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceItem_ServiceInfo_ServiceInfoId",
                table: "ServiceItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceItem",
                table: "ServiceItem");

            migrationBuilder.RenameTable(
                name: "ServiceItem",
                newName: "Service");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceItem_ServiceInfoId",
                table: "Service",
                newName: "IX_Service_ServiceInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceItem_ProviderId",
                table: "Service",
                newName: "IX_Service_ProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceItem_ProductId",
                table: "Service",
                newName: "IX_Service_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service",
                table: "Service",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CoverageArea_Service_ServiceId",
                table: "CoverageArea",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderOptionPrice_Service_ServiceId",
                table: "ProviderOptionPrice",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Product_ProductId",
                table: "Service",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Provider_ProviderId",
                table: "Service",
                column: "ProviderId",
                principalTable: "Provider",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_ServiceInfo_ServiceInfoId",
                table: "Service",
                column: "ServiceInfoId",
                principalTable: "ServiceInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
