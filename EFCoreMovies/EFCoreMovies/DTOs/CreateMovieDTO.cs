using EFCoreMovies.Entities;

namespace EFCoreMovies.DTOs
{
    public class CreateMovieDTO
    {
        public string Title { get; set; }

        public bool OnBillboard { get; set; }

        public DateTime ReleaseDate { get; set; }

        public List<int> Genres { get; set; }

        public List<int> CinemaHalls { get; set; }

        public List<CreateMovieActorDTO> MoviesActors { get; set; }
    }
}
