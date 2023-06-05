using NetTopologySuite.Geometries;

namespace EFCoreMovies.Entities
{
    /// <summary>
    /// Cinema Entity
    /// </summary>
    public class Cinema
    {
        /// <summary>
        /// Cinema ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Cinema's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Cinema's location
        /// </summary>
        public Point Location { get; set; }

        /// <summary>
        /// Navigation porperty cinema offer
        /// Nos permite navegar entre entidades de una relacion.
        /// </summary>
        public CinemaOffer CinemaOffer { get; set; }

        /// <summary>
        /// Hash set of cinema halls.
        /// HashSet es mas rapido que ICollection.
        /// La desventaja de hashSet es que no ordena.
        /// </summary>
        public HashSet<CinemaHall> CinemaHalls { get; set; }
    }
}
