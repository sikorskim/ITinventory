using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ITinventory.Migrations
{
    public partial class migr0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Localization_Department_DepartmentId",
                table: "Localization");

            migrationBuilder.DropColumn(
                name: "DepatmentId",
                table: "Localization");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Localization",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Localization_Department_DepartmentId",
                table: "Localization",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Localization_Department_DepartmentId",
                table: "Localization");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Localization",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "DepatmentId",
                table: "Localization",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Localization_Department_DepartmentId",
                table: "Localization",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
