using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cassiopeia_be.Data.Migrations
{
    /// <inheritdoc />
    public partial class Battery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Battery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SatelliteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Battery_SatelliteInfos_SatelliteId",
                        column: x => x.SatelliteId,
                        principalTable: "SatelliteInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BatteryCurrentRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentIn = table.Column<double>(type: "float", nullable: false),
                    CurrentOut = table.Column<double>(type: "float", nullable: false),
                    BatteryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatteryCurrentRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BatteryCurrentRecords_Battery_BatteryId",
                        column: x => x.BatteryId,
                        principalTable: "Battery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BatteryStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Voltage = table.Column<double>(type: "float", nullable: false),
                    Current = table.Column<double>(type: "float", nullable: false),
                    ChargeLevel = table.Column<int>(type: "int", nullable: false),
                    BatteryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatteryStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BatteryStatuses_Battery_BatteryId",
                        column: x => x.BatteryId,
                        principalTable: "Battery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemperatureDataRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BatteryTemperature = table.Column<double>(type: "float", nullable: false),
                    SystemTemperature = table.Column<double>(type: "float", nullable: false),
                    BatteryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemperatureDataRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemperatureDataRecords_Battery_BatteryId",
                        column: x => x.BatteryId,
                        principalTable: "Battery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AprsMessages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2023, 8, 24, 11, 12, 44, 800, DateTimeKind.Local).AddTicks(6520));

            migrationBuilder.UpdateData(
                table: "AprsMessages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2023, 8, 24, 11, 12, 44, 800, DateTimeKind.Local).AddTicks(6544));

            migrationBuilder.UpdateData(
                table: "AprsMessages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2023, 8, 24, 11, 12, 44, 800, DateTimeKind.Local).AddTicks(6547));

            migrationBuilder.UpdateData(
                table: "AprsMessages",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: new DateTime(2023, 8, 24, 11, 12, 44, 800, DateTimeKind.Local).AddTicks(6549));

            migrationBuilder.UpdateData(
                table: "AprsMessages",
                keyColumn: "Id",
                keyValue: 5,
                column: "Time",
                value: new DateTime(2023, 8, 24, 11, 12, 44, 800, DateTimeKind.Local).AddTicks(6552));

            migrationBuilder.InsertData(
                table: "Battery",
                columns: new[] { "Id", "SatelliteId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "BatteryCurrentRecords",
                columns: new[] { "Id", "BatteryId", "CurrentIn", "CurrentOut", "Timestamp" },
                values: new object[,]
                {
                    { 1, 1, 1.2, 0.80000000000000004, new DateTime(2023, 8, 24, 9, 12, 44, 801, DateTimeKind.Utc).AddTicks(3212) },
                    { 2, 2, 1.0, 0.69999999999999996, new DateTime(2023, 8, 24, 9, 12, 44, 801, DateTimeKind.Utc).AddTicks(3214) }
                });

            migrationBuilder.InsertData(
                table: "BatteryStatuses",
                columns: new[] { "Id", "BatteryId", "ChargeLevel", "Current", "Voltage" },
                values: new object[,]
                {
                    { 1, 1, 80, 5.0, 12.5 },
                    { 2, 2, 75, 4.7999999999999998, 13.199999999999999 }
                });

            migrationBuilder.InsertData(
                table: "TemperatureDataRecords",
                columns: new[] { "Id", "BatteryId", "BatteryTemperature", "SystemTemperature", "Timestamp" },
                values: new object[,]
                {
                    { 1, 1, 25.5, 28.300000000000001, new DateTime(2023, 8, 24, 9, 12, 44, 801, DateTimeKind.Utc).AddTicks(3196) },
                    { 2, 2, 24.800000000000001, 27.699999999999999, new DateTime(2023, 8, 24, 9, 12, 44, 801, DateTimeKind.Utc).AddTicks(3198) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Battery_SatelliteId",
                table: "Battery",
                column: "SatelliteId");

            migrationBuilder.CreateIndex(
                name: "IX_BatteryCurrentRecords_BatteryId",
                table: "BatteryCurrentRecords",
                column: "BatteryId");

            migrationBuilder.CreateIndex(
                name: "IX_BatteryStatuses_BatteryId",
                table: "BatteryStatuses",
                column: "BatteryId");

            migrationBuilder.CreateIndex(
                name: "IX_TemperatureDataRecords_BatteryId",
                table: "TemperatureDataRecords",
                column: "BatteryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BatteryCurrentRecords");

            migrationBuilder.DropTable(
                name: "BatteryStatuses");

            migrationBuilder.DropTable(
                name: "TemperatureDataRecords");

            migrationBuilder.DropTable(
                name: "Battery");

            migrationBuilder.UpdateData(
                table: "AprsMessages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2023, 8, 21, 12, 43, 29, 596, DateTimeKind.Local).AddTicks(7159));

            migrationBuilder.UpdateData(
                table: "AprsMessages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2023, 8, 21, 12, 43, 29, 596, DateTimeKind.Local).AddTicks(7171));

            migrationBuilder.UpdateData(
                table: "AprsMessages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2023, 8, 21, 12, 43, 29, 596, DateTimeKind.Local).AddTicks(7173));

            migrationBuilder.UpdateData(
                table: "AprsMessages",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: new DateTime(2023, 8, 21, 12, 43, 29, 596, DateTimeKind.Local).AddTicks(7175));

            migrationBuilder.UpdateData(
                table: "AprsMessages",
                keyColumn: "Id",
                keyValue: 5,
                column: "Time",
                value: new DateTime(2023, 8, 21, 12, 43, 29, 596, DateTimeKind.Local).AddTicks(7177));
        }
    }
}
