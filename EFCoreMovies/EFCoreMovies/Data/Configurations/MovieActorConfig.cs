using EFCoreMovies.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies.Data.Configurations
{
    /// <summary>
    /// MovieActor EF Core configuration
    /// </summary>
    public class MovieActorConfig : IEntityTypeConfiguration<MovieActor>
    {
        public void Configure(EntityTypeBuilder<MovieActor> builder)
        {
           builder.HasKey(prop => new { prop.MovieId, prop.ActorId });
           builder.Property(prop => prop.Character)
                .HasMaxLength(150);
        }
    }
}
