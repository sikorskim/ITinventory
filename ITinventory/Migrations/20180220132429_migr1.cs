using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ITinventory.Migrations
{
    public partial class migr1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Device_DeviceType_DeviceTypeId",
                table: "Device");

            migrationBuilder.DropForeignKey(
                name: "FK_Device_Manufacturer_ManufacturerId",
                table: "Device");

            migrationBuilder.DropIndex(
                name: "IX_Device_DeviceTypeId",
                table: "Device");

            migrationBuilder.DropIndex(
                name: "IX_Device_ManufacturerId",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "DeviceTypeId",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "ManufacturerId",
                table: "Device");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "License",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Used",
                table: "License",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "License");

            migrationBuilder.DropColumn(
                name: "Used",
                table: "License");

            migrationBuilder.AddColumn<int>(
                name: "DeviceTypeId",
                table: "Device",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ManufacturerId",
                table: "Device",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Device_DeviceTypeId",
                table: "Device",
                column: "DeviceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Device_ManufacturerId",
                table: "Device",
                column: "ManufacturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Device_DeviceType_DeviceTypeId",
                table: "Device",
                column: "DeviceTypeId",
                principalTable: "DeviceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Device_Manufacturer_ManufacturerId",
                table: "Device",
                column: "ManufacturerId",
                principalTable: "Manufacturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
