using System.ComponentModel.DataAnnotations;

namespace EFCoreMovies.DTOs
{
    public class CreateCinemaOfferDTO
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Range(1, 100)]
        public decimal DiscountPercentage { get; set; }
    }
}
