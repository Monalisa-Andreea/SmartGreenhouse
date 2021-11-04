using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartGarden.Migrations
{
    public partial class InitMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BarometricSensors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemperatureValue = table.Column<double>(nullable: false),
                    PressureValue = table.Column<double>(nullable: false),
                    AltitudeValue = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarometricSensors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LightSensors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LightSensors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoilMoistureSensors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoilMoistureSensors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TemperatureSensors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HumidityValue = table.Column<double>(nullable: false),
                    TemperatureCValue = table.Column<double>(nullable: false),
                    TemperatureFValue = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemperatureSensors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaterLevelSensors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterLevelSensors", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarometricSensors");

            migrationBuilder.DropTable(
                name: "LightSensors");

            migrationBuilder.DropTable(
                name: "SoilMoistureSensors");

            migrationBuilder.DropTable(
                name: "TemperatureSensors");

            migrationBuilder.DropTable(
                name: "WaterLevelSensors");
        }
    }
}
