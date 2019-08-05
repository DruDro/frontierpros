using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class RenamedProjectDurationToMinJobDurationForServiceItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProjectDuration",
                table: "ServiceItem",
                newName: "MinJobDuration");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MinJobDuration",
                table: "ServiceItem",
                newName: "ProjectDuration");
        }
    }
}
