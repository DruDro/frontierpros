using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class AddProviderQuestionsAndOptionsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProviderQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Heading = table.Column<string>(nullable: true),
                    SubHeading = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    IsStartQuestion = table.Column<bool>(nullable: false),
                    IsRequired = table.Column<bool>(nullable: false),
                    CategoryInfoId = table.Column<int>(nullable: false),
                    NextQuestionId = table.Column<int>(nullable: true),
                    ClientQuestionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProviderQuestion_CategoryInfo_CategoryInfoId",
                        column: x => x.CategoryInfoId,
                        principalTable: "CategoryInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProviderQuestion_Question_ClientQuestionId",
                        column: x => x.ClientQuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProviderQuestion_ProviderQuestion_NextQuestionId",
                        column: x => x.NextQuestionId,
                        principalTable: "ProviderQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProviderOption",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    SpecialtyId = table.Column<int>(nullable: true),
                    QuestionId = table.Column<int>(nullable: true),
                    ClientOptionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProviderOption_Option_ClientOptionId",
                        column: x => x.ClientOptionId,
                        principalTable: "Option",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProviderOption_ProviderQuestion_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "ProviderQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProviderOption_Specialty_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProviderOption_ClientOptionId",
                table: "ProviderOption",
                column: "ClientOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderOption_QuestionId",
                table: "ProviderOption",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderOption_SpecialtyId",
                table: "ProviderOption",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderQuestion_CategoryInfoId",
                table: "ProviderQuestion",
                column: "CategoryInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderQuestion_ClientQuestionId",
                table: "ProviderQuestion",
                column: "ClientQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderQuestion_NextQuestionId",
                table: "ProviderQuestion",
                column: "NextQuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProviderOption");

            migrationBuilder.DropTable(
                name: "ProviderQuestion");
        }
    }
}
