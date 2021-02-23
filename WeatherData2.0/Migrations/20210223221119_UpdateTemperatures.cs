using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherData2._0.Migrations
{
    public partial class UpdateTemperatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Enviornments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 2, 23, 23, 11, 18, 109, DateTimeKind.Local).AddTicks(6813));

            migrationBuilder.UpdateData(
                table: "Enviornments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 2, 23, 23, 11, 18, 122, DateTimeKind.Local).AddTicks(498));

            migrationBuilder.UpdateData(
                table: "Enviornments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2021, 2, 23, 23, 11, 18, 122, DateTimeKind.Local).AddTicks(629));

            migrationBuilder.UpdateData(
                table: "Enviornments",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2021, 2, 23, 23, 11, 18, 122, DateTimeKind.Local).AddTicks(729));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Enviornments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 2, 23, 22, 54, 54, 261, DateTimeKind.Local).AddTicks(4967));

            migrationBuilder.UpdateData(
                table: "Enviornments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 2, 23, 22, 54, 54, 273, DateTimeKind.Local).AddTicks(5463));

            migrationBuilder.UpdateData(
                table: "Enviornments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2021, 2, 23, 22, 54, 54, 273, DateTimeKind.Local).AddTicks(5577));

            migrationBuilder.UpdateData(
                table: "Enviornments",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2021, 2, 23, 22, 54, 54, 273, DateTimeKind.Local).AddTicks(5589));
        }
    }
}
