using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovies.Migrations
{
    /// <inheritdoc />
    public partial class AddViewForMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
CREATE VIEW [dbo].[CountMoviesView]
AS
SELECT Id, Title,
(
SELECT count(*)
FROM MoviesActors
WHERE MovieId = Movies.Id) as GenresQuantity,
(SELECT count(distinct CinemaId) 
FROM CinemaHallMovie
INNER JOIN CinemaHalls
ON CinemaHalls.Id = CinemaHallMovie.CinemaHallsId
WHERE MoviesId =  Movies.Id) as CinemasQuantity,
(
SELECT count(*)
FROM MoviesActors
WHERE MovieId = Movies.Id) as ActorsQuantity
FROM Movies
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW [dbo].[CountMoviesView]");
        }
    }
}
