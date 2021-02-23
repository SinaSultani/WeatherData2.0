using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherData2._0.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enviornments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Temperature = table.Column<float>(type: "real", nullable: false),
                    Humidity = table.Column<int>(type: "int", nullable: false),
                    InsideOrOutside = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enviornments", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Enviornments",
                columns: new[] { "Id", "Date", "Humidity", "InsideOrOutside", "Temperature" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 2, 23, 22, 54, 54, 261, DateTimeKind.Local).AddTicks(4967), 60, "Outside", -3f },
                    { 2, new DateTime(2021, 2, 23, 22, 54, 54, 273, DateTimeKind.Local).AddTicks(5463), 20, "Inside", 25.2f },
                    { 3, new DateTime(2021, 2, 23, 22, 54, 54, 273, DateTimeKind.Local).AddTicks(5577), 80, "Outside", 2f },
                    { 4, new DateTime(2021, 2, 23, 22, 54, 54, 273, DateTimeKind.Local).AddTicks(5589), 18, "Inside", 28.1f }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enviornments");
        }
    }
}
