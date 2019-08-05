using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class AddCategoryInfoColumnToQuestionAndSpecialtyTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryInfoId",
                table: "Specialty",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryInfoId",
                table: "Question",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Specialty_CategoryInfoId",
                table: "Specialty",
                column: "CategoryInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_CategoryInfoId",
                table: "Question",
                column: "CategoryInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_CategoryInfo_CategoryInfoId",
                table: "Question",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_CategoryInfo_CategoryInfoId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialty_CategoryInfo_CategoryInfoId",
                table: "Specialty");

            migrationBuilder.DropIndex(
                name: "IX_Specialty_CategoryInfoId",
                table: "Specialty");

            migrationBuilder.DropIndex(
                name: "IX_Question_CategoryInfoId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "CategoryInfoId",
                table: "Specialty");

            migrationBuilder.DropColumn(
                name: "CategoryInfoId",
                table: "Question");
        }
    }
}
