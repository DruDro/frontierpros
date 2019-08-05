using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class SetServiceInfoIdAsNullableForServiceItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceItem_ServiceInfo_ServiceInfoId",
                table: "ServiceItem");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceInfoId",
                table: "ServiceItem",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceItem_ServiceInfo_ServiceInfoId",
                table: "ServiceItem",
                column: "ServiceInfoId",
                principalTable: "ServiceInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceItem_ServiceInfo_ServiceInfoId",
                table: "ServiceItem");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceInfoId",
                table: "ServiceItem",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceItem_ServiceInfo_ServiceInfoId",
                table: "ServiceItem",
                column: "ServiceInfoId",
                principalTable: "ServiceInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
