using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class AddedPaidAndOrderCoulumnsForQuestionAndQuestionSourceTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPaidQuestion",
                table: "QuestionSource",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "QuestionSource",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsPaidQuestion",
                table: "Question",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Question",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPaidQuestion",
                table: "QuestionSource");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "QuestionSource");

            migrationBuilder.DropColumn(
                name: "IsPaidQuestion",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Question");
        }
    }
}
