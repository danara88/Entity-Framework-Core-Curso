using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Entities.NotKeys
{
    [Keyless]
    public class CinemaWithNotLocation
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
