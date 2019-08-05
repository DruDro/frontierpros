using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class RenamedCategoryInfoSourceTableToServiceInfoSource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddonSource_CategoryInfoSource_CategoryInfoSourceId",
                table: "AddonSource");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryGroupSource_CategoryInfoSource_CategoryInfoSourceId",
                table: "CategoryGroupSource");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryNameTokenSource_CategoryInfoSource_CategoryInfoSourceId",
                table: "CategoryNameTokenSource");

            migrationBuilder.DropForeignKey(
                name: "FK_ProviderQuestionSource_CategoryInfoSource_CategoryInfoSourceId",
                table: "ProviderQuestionSource");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionSource_CategoryInfoSource_CategoryInfoSourceId",
                table: "QuestionSource");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialtySource_CategoryInfoSource_CategoryInfoSourceId",
                table: "SpecialtySource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryInfoSource",
                table: "CategoryInfoSource");

            migrationBuilder.RenameTable(
                name: "CategoryInfoSource",
                newName: "ServiceInfoSource");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceInfoSource",
                table: "ServiceInfoSource",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AddonSource_ServiceInfoSource_CategoryInfoSourceId",
                table: "AddonSource",
                column: "CategoryInfoSourceId",
                principalTable: "ServiceInfoSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryGroupSource_ServiceInfoSource_CategoryInfoSourceId",
                table: "CategoryGroupSource",
                column: "CategoryInfoSourceId",
                principalTable: "ServiceInfoSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryNameTokenSource_ServiceInfoSource_CategoryInfoSourceId",
                table: "CategoryNameTokenSource",
                column: "CategoryInfoSourceId",
                principalTable: "ServiceInfoSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderQuestionSource_ServiceInfoSource_CategoryInfoSourceId",
                table: "ProviderQuestionSource",
                column: "CategoryInfoSourceId",
                principalTable: "ServiceInfoSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionSource_ServiceInfoSource_CategoryInfoSourceId",
                table: "QuestionSource",
                column: "CategoryInfoSourceId",
                principalTable: "ServiceInfoSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialtySource_ServiceInfoSource_CategoryInfoSourceId",
                table: "SpecialtySource",
                column: "CategoryInfoSourceId",
                principalTable: "ServiceInfoSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddonSource_ServiceInfoSource_CategoryInfoSourceId",
                table: "AddonSource");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryGroupSource_ServiceInfoSource_CategoryInfoSourceId",
                table: "CategoryGroupSource");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryNameTokenSource_ServiceInfoSource_CategoryInfoSourceId",
                table: "CategoryNameTokenSource");

            migrationBuilder.DropForeignKey(
                name: "FK_ProviderQuestionSource_ServiceInfoSource_CategoryInfoSourceId",
                table: "ProviderQuestionSource");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionSource_ServiceInfoSource_CategoryInfoSourceId",
                table: "QuestionSource");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialtySource_ServiceInfoSource_CategoryInfoSourceId",
                table: "SpecialtySource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceInfoSource",
                table: "ServiceInfoSource");

            migrationBuilder.RenameTable(
                name: "ServiceInfoSource",
                newName: "CategoryInfoSource");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryInfoSource",
                table: "CategoryInfoSource",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AddonSource_CategoryInfoSource_CategoryInfoSourceId",
                table: "AddonSource",
                column: "CategoryInfoSourceId",
                principalTable: "CategoryInfoSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryGroupSource_CategoryInfoSource_CategoryInfoSourceId",
                table: "CategoryGroupSource",
                column: "CategoryInfoSourceId",
                principalTable: "CategoryInfoSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryNameTokenSource_CategoryInfoSource_CategoryInfoSourceId",
                table: "CategoryNameTokenSource",
                column: "CategoryInfoSourceId",
                principalTable: "CategoryInfoSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderQuestionSource_CategoryInfoSource_CategoryInfoSourceId",
                table: "ProviderQuestionSource",
                column: "CategoryInfoSourceId",
                principalTable: "CategoryInfoSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionSource_CategoryInfoSource_CategoryInfoSourceId",
                table: "QuestionSource",
                column: "CategoryInfoSourceId",
                principalTable: "CategoryInfoSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialtySource_CategoryInfoSource_CategoryInfoSourceId",
                table: "SpecialtySource",
                column: "CategoryInfoSourceId",
                principalTable: "CategoryInfoSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
