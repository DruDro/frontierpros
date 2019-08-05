using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class AddedNewColumnsForServiceItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "BeginHoursUtc",
                table: "ServiceItem",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "FinishHoursUtc",
                table: "ServiceItem",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<bool>(
                name: "IsFlexibleAvailability",
                table: "ServiceItem",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRecurringJob",
                table: "ServiceItem",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "JobBookingTime",
                table: "ServiceItem",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ProjectDuration",
                table: "ServiceItem",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "TimeZoneDataId",
                table: "ServiceItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkingDaysSchedule",
                table: "ServiceItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceItem_TimeZoneDataId",
                table: "ServiceItem",
                column: "TimeZoneDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceItem_tblTimeZoneData_TimeZoneDataId",
                table: "ServiceItem",
                column: "TimeZoneDataId",
                principalTable: "tblTimeZoneData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceItem_tblTimeZoneData_TimeZoneDataId",
                table: "ServiceItem");

            migrationBuilder.DropIndex(
                name: "IX_ServiceItem_TimeZoneDataId",
                table: "ServiceItem");

            migrationBuilder.DropColumn(
                name: "BeginHoursUtc",
                table: "ServiceItem");

            migrationBuilder.DropColumn(
                name: "FinishHoursUtc",
                table: "ServiceItem");

            migrationBuilder.DropColumn(
                name: "IsFlexibleAvailability",
                table: "ServiceItem");

            migrationBuilder.DropColumn(
                name: "IsRecurringJob",
                table: "ServiceItem");

            migrationBuilder.DropColumn(
                name: "JobBookingTime",
                table: "ServiceItem");

            migrationBuilder.DropColumn(
                name: "ProjectDuration",
                table: "ServiceItem");

            migrationBuilder.DropColumn(
                name: "TimeZoneDataId",
                table: "ServiceItem");

            migrationBuilder.DropColumn(
                name: "WorkingDaysSchedule",
                table: "ServiceItem");
        }
    }
}
