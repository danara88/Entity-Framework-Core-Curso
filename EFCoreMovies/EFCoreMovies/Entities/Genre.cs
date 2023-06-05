namespace EFCoreMovies.Entities
{
    /// <summary>
    /// Genre Entity
    /// </summary>
    // [Table("TableGeneros", Schema="peliculas")] Esto cambia el nombre de la tabla
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
        /// Movies hash set
        /// </summary>
        public HashSet<Movie> Movies { get; set; }
    }
}
