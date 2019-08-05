using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class RenamedCategoryGroupSourceToServiceCategorySourceAndServiceInfoSource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryGroupSource_ServiceInfoSource_CategoryInfoSourceId",
                table: "CategoryGroupSource");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryGroupSource_ServiceCategorySource_GroupSourceId",
                table: "CategoryGroupSource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryGroupSource",
                table: "CategoryGroupSource");

            migrationBuilder.RenameTable(
                name: "CategoryGroupSource",
                newName: "ServiceCategorySourceAndServiceInfoSource");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryGroupSource_GroupSourceId",
                table: "ServiceCategorySourceAndServiceInfoSource",
                newName: "IX_ServiceCategorySourceAndServiceInfoSource_GroupSourceId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryGroupSource_CategoryInfoSourceId",
                table: "ServiceCategorySourceAndServiceInfoSource",
                newName: "IX_ServiceCategorySourceAndServiceInfoSource_CategoryInfoSourceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceCategorySourceAndServiceInfoSource",
                table: "ServiceCategorySourceAndServiceInfoSource",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCategorySourceAndServiceInfoSource_ServiceInfoSource_CategoryInfoSourceId",
                table: "ServiceCategorySourceAndServiceInfoSource",
                column: "CategoryInfoSourceId",
                principalTable: "ServiceInfoSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCategorySourceAndServiceInfoSource_ServiceCategorySource_GroupSourceId",
                table: "ServiceCategorySourceAndServiceInfoSource",
                column: "GroupSourceId",
                principalTable: "ServiceCategorySource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCategorySourceAndServiceInfoSource_ServiceInfoSource_CategoryInfoSourceId",
                table: "ServiceCategorySourceAndServiceInfoSource");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCategorySourceAndServiceInfoSource_ServiceCategorySource_GroupSourceId",
                table: "ServiceCategorySourceAndServiceInfoSource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceCategorySourceAndServiceInfoSource",
                table: "ServiceCategorySourceAndServiceInfoSource");

            migrationBuilder.RenameTable(
                name: "ServiceCategorySourceAndServiceInfoSource",
                newName: "CategoryGroupSource");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceCategorySourceAndServiceInfoSource_GroupSourceId",
                table: "CategoryGroupSource",
                newName: "IX_CategoryGroupSource_GroupSourceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceCategorySourceAndServiceInfoSource_CategoryInfoSourceId",
                table: "CategoryGroupSource",
                newName: "IX_CategoryGroupSource_CategoryInfoSourceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryGroupSource",
                table: "CategoryGroupSource",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryGroupSource_ServiceInfoSource_CategoryInfoSourceId",
                table: "CategoryGroupSource",
                column: "CategoryInfoSourceId",
                principalTable: "ServiceInfoSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryGroupSource_ServiceCategorySource_GroupSourceId",
                table: "CategoryGroupSource",
                column: "GroupSourceId",
                principalTable: "ServiceCategorySource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
