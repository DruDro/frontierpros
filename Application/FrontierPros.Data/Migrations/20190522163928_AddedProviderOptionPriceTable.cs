using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class AddedProviderOptionPriceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "BasePrice",
                table: "Service",
                type: "decimal(18, 4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.CreateTable(
                name: "ProviderOptionPrice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    ServiceId = table.Column<int>(nullable: false),
                    ProviderOptionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderOptionPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProviderOptionPrice_ProviderOption_ProviderOptionId",
                        column: x => x.ProviderOptionId,
                        principalTable: "ProviderOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProviderOptionPrice_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProviderOptionPrice_ProviderOptionId",
                table: "ProviderOptionPrice",
                column: "ProviderOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderOptionPrice_ServiceId",
                table: "ProviderOptionPrice",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProviderOptionPrice");

            migrationBuilder.AlterColumn<decimal>(
                name: "BasePrice",
                table: "Service",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 4)");
        }
    }
}
