using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherData2._0.Migrations
{
    public partial class ReadCSV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Enviornments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Enviornments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Enviornments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Enviornments",
                keyColumn: "Id",
                keyValue: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Enviornments",
                columns: new[] { "Id", "Date", "Humidity", "InsideOrOutside", "Temperature" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 2, 23, 23, 11, 18, 109, DateTimeKind.Local).AddTicks(6813), 60, "Outside", -3f },
                    { 2, new DateTime(2021, 2, 23, 23, 11, 18, 122, DateTimeKind.Local).AddTicks(498), 20, "Inside", 25.2f },
                    { 3, new DateTime(2021, 2, 23, 23, 11, 18, 122, DateTimeKind.Local).AddTicks(629), 80, "Outside", 2f },
                    { 4, new DateTime(2021, 2, 23, 23, 11, 18, 122, DateTimeKind.Local).AddTicks(729), 18, "Inside", 28.1f }
                });
        }
    }
}
