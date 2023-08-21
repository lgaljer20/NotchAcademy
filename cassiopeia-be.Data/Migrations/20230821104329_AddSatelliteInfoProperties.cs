using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cassiopeia_be.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSatelliteInfoProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "SatelliteInfos");

            migrationBuilder.AddColumn<bool>(
                name: "APRSIsEnabled",
                table: "SatelliteInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BatteryCapacityIsEnabled",
                table: "SatelliteInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BatteryTemperatureIsEnabled",
                table: "SatelliteInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BatteryVoltageIsEnabled",
                table: "SatelliteInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OBC9DOTemperatureIsEnabled",
                table: "SatelliteInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OBCFreeMemoryIsEnabled",
                table: "SatelliteInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OBCMCUTemperatureIsEnabled",
                table: "SatelliteInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OBCNumberIsEnabled",
                table: "SatelliteInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OBCPacketRecordIsEnabled",
                table: "SatelliteInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OBCRestartIsEnabled",
                table: "SatelliteInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OBCTimestampIsEnabled",
                table: "SatelliteInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OBCUptimeTotalIsEnabled",
                table: "SatelliteInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReceivedByIsEnabled",
                table: "SatelliteInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SignalCountIsEnabled",
                table: "SatelliteInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SolarTemperatureIsEnabled",
                table: "SatelliteInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StatusIsEnabled",
                table: "SatelliteInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UHFTemperatureIsEnabled",
                table: "SatelliteInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "VHFTemperatureIsEnabled",
                table: "SatelliteInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.UpdateData(
                table: "SatelliteInfos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "APRSIsEnabled", "BatteryCapacityIsEnabled", "BatteryTemperatureIsEnabled", "BatteryVoltageIsEnabled", "OBC9DOTemperatureIsEnabled", "OBCFreeMemoryIsEnabled", "OBCMCUTemperatureIsEnabled", "OBCNumberIsEnabled", "OBCPacketRecordIsEnabled", "OBCRestartIsEnabled", "OBCTimestampIsEnabled", "OBCUptimeTotalIsEnabled", "ReceivedByIsEnabled", "SignalCountIsEnabled", "SolarTemperatureIsEnabled", "StatusIsEnabled", "UHFTemperatureIsEnabled", "VHFTemperatureIsEnabled" },
                values: new object[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "APRSIsEnabled",
                table: "SatelliteInfos");

            migrationBuilder.DropColumn(
                name: "BatteryCapacityIsEnabled",
                table: "SatelliteInfos");

            migrationBuilder.DropColumn(
                name: "BatteryTemperatureIsEnabled",
                table: "SatelliteInfos");

            migrationBuilder.DropColumn(
                name: "BatteryVoltageIsEnabled",
                table: "SatelliteInfos");

            migrationBuilder.DropColumn(
                name: "OBC9DOTemperatureIsEnabled",
                table: "SatelliteInfos");

            migrationBuilder.DropColumn(
                name: "OBCFreeMemoryIsEnabled",
                table: "SatelliteInfos");

            migrationBuilder.DropColumn(
                name: "OBCMCUTemperatureIsEnabled",
                table: "SatelliteInfos");

            migrationBuilder.DropColumn(
                name: "OBCNumberIsEnabled",
                table: "SatelliteInfos");

            migrationBuilder.DropColumn(
                name: "OBCPacketRecordIsEnabled",
                table: "SatelliteInfos");

            migrationBuilder.DropColumn(
                name: "OBCRestartIsEnabled",
                table: "SatelliteInfos");

            migrationBuilder.DropColumn(
                name: "OBCTimestampIsEnabled",
                table: "SatelliteInfos");

            migrationBuilder.DropColumn(
                name: "OBCUptimeTotalIsEnabled",
                table: "SatelliteInfos");

            migrationBuilder.DropColumn(
                name: "ReceivedByIsEnabled",
                table: "SatelliteInfos");

            migrationBuilder.DropColumn(
                name: "SignalCountIsEnabled",
                table: "SatelliteInfos");

            migrationBuilder.DropColumn(
                name: "SolarTemperatureIsEnabled",
                table: "SatelliteInfos");

            migrationBuilder.DropColumn(
                name: "StatusIsEnabled",
                table: "SatelliteInfos");

            migrationBuilder.DropColumn(
                name: "UHFTemperatureIsEnabled",
                table: "SatelliteInfos");

            migrationBuilder.DropColumn(
                name: "VHFTemperatureIsEnabled",
                table: "SatelliteInfos");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "SatelliteInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AprsMessages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2023, 8, 17, 15, 54, 20, 853, DateTimeKind.Local).AddTicks(1855));

            migrationBuilder.UpdateData(
                table: "AprsMessages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2023, 8, 17, 15, 54, 20, 853, DateTimeKind.Local).AddTicks(1865));

            migrationBuilder.UpdateData(
                table: "AprsMessages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2023, 8, 17, 15, 54, 20, 853, DateTimeKind.Local).AddTicks(1868));

            migrationBuilder.UpdateData(
                table: "AprsMessages",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: new DateTime(2023, 8, 17, 15, 54, 20, 853, DateTimeKind.Local).AddTicks(1871));

            migrationBuilder.UpdateData(
                table: "AprsMessages",
                keyColumn: "Id",
                keyValue: 5,
                column: "Time",
                value: new DateTime(2023, 8, 17, 15, 54, 20, 853, DateTimeKind.Local).AddTicks(1873));

            migrationBuilder.UpdateData(
                table: "SatelliteInfos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: "active");
        }
    }
}
