using EFCoreMovies.Enums;

namespace EFCoreMovies.Entities
{
    /// <summary>
    /// Cinema hall Entity
    /// </summary>
    public class CinemaHall
    {
        /// <summary>
        /// Cinema hall ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ciname Hall type
        /// </summary>
        public CinemaHallTypeEnum CinemaHallType { get; set; }

        /// <summary>
        /// Cinema hall price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Foreign key cinema Id
        /// </summary>
        public int CinemaId { get; set; }

        /// <summary>
        /// Cinema Entity
        /// </summary>
        public Cinema Cinema { get; set; }

        /// <summary>
        /// Movies hash set
        /// </summary>
        public HashSet<Movie> Movies { get; set; }
    }
}
