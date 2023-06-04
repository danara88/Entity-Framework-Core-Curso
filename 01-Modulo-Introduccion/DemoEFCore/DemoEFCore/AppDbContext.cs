using DemoEFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoEFCore
{
    /// <summary>
    /// This is the db Context.
    /// It is used to configure EF Core.
    /// </summary>
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Aqui puedo configurar la base de datos que voy a utilizar
            optionsBuilder.UseSqlServer("Server=DESKTOP-LIA4EMV;Initial Catalog=DemoEFCoreUdemy;Integrated Security=True;TrustServerCertificate=True");
        }

        // Add tables here
        // Persons -> Will be the name of the table on the database
        public DbSet<Person> Persons { get; set; }
    }
}
