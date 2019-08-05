using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class UpdatedProviderAndServiceTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Service");

            migrationBuilder.AddColumn<int>(
                name: "ProviderId",
                table: "Service",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Service_ProviderId",
                table: "Service",
                column: "ProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Provider_ProviderId",
                table: "Service",
                column: "ProviderId",
                principalTable: "Provider",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_Provider_ProviderId",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_ProviderId",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "ProviderId",
                table: "Service");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Service",
                nullable: true);
        }
    }
}
