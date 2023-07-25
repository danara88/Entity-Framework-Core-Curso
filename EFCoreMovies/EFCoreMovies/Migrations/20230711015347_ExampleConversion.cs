using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovies.Migrations
{
    /// <inheritdoc />
    public partial class ExampleConversion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CinemaHallType",
                table: "CinemaHalls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "TwoDimensions",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CinemaHallType",
                table: "CinemaHalls",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "TwoDimensions");
        }
    }
}
