using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class ChangedBindingFromProviderOptionsToOptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProviderOptionPrice_ProviderOption_ProviderOptionId",
                table: "ProviderOptionPrice");

            migrationBuilder.DropTable(
                name: "ProviderOption");

            migrationBuilder.DropTable(
                name: "ProviderOptionSource");

            migrationBuilder.DropTable(
                name: "ProviderQuestion");

            migrationBuilder.DropTable(
                name: "ProviderQuestionSource");

            migrationBuilder.RenameColumn(
                name: "ProviderOptionId",
                table: "ProviderOptionPrice",
                newName: "OptionId");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderOptionPrice_ProviderOptionId",
                table: "ProviderOptionPrice",
                newName: "IX_ProviderOptionPrice_OptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderOptionPrice_Option_OptionId",
                table: "ProviderOptionPrice",
                column: "OptionId",
                principalTable: "Option",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProviderOptionPrice_Option_OptionId",
                table: "ProviderOptionPrice");

            migrationBuilder.RenameColumn(
                name: "OptionId",
                table: "ProviderOptionPrice",
                newName: "ProviderOptionId");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderOptionPrice_OptionId",
                table: "ProviderOptionPrice",
                newName: "IX_ProviderOptionPrice_ProviderOptionId");

            migrationBuilder.CreateTable(
                name: "ProviderQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientQuestionId = table.Column<int>(nullable: true),
                    Heading = table.Column<string>(nullable: true),
                    IsRequired = table.Column<bool>(nullable: false),
                    IsStartQuestion = table.Column<bool>(nullable: false),
                    NextQuestionId = table.Column<int>(nullable: true),
                    ServiceInfoId = table.Column<int>(nullable: false),
                    SubHeading = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderQuestion", x => x.Id);
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
                    table.ForeignKey(
                        name: "FK_ProviderQuestion_ServiceInfo_ServiceInfoId",
                        column: x => x.ServiceInfoId,
                        principalTable: "ServiceInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProviderQuestionSource",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientQuestionSourceId = table.Column<int>(nullable: true),
                    Heading = table.Column<string>(nullable: true),
                    IsRequired = table.Column<bool>(nullable: false),
                    IsStartQuestion = table.Column<bool>(nullable: false),
                    NextQuestionSourceId = table.Column<int>(nullable: true),
                    ServiceInfoSourceId = table.Column<int>(nullable: false),
                    SubHeading = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderQuestionSource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProviderQuestionSource_QuestionSource_ClientQuestionSourceId",
                        column: x => x.ClientQuestionSourceId,
                        principalTable: "QuestionSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProviderQuestionSource_ProviderQuestionSource_NextQuestionSourceId",
                        column: x => x.NextQuestionSourceId,
                        principalTable: "ProviderQuestionSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProviderQuestionSource_ServiceInfoSource_ServiceInfoSourceId",
                        column: x => x.ServiceInfoSourceId,
                        principalTable: "ServiceInfoSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProviderOption",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientOptionId = table.Column<int>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: true),
                    SpecialtyId = table.Column<int>(nullable: true),
                    Text = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "ProviderOptionSource",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientOptionSourceId = table.Column<int>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    QuestionSourceId = table.Column<int>(nullable: true),
                    SpecialtySourceId = table.Column<int>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderOptionSource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProviderOptionSource_OptionSource_ClientOptionSourceId",
                        column: x => x.ClientOptionSourceId,
                        principalTable: "OptionSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProviderOptionSource_ProviderQuestionSource_QuestionSourceId",
                        column: x => x.QuestionSourceId,
                        principalTable: "ProviderQuestionSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProviderOptionSource_SpecialtySource_SpecialtySourceId",
                        column: x => x.SpecialtySourceId,
                        principalTable: "SpecialtySource",
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
                name: "IX_ProviderOptionSource_ClientOptionSourceId",
                table: "ProviderOptionSource",
                column: "ClientOptionSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderOptionSource_QuestionSourceId",
                table: "ProviderOptionSource",
                column: "QuestionSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderOptionSource_SpecialtySourceId",
                table: "ProviderOptionSource",
                column: "SpecialtySourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderQuestion_ClientQuestionId",
                table: "ProviderQuestion",
                column: "ClientQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderQuestion_NextQuestionId",
                table: "ProviderQuestion",
                column: "NextQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderQuestion_ServiceInfoId",
                table: "ProviderQuestion",
                column: "ServiceInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderQuestionSource_ClientQuestionSourceId",
                table: "ProviderQuestionSource",
                column: "ClientQuestionSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderQuestionSource_NextQuestionSourceId",
                table: "ProviderQuestionSource",
                column: "NextQuestionSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderQuestionSource_ServiceInfoSourceId",
                table: "ProviderQuestionSource",
                column: "ServiceInfoSourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderOptionPrice_ProviderOption_ProviderOptionId",
                table: "ProviderOptionPrice",
                column: "ProviderOptionId",
                principalTable: "ProviderOption",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
