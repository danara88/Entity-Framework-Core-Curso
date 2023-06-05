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
        }
    }
}
