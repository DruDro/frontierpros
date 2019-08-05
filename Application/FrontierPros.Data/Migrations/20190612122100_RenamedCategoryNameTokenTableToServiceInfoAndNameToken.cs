using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class RenamedCategoryNameTokenTableToServiceInfoAndNameToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryNameToken_ServiceInfo_CategoryInfoId",
                table: "CategoryNameToken");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryNameToken_NameToken_NameTokenId",
                table: "CategoryNameToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryNameToken",
                table: "CategoryNameToken");

            migrationBuilder.RenameTable(
                name: "CategoryNameToken",
                newName: "ServiceInfoAndNameToken");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryNameToken_NameTokenId",
                table: "ServiceInfoAndNameToken",
                newName: "IX_ServiceInfoAndNameToken_NameTokenId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryNameToken_CategoryInfoId",
                table: "ServiceInfoAndNameToken",
                newName: "IX_ServiceInfoAndNameToken_CategoryInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceInfoAndNameToken",
                table: "ServiceInfoAndNameToken",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceInfoAndNameToken_ServiceInfo_CategoryInfoId",
                table: "ServiceInfoAndNameToken",
                column: "CategoryInfoId",
                principalTable: "ServiceInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceInfoAndNameToken_NameToken_NameTokenId",
                table: "ServiceInfoAndNameToken",
                column: "NameTokenId",
                principalTable: "NameToken",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceInfoAndNameToken_ServiceInfo_CategoryInfoId",
                table: "ServiceInfoAndNameToken");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceInfoAndNameToken_NameToken_NameTokenId",
                table: "ServiceInfoAndNameToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceInfoAndNameToken",
                table: "ServiceInfoAndNameToken");

            migrationBuilder.RenameTable(
                name: "ServiceInfoAndNameToken",
                newName: "CategoryNameToken");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceInfoAndNameToken_NameTokenId",
                table: "CategoryNameToken",
                newName: "IX_CategoryNameToken_NameTokenId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceInfoAndNameToken_CategoryInfoId",
                table: "CategoryNameToken",
                newName: "IX_CategoryNameToken_CategoryInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryNameToken",
                table: "CategoryNameToken",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryNameToken_ServiceInfo_CategoryInfoId",
                table: "CategoryNameToken",
                column: "CategoryInfoId",
                principalTable: "ServiceInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryNameToken_NameToken_NameTokenId",
                table: "CategoryNameToken",
                column: "NameTokenId",
                principalTable: "NameToken",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
