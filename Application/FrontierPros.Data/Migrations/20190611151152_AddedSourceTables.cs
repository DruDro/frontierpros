using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class AddedSourceTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryInfoSource",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PK = table.Column<string>(nullable: true),
                    IDString = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Taxonym = table.Column<string>(nullable: true),
                    PluralTaxonym = table.Column<string>(nullable: true),
                    Popularity = table.Column<double>(nullable: false),
                    Rank = table.Column<double>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(nullable: false),
                    Published = table.Column<bool>(nullable: false),
                    SourceType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryInfoSource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupSource",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Published = table.Column<bool>(nullable: false),
                    SourceType = table.Column<int>(nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupSource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NameTokenSource",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NameTokenSource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AddonSource",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CategoryInfoSourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddonSource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddonSource_CategoryInfoSource_CategoryInfoSourceId",
                        column: x => x.CategoryInfoSourceId,
                        principalTable: "CategoryInfoSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionSource",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Heading = table.Column<string>(nullable: true),
                    SubHeading = table.Column<string>(nullable: true),
                    Placeholder = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    IsStartQuestion = table.Column<bool>(nullable: false),
                    IsRequired = table.Column<bool>(nullable: false),
                    CategoryInfoSourceId = table.Column<int>(nullable: false),
                    NextQuestionSourceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionSource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionSource_CategoryInfoSource_CategoryInfoSourceId",
                        column: x => x.CategoryInfoSourceId,
                        principalTable: "CategoryInfoSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionSource_QuestionSource_NextQuestionSourceId",
                        column: x => x.NextQuestionSourceId,
                        principalTable: "QuestionSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecialtySource",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Heading = table.Column<string>(nullable: true),
                    CategoryInfoSourceId = table.Column<int>(nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialtySource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialtySource_CategoryInfoSource_CategoryInfoSourceId",
                        column: x => x.CategoryInfoSourceId,
                        principalTable: "CategoryInfoSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryGroupSource",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryInfoSourceId = table.Column<int>(nullable: false),
                    GroupSourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryGroupSource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryGroupSource_CategoryInfoSource_CategoryInfoSourceId",
                        column: x => x.CategoryInfoSourceId,
                        principalTable: "CategoryInfoSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryGroupSource_GroupSource_GroupSourceId",
                        column: x => x.GroupSourceId,
                        principalTable: "GroupSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryNameTokenSource",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameTokenSourceId = table.Column<int>(nullable: false),
                    CategoryInfoSourceId = table.Column<int>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryNameTokenSource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryNameTokenSource_CategoryInfoSource_CategoryInfoSourceId",
                        column: x => x.CategoryInfoSourceId,
                        principalTable: "CategoryInfoSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryNameTokenSource_NameTokenSource_NameTokenSourceId",
                        column: x => x.NameTokenSourceId,
                        principalTable: "NameTokenSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddonItemSource",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    AddonSourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddonItemSource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddonItemSource_AddonSource_AddonSourceId",
                        column: x => x.AddonSourceId,
                        principalTable: "AddonSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProviderQuestionSource",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Heading = table.Column<string>(nullable: true),
                    SubHeading = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    IsStartQuestion = table.Column<bool>(nullable: false),
                    IsRequired = table.Column<bool>(nullable: false),
                    CategoryInfoSourceId = table.Column<int>(nullable: false),
                    NextQuestionSourceId = table.Column<int>(nullable: true),
                    ClientQuestionSourceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderQuestionSource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProviderQuestionSource_CategoryInfoSource_CategoryInfoSourceId",
                        column: x => x.CategoryInfoSourceId,
                        principalTable: "CategoryInfoSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                });

            migrationBuilder.CreateTable(
                name: "OptionSource",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true),
                    Placeholder = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    SpecialtySourceId = table.Column<int>(nullable: true),
                    QuestionSourceId = table.Column<int>(nullable: true),
                    NextQuestionSourceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionSource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OptionSource_QuestionSource_NextQuestionSourceId",
                        column: x => x.NextQuestionSourceId,
                        principalTable: "QuestionSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OptionSource_QuestionSource_QuestionSourceId",
                        column: x => x.QuestionSourceId,
                        principalTable: "QuestionSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OptionSource_SpecialtySource_SpecialtySourceId",
                        column: x => x.SpecialtySourceId,
                        principalTable: "SpecialtySource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProviderOptionSource",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    SpecialtySourceId = table.Column<int>(nullable: true),
                    QuestionSourceId = table.Column<int>(nullable: true),
                    ClientOptionSourceId = table.Column<int>(nullable: true)
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
                name: "IX_AddonItemSource_AddonSourceId",
                table: "AddonItemSource",
                column: "AddonSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_AddonSource_CategoryInfoSourceId",
                table: "AddonSource",
                column: "CategoryInfoSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryGroupSource_CategoryInfoSourceId",
                table: "CategoryGroupSource",
                column: "CategoryInfoSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryGroupSource_GroupSourceId",
                table: "CategoryGroupSource",
                column: "GroupSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryNameTokenSource_CategoryInfoSourceId",
                table: "CategoryNameTokenSource",
                column: "CategoryInfoSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryNameTokenSource_NameTokenSourceId",
                table: "CategoryNameTokenSource",
                column: "NameTokenSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionSource_NextQuestionSourceId",
                table: "OptionSource",
                column: "NextQuestionSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionSource_QuestionSourceId",
                table: "OptionSource",
                column: "QuestionSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionSource_SpecialtySourceId",
                table: "OptionSource",
                column: "SpecialtySourceId");

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
                name: "IX_ProviderQuestionSource_CategoryInfoSourceId",
                table: "ProviderQuestionSource",
                column: "CategoryInfoSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderQuestionSource_ClientQuestionSourceId",
                table: "ProviderQuestionSource",
                column: "ClientQuestionSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderQuestionSource_NextQuestionSourceId",
                table: "ProviderQuestionSource",
                column: "NextQuestionSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionSource_CategoryInfoSourceId",
                table: "QuestionSource",
                column: "CategoryInfoSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionSource_NextQuestionSourceId",
                table: "QuestionSource",
                column: "NextQuestionSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialtySource_CategoryInfoSourceId",
                table: "SpecialtySource",
                column: "CategoryInfoSourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddonItemSource");

            migrationBuilder.DropTable(
                name: "CategoryGroupSource");

            migrationBuilder.DropTable(
                name: "CategoryNameTokenSource");

            migrationBuilder.DropTable(
                name: "ProviderOptionSource");

            migrationBuilder.DropTable(
                name: "AddonSource");

            migrationBuilder.DropTable(
                name: "GroupSource");

            migrationBuilder.DropTable(
                name: "NameTokenSource");

            migrationBuilder.DropTable(
                name: "OptionSource");

            migrationBuilder.DropTable(
                name: "ProviderQuestionSource");

            migrationBuilder.DropTable(
                name: "SpecialtySource");

            migrationBuilder.DropTable(
                name: "QuestionSource");

            migrationBuilder.DropTable(
                name: "CategoryInfoSource");
        }
    }
}
