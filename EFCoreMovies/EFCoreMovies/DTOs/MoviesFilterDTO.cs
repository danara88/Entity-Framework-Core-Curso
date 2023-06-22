namespace EFCoreMovies.DTOs
{
    public class MoviesFilterDTO
    {
        public string Title { get; set; }

        public int GenreId { get; set; }

        public bool OnBillboard { get; set; }

        public bool NextReleases { get; set; }
    }
}
