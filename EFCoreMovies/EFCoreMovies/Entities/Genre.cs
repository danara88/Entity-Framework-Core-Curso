using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Entities
{
    /// <summary>
    /// Genre Entity
    /// </summary>
    // [Table("TableGeneros", Schema="peliculas")] Esto cambia el nombre de la tabla
    // [Index(nameof(Name), IsUnique = true)] // Name debe ser unico
    public class Genre
    {
        /// <summary>
        /// Genre ID
        /// </summary>
        // [Key]
        public int Id { get; set; }

        /// <summary>
        /// Genre Name
        /// </summary>
        // [StringLength(150)] Es lo mismo
        // [MaxLength(150)] Es lo mismo
        // [Required]
        // [Column("NombreGenero")] Esto cambia el nombre de la columna
        public string Name { get; set; }

        /// <summary>
        /// Genre deleted status
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Movies hash set
        /// </summary>
        public HashSet<Movie> Movies { get; set; }
    }
}
