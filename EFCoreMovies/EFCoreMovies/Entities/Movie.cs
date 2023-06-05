namespace EFCoreMovies.Entities
{
    /// <summary>
    /// Movie Entity
    /// </summary>
    public class Movie
    {
        /// <summary>
        /// Movie ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Movie's title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Is movie on billboard
        /// </summary>
        public bool OnBillboard { get; set; }

        /// <summary>
        /// Movie's release date
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Movie's poster URL
        /// </summary>
        // [Unicode(false)]
        public string PosterURL { get; set; }

        /// <summary>
        /// Genres hash set
        /// </summary>
        public HashSet<Genre> Genres { get; set; }

        /// <summary>
        /// Cinema halls hash set
        /// </summary>
        public HashSet<CinemaHall> CinemaHalls { get; set; }

        /// <summary>
        /// Movies Actors navigation property
        /// </summary>
        public HashSet<MovieActor> MoviesActors { get; set; }
    }
}
