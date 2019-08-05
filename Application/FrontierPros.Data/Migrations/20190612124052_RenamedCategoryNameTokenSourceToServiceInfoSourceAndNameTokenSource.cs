using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class RenamedCategoryNameTokenSourceToServiceInfoSourceAndNameTokenSource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryNameTokenSource_ServiceInfoSource_CategoryInfoSourceId",
                table: "CategoryNameTokenSource");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryNameTokenSource_NameTokenSource_NameTokenSourceId",
                table: "CategoryNameTokenSource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryNameTokenSource",
                table: "CategoryNameTokenSource");

            migrationBuilder.RenameTable(
                name: "CategoryNameTokenSource",
                newName: "ServiceInfoSourceAndNameTokenSource");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryNameTokenSource_NameTokenSourceId",
                table: "ServiceInfoSourceAndNameTokenSource",
                newName: "IX_ServiceInfoSourceAndNameTokenSource_NameTokenSourceId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryNameTokenSource_CategoryInfoSourceId",
                table: "ServiceInfoSourceAndNameTokenSource",
                newName: "IX_ServiceInfoSourceAndNameTokenSource_CategoryInfoSourceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceInfoSourceAndNameTokenSource",
                table: "ServiceInfoSourceAndNameTokenSource",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceInfoSourceAndNameTokenSource_ServiceInfoSource_CategoryInfoSourceId",
                table: "ServiceInfoSourceAndNameTokenSource",
                column: "CategoryInfoSourceId",
                principalTable: "ServiceInfoSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceInfoSourceAndNameTokenSource_NameTokenSource_NameTokenSourceId",
                table: "ServiceInfoSourceAndNameTokenSource",
                column: "NameTokenSourceId",
                principalTable: "NameTokenSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceInfoSourceAndNameTokenSource_ServiceInfoSource_CategoryInfoSourceId",
                table: "ServiceInfoSourceAndNameTokenSource");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceInfoSourceAndNameTokenSource_NameTokenSource_NameTokenSourceId",
                table: "ServiceInfoSourceAndNameTokenSource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceInfoSourceAndNameTokenSource",
                table: "ServiceInfoSourceAndNameTokenSource");

            migrationBuilder.RenameTable(
                name: "ServiceInfoSourceAndNameTokenSource",
                newName: "CategoryNameTokenSource");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceInfoSourceAndNameTokenSource_NameTokenSourceId",
                table: "CategoryNameTokenSource",
                newName: "IX_CategoryNameTokenSource_NameTokenSourceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceInfoSourceAndNameTokenSource_CategoryInfoSourceId",
                table: "CategoryNameTokenSource",
                newName: "IX_CategoryNameTokenSource_CategoryInfoSourceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryNameTokenSource",
                table: "CategoryNameTokenSource",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryNameTokenSource_ServiceInfoSource_CategoryInfoSourceId",
                table: "CategoryNameTokenSource",
                column: "CategoryInfoSourceId",
                principalTable: "ServiceInfoSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryNameTokenSource_NameTokenSource_NameTokenSourceId",
                table: "CategoryNameTokenSource",
                column: "NameTokenSourceId",
                principalTable: "NameTokenSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
