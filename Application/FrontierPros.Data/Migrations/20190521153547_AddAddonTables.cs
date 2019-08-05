﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class AddAddonTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CategoryInfoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addon_CategoryInfo_CategoryInfoId",
                        column: x => x.CategoryInfoId,
                        principalTable: "CategoryInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddonItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    AddonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddonItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddonItem_Addon_AddonId",
                        column: x => x.AddonId,
                        principalTable: "Addon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addon_CategoryInfoId",
                table: "Addon",
                column: "CategoryInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_AddonItem_AddonId",
                table: "AddonItem",
                column: "AddonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddonItem");

            migrationBuilder.DropTable(
                name: "Addon");
        }
    }
}
