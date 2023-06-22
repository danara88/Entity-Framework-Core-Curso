using EFCoreMovies.Data.Configurations;
using EFCoreMovies.Data.Seeding;
using EFCoreMovies.Entities;
using EFCoreMovies.Enums;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EFCoreMovies.Data
{
    /// <summary>
    /// Application DB Context
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Convenciones: Podemos configurar aqui las convenciones por default de EF Core.
        /// Podemos sobreescribir la convencion en el onModelCreating
        /// </summary>
        /// <param name="configurationBuilder"></param>
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            // Siempre que agreguemos un campo dateTime, en SQL sera mapeado de tipo date
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }

        /// <summary>
        /// Metodo para configurar el API fluente
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aqui puedo configurar mis identidades y sus propiedades
            // El APi Fluente puede hacer cosas que no se pueden hacer por atributos

            // Quiere decir que escanea el ensamble actual (el proyecto actual) y toma todas esas clases que heredan de IEntityTypeConfiguration
            // y aplicalas en nuestro API fluente.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //modelBuilder.ApplyConfiguration(new GenreConfig());

            //modelBuilder.ApplyConfiguration(new ActorConfig());

            //modelBuilder.ApplyConfiguration(new CinemaConfig());

            //modelBuilder.ApplyConfiguration(new MovieConfig());

            //modelBuilder.ApplyConfiguration(new CinemaOfferConfig());

            //modelBuilder.ApplyConfiguration(new CinemaHallConfig());

            //modelBuilder.ApplyConfiguration(new MovieActorConfig());

            // Para ejecutar la seed, tenemos que hacer una migracion
            SeedingModuleConsult.Seed(modelBuilder);
        }

        // Add your tables here
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<CinemaOffer> CinemaOffers { get; set; }
        public DbSet<CinemaHall> CinemaHalls { get; set; }
        public DbSet<MovieActor> MoviesActors { get; set; }
    }
}
