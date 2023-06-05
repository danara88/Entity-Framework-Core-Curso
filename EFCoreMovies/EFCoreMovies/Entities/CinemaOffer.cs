namespace EFCoreMovies.Entities
{
    /// <summary>
    /// Cinema offert
    /// </summary>
    public class CinemaOffer
    {
        /// <summary>
        /// Cinema Offer ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Cinema offer start date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Cinema offer end date
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Cinema offer discount percentage
        /// </summary>
        public decimal DiscountPercentage { get; set; }

        /// <summary>
        /// Cinema ID
        /// </summary>
        public int CinemaId { get; set; }
    }
}
