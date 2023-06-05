using EFCoreMovies.Entities;
using EFCoreMovies.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies.Data.Configurations
{
    /// <summary>
    /// CinemaHall EF Core configuration
    /// </summary>
    public class CinemaHallConfig : IEntityTypeConfiguration<CinemaHall>
    {
        public void Configure(EntityTypeBuilder<CinemaHall> builder)
        {
            builder.Property(prop => prop.Price)
               .HasPrecision(precision: 9, scale: 2);
            builder.Property(prop => prop.CinemaHallType)
                .HasDefaultValue(CinemaHallTypeEnum.TwoDimensions);
        }
    }
}
