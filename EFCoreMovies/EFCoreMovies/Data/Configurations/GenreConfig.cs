using EFCoreMovies.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies.Data.Configurations
{
    /// <summary>
    /// Genre EF Core configuration
    /// </summary>
    public class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            // modelBuilder.Entity<Genre>().HasKey(prop => prop.GenreID);
            // modelBuilder.Entity<Genre>().ToTable(name: "TableGeneros", schema: "Peliculas");
            builder.Property(prop => prop.Name)
                // .HasColumnName("NombreGenero")
                .HasMaxLength(150)
                .IsRequired();

            // Este es un filtro a nivel de modelo
            builder.HasQueryFilter(prop => !prop.IsDeleted); // Para utilizar el borrado logico

            builder.HasIndex(prop => prop.Name)
                .HasFilter("IsDeleted = 'false'")
                .IsUnique(); // Crea un indice para Name

            // Configurando una propiedad sombra
            //builder.Property<DateTime>("CreatedOnShadow")
            //    .HasDefaultValueSql("GetDate()")
            //    .HasColumnType("datetime2");
        }
    }
}
