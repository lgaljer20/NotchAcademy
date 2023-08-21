using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cassiopeia_be.Data.Migrations
{
    /// <inheritdoc />
    public partial class aprs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AprsMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Station = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SatelliteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AprsMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AprsMessages_SatelliteInfos_SatelliteId",
                        column: x => x.SatelliteId,
                        principalTable: "SatelliteInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AprsMessages",
                columns: new[] { "Id", "Message", "Observer", "SatelliteId", "Source", "Station", "Time" },
                values: new object[] { 1, "Hello from CubeSat-1!", "Ground Station A", 1, "NOCALL", "CubeSat-1", new DateTime(2023, 8, 17, 15, 40, 12, 520, DateTimeKind.Local).AddTicks(6166) });

            migrationBuilder.CreateIndex(
                name: "IX_AprsMessages_SatelliteId",
                table: "AprsMessages",
                column: "SatelliteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AprsMessages");
        }
    }
}
