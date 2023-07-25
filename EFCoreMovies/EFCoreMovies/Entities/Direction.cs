using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreMovies.Entities
{
    /// <summary>
    /// Esto es un ejemplo, vamos a ignorar esta clase para que no se mapee en la
    /// base de datos
    /// </summary>
    [NotMapped] // Ignorar esta clase sea donde se coloque
    public class Direction
    {
        public string Street { get; set; }

        public string Country { get; set; }

        public string Province { get; set; }
    }
}
