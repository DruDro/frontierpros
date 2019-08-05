using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class RenamedProviderOptionPriceToServiceItemSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProviderOptionPrice");

            migrationBuilder.CreateTable(
                name: "tblServiceItemSettings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<decimal>(type: "decimal(18, 4)", nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    ServiceItemId = table.Column<int>(nullable: false),
                    OptionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblServiceItemSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblServiceItemSettings_Option_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Option",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblServiceItemSettings_ServiceItem_ServiceItemId",
                        column: x => x.ServiceItemId,
                        principalTable: "ServiceItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblServiceItemSettings_OptionId",
                table: "tblServiceItemSettings",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_tblServiceItemSettings_ServiceItemId",
                table: "tblServiceItemSettings",
                column: "ServiceItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblServiceItemSettings");

            migrationBuilder.CreateTable(
                name: "ProviderOptionPrice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OptionId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    ServiceItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderOptionPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProviderOptionPrice_Option_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Option",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProviderOptionPrice_ServiceItem_ServiceItemId",
                        column: x => x.ServiceItemId,
                        principalTable: "ServiceItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProviderOptionPrice_OptionId",
                table: "ProviderOptionPrice",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderOptionPrice_ServiceItemId",
                table: "ProviderOptionPrice",
                column: "ServiceItemId");
        }
    }
}
