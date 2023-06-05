namespace EFCoreMovies.Entities
{
    /// <summary>
    /// MovieAutor pivot table
    /// </summary>
    public class MovieActor
    {
        /// <summary>
        /// Movie ID
        /// </summary>
        public int MovieId { get; set; }

        /// <summary>
        /// Acotr ID
        /// </summary>
        public int ActorId { get; set; }

        /// <summary>
        /// Character name
        /// </summary>
        public string Character { get; set; }

        /// <summary>
        /// Order of relevance
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Movie navigation property
        /// </summary>
        public Movie Movie { get; set; }

        /// <summary>
        /// Actor navigation property
        /// </summary>
        public Actor Actor { get; set; }
    }
}
