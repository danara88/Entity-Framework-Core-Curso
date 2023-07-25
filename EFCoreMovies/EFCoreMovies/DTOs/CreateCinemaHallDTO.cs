using EFCoreMovies.Enums;

namespace EFCoreMovies.DTOs
{
    public class CreateCinemaHallDTO
    {
        public decimal Price { get; set; }

        public CinemaHallTypeEnum CinemaHallType { get; set; }
    }
}
