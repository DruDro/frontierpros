using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class AddedProviderColumnsForQuestionAndOptionTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsProviderQuestion",
                table: "QuestionSource",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ProviderHeading",
                table: "QuestionSource",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProviderSubHeading",
                table: "QuestionSource",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsProviderQuestion",
                table: "Question",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ProviderHeading",
                table: "Question",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProviderSubHeading",
                table: "Question",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProviderText",
                table: "OptionSource",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProviderText",
                table: "Option",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsProviderQuestion",
                table: "QuestionSource");

            migrationBuilder.DropColumn(
                name: "ProviderHeading",
                table: "QuestionSource");

            migrationBuilder.DropColumn(
                name: "ProviderSubHeading",
                table: "QuestionSource");

            migrationBuilder.DropColumn(
                name: "IsProviderQuestion",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "ProviderHeading",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "ProviderSubHeading",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "ProviderText",
                table: "OptionSource");

            migrationBuilder.DropColumn(
                name: "ProviderText",
                table: "Option");
        }
    }
}
