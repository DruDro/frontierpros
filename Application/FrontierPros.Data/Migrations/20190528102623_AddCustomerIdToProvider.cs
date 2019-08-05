using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class AddCustomerIdToProvider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Provider",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Provider_CustomerId",
                table: "Provider",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Provider_Customer_CustomerId",
                table: "Provider",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Provider_Customer_CustomerId",
                table: "Provider");

            migrationBuilder.DropIndex(
                name: "IX_Provider_CustomerId",
                table: "Provider");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Provider");
        }
    }
}
