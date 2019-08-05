using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class AddedDiscountRateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblDiscountRate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RecurringSchedule = table.Column<int>(nullable: false),
                    DiscountRateType = table.Column<int>(nullable: false),
                    OneMonthDiscountValue = table.Column<decimal>(nullable: true),
                    TreeMonthDiscountValue = table.Column<decimal>(nullable: true),
                    SixMonthDiscountValue = table.Column<decimal>(nullable: true),
                    TwelveMonthDiscountValue = table.Column<decimal>(nullable: true),
                    ServiceItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDiscountRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblDiscountRate_ServiceItem_ServiceItemId",
                        column: x => x.ServiceItemId,
                        principalTable: "ServiceItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblDiscountRate_ServiceItemId",
                table: "tblDiscountRate",
                column: "ServiceItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblDiscountRate");
        }
    }
}
