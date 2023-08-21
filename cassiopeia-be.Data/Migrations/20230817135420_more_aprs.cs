using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cassiopeia_be.Data.Migrations
{
    /// <inheritdoc />
    public partial class more_aprs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AprsMessages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2023, 8, 17, 15, 54, 20, 853, DateTimeKind.Local).AddTicks(1855));

            migrationBuilder.InsertData(
                table: "AprsMessages",
                columns: new[] { "Id", "Message", "Observer", "SatelliteId", "Source", "Station", "Time" },
                values: new object[,]
                {
                    { 2, "Temperature: 25°C, Battery: 85%", "Ground Station B", 1, "NOCALL", "CubeSat-2", new DateTime(2023, 8, 17, 15, 54, 20, 853, DateTimeKind.Local).AddTicks(1865) },
                    { 3, "Deployed solar panels successfully!", "Ground Station C", 1, "NOCALL", "CubeSat-3", new DateTime(2023, 8, 17, 15, 54, 20, 853, DateTimeKind.Local).AddTicks(1868) },
                    { 4, "Orbit update: Altitude: 400 km, Inclination: 45°", "Ground Station D", 1, "NOCALL", "CubeSat-4", new DateTime(2023, 8, 17, 15, 54, 20, 853, DateTimeKind.Local).AddTicks(1871) },
                    { 5, "Experiment results: Successful microgravity test.", "Ground Station E", 1, "NOCALL", "CubeSat-5", new DateTime(2023, 8, 17, 15, 54, 20, 853, DateTimeKind.Local).AddTicks(1873) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AprsMessages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AprsMessages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AprsMessages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AprsMessages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "AprsMessages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2023, 8, 17, 15, 40, 12, 520, DateTimeKind.Local).AddTicks(6166));
        }
    }
}
