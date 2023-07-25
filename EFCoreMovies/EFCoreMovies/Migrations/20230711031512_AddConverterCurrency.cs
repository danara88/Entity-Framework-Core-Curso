using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovies.Migrations
{
    /// <inheritdoc />
    public partial class AddConverterCurrency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "CinemaHalls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "CinemaHalls");
        }
    }
}
