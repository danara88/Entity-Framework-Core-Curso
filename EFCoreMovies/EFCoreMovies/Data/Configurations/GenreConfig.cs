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
        }
    }
}
