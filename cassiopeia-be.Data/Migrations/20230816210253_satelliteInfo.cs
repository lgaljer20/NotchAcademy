using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cassiopeia_be.Data.Migrations
{
    /// <inheritdoc />
    public partial class satelliteInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SatelliteInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LaunchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginCountry = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatelliteInfos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SatelliteInfos",
                columns: new[] { "Id", "Image", "LaunchDate", "Name", "OriginCountry", "Owner", "Status" },
                values: new object[] { 1, "https://some_random_image.jpg", new DateTime(2023, 8, 7, 17, 45, 0, 0, DateTimeKind.Local), "cassiopeia", "Croatia", "notch", "active" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SatelliteInfos");
        }
    }
}
