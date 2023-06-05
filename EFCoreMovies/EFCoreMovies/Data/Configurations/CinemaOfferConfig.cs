using EFCoreMovies.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies.Data.Configurations
{
    /// <summary>
    /// CinemaOffer EF Core configuration
    /// </summary>
    public class CinemaOfferConfig : IEntityTypeConfiguration<CinemaOffer>
    {
        public void Configure(EntityTypeBuilder<CinemaOffer> builder)
        {
           builder.Property(prop => prop.DiscountPercentage)
              .HasPrecision(precision: 5, scale: 2);
            //modelBuilder.Entity<CinemaOffer>().Property(prop => prop.StartDate)
            //    .HasColumnType("date");
            //modelBuilder.Entity<CinemaOffer>().Property(prop => prop.EndDate)
            //   .HasColumnType("date");
        }
    }
}
