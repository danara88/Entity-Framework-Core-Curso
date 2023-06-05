namespace EFCoreMovies.Entities
{
    /// <summary>
    /// Actor Entity
    /// </summary>
    public class Actor
    {
        /// <summary>
        /// Actor ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Actor's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Actor's biography
        /// </summary>
        public string Biography { get; set; }

        /// <summary>
        /// Actor's birthdate
        /// </summary>
        /// datetime2 -> Significa que en la tabla tambien se guardara la hora
        //[Column(TypeName = "Date")]
        public DateTime? Birthdate { get; set; } // Utilizando ? permitimos nulo

        /// <summary>
        /// MaviesActors navigation property
        /// </summary>
        public HashSet<MovieActor> MoviesActors { get; set; }
    }
}
