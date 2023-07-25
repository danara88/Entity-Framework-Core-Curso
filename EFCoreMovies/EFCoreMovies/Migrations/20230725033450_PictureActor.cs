using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovies.Migrations
{
    /// <inheritdoc />
    public partial class PictureActor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureURL",
                table: "Actors",
                type: "varchar(500)",
                unicode: false,
                maxLength: 500,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1,
                column: "PictureURL",
                value: null);

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2,
                column: "PictureURL",
                value: null);

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3,
                column: "PictureURL",
                value: null);

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 4,
                column: "PictureURL",
                value: null);

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 5,
                column: "PictureURL",
                value: null);

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 6,
                column: "PictureURL",
                value: null);

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 7,
                column: "PictureURL",
                value: null);

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 8,
                column: "PictureURL",
                value: null);

            migrationBuilder.UpdateData(
                table: "CinemaOffers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 7, 31, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 7, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CinemaOffers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 7, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 7, 24, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureURL",
                table: "Actors");

            migrationBuilder.UpdateData(
                table: "CinemaOffers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 7, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 7, 12, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CinemaOffers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 7, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 7, 12, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
