using EFCoreDemoUdemyApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemoUdemyApi
{
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Aqui estamos utilizando el sistema de inyeccion de dependencias de ASP.NET
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        // Add tables

        public DbSet<Person> Persons { get; set; }
    }
}
