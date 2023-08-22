using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cassiopeia_be.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStatusField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.Sql("UPDATE SatelliteInfos SET Status = 1 WHERE Status = 'active';");
            migrationBuilder.Sql("UPDATE SatelliteInfos SET Status = 0 WHERE Status = 'inactive';");


            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "SatelliteInfos",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }




    }
}
