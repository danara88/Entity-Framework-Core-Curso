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
        /// List -> Si nos ayuda al ordenamiento
        /// </summary>
        public List<Genre> Genres { get; set; } // HashSet no los ordena, y microsoft no nos garantiza el ordenamiento al 100%

        /// <summary>
        /// Cinema halls hash set
        /// </summary>
        public List<CinemaHall> CinemaHalls { get; set; }

        /// <summary>
        /// Movies Actors navigation property
        /// </summary>
        public List<MovieActor> MoviesActors { get; set; }
    }
}
