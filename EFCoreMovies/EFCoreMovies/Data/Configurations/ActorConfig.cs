using EFCoreMovies.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies.Data.Configurations
{
    /// <summary>
    /// Actor EF Core configuration
    /// </summary>
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(prop => prop.Name)
              .HasMaxLength(150)
              .IsRequired();
            //modelBuilder.Entity<Actor>().Property(prop => prop.Birthdate)
            //    .HasColumnType("date");

            // Mapeo flexible
            builder.Property(prop => prop.Name).HasField("_name");

            // Ignorando una propiedad de una entidad
            // builder.Ignore(prop => prop.Age);

            // Ignorando una clase completa
            // builder.Ignore(prop => prop.Direction);
        }
    }
}
