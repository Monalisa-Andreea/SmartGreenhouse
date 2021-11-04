using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartGarden.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CurrentDate",
                table: "WaterLevelSensors",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CurrentDate",
                table: "TemperatureSensors",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CurrentDate",
                table: "SoilMoistureSensors",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CurrentDate",
                table: "LightSensors",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CurrentDate",
                table: "BarometricSensors",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentDate",
                table: "WaterLevelSensors");

            migrationBuilder.DropColumn(
                name: "CurrentDate",
                table: "TemperatureSensors");

            migrationBuilder.DropColumn(
                name: "CurrentDate",
                table: "SoilMoistureSensors");

            migrationBuilder.DropColumn(
                name: "CurrentDate",
                table: "LightSensors");

            migrationBuilder.DropColumn(
                name: "CurrentDate",
                table: "BarometricSensors");
        }
    }
}
