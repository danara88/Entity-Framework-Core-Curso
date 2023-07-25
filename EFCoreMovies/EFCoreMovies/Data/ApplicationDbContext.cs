using EFCoreMovies.Data.Configurations;
using EFCoreMovies.Data.Seeding;
using EFCoreMovies.Entities;
using EFCoreMovies.Entities.NotKeys;
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

            // modelBuilder.Entity<Log>().Property(prop => prop.Id).ValueGeneratedNever();

            // Ignorando la clase Direction
            // modelBuilder.Ignore<Direction>();

            modelBuilder.Entity<CinemaWithNotLocation>().ToSqlQuery("Select Id, Name from Cinemas")
                //.HasNoKey()
                .ToView(null); // Para que no se agregue una tabla en la bd con el esquema de CinemaWithoutLocation

            // Load data from a VIEW
            modelBuilder.Entity<MovieWithQuantities>()
                .HasNoKey()
                .ToView("CountMoviesView");

            // Aplicando una configuracion de no unicode a las propiedades que contengan el nombre URL
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var prop in entityType.GetProperties())
                {
                    if(prop.ClrType == typeof(string) && prop.Name.Contains("URL", StringComparison.CurrentCultureIgnoreCase))
                    {
                        prop.SetIsUnicode(false);
                        prop.SetMaxLength(500);
                    }
                }
            }
        }

        // Add your tables here
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<CinemaOffer> CinemaOffers { get; set; }
        public DbSet<CinemaHall> CinemaHalls { get; set; }
        public DbSet<MovieActor> MoviesActors { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<CinemaWithNotLocation> CinemaWithNotLocation { get; set; }
    }
}
