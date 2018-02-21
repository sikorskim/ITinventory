using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ITinventory.Migrations
{
    public partial class migr0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocalizationId",
                table: "Device",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Device_LocalizationId",
                table: "Device",
                column: "LocalizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Device_Localization_LocalizationId",
                table: "Device",
                column: "LocalizationId",
                principalTable: "Localization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Device_Localization_LocalizationId",
                table: "Device");

            migrationBuilder.DropIndex(
                name: "IX_Device_LocalizationId",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "LocalizationId",
                table: "Device");
        }
    }
}
