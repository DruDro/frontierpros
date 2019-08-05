using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class AddProfileInfoFieldsToProvider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Provider",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Provider",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirthday",
                table: "Provider",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Provider",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Provider",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsIndividualCompany",
                table: "Provider",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Provider",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonalAdress",
                table: "Provider",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonalPhoneNumber",
                table: "Provider",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceCategoryId",
                table: "Provider",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Provider",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Provider",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WhyShouldCustomerHireYou",
                table: "Provider",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YourIntroduction",
                table: "Provider",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Provider");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Provider");

            migrationBuilder.DropColumn(
                name: "DateOfBirthday",
                table: "Provider");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Provider");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Provider");

            migrationBuilder.DropColumn(
                name: "IsIndividualCompany",
                table: "Provider");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Provider");

            migrationBuilder.DropColumn(
                name: "PersonalAdress",
                table: "Provider");

            migrationBuilder.DropColumn(
                name: "PersonalPhoneNumber",
                table: "Provider");

            migrationBuilder.DropColumn(
                name: "ServiceCategoryId",
                table: "Provider");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Provider");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Provider");

            migrationBuilder.DropColumn(
                name: "WhyShouldCustomerHireYou",
                table: "Provider");

            migrationBuilder.DropColumn(
                name: "YourIntroduction",
                table: "Provider");
        }
    }
}
