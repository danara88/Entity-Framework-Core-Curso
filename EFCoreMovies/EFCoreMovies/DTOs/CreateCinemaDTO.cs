using System.ComponentModel.DataAnnotations;

namespace EFCoreMovies.DTOs
{
    public class CreateCinemaDTO
    {
        [Required]
        public string Name { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public CreateCinemaOfferDTO CinemaOffer { get; set; }

        public HashSet<CreateCinemaHallDTO> CinemaHalls { get; set; }
    }
}
