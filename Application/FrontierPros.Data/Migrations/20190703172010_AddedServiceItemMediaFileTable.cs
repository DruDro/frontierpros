using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class AddedServiceItemMediaFileTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IconId",
                table: "ServiceItem",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tblServiceItemMediaFile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    BlobName = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    ServiceItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblServiceItemMediaFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblServiceItemMediaFile_ServiceItem_ServiceItemId",
                        column: x => x.ServiceItemId,
                        principalTable: "ServiceItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceItem_IconId",
                table: "ServiceItem",
                column: "IconId");

            migrationBuilder.CreateIndex(
                name: "IX_tblServiceItemMediaFile_ServiceItemId",
                table: "tblServiceItemMediaFile",
                column: "ServiceItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceItem_tblServiceItemMediaFile_IconId",
                table: "ServiceItem",
                column: "IconId",
                principalTable: "tblServiceItemMediaFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceItem_tblServiceItemMediaFile_IconId",
                table: "ServiceItem");

            migrationBuilder.DropTable(
                name: "tblServiceItemMediaFile");

            migrationBuilder.DropIndex(
                name: "IX_ServiceItem_IconId",
                table: "ServiceItem");

            migrationBuilder.DropColumn(
                name: "IconId",
                table: "ServiceItem");
        }
    }
}
