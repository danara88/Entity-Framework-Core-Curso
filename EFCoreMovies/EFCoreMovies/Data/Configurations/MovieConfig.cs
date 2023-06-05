using EFCoreMovies.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies.Data.Configurations
{
    /// <summary>
    /// Movie EF Core configuration
    /// </summary>
    public class MovieConfig : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(prop => prop.Title)
               .HasMaxLength(150)
               .IsRequired();
            //builder.Property(prop => prop.ReleaseDate)
            //   .HasColumnType("date");
            // Es bueno tener un campo unicode en data generada por el usuario
            builder.Property(prop => prop.PosterURL)
                .HasMaxLength(500)
                .IsUnicode(false); // Son los caracteres que vamos a aceptar en el campo ñ arabes emojis etc.. La URL solo usa caracteres ASCII
        }
    }
}
