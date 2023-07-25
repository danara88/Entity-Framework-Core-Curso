 using EFCoreMovies.Data;
using EFCoreMovies.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/genres")]
    public class GenresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GenresController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Genre>> Get()
        {
            // Consulta unicamente para leer los generos.
            // Query de solo lectura: Solo cuando queremos hacer lectura de datos.
            // return await _context.Genres.AsNoTracking().ToListAsync();
            // usar el .AsTracking() para sobre escribir el AsNotTracking()

            // Es mejor no generar el Guid manualmente, si no que dejar al sistema de base de datos
            // que la genere.
            _context.Logs.Add(new Log { Message = "Ejecutando metodo GenerosCOntroller.GET", Id = new Guid() });
            await _context.SaveChangesAsync();
            return await _context.Genres.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id) 
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(g => g.Id == id);
            if (genre is null)
            {
                return NotFound();
            }
            return Ok(genre);
        }

        [HttpGet("first")]
        public async Task<IActionResult> GetFirst()
        {
            // First: Si no encuentra el dato, arroja una excepcion
            // FirstOrDefault: Si no encuentra el dato, arroja null
            // return await _context.Genres.FirstAsync();
            // return await _context.Genres.FirstAsync(g => g.Name.StartsWith("Z"));
            var genre = await _context.Genres.FirstOrDefaultAsync(g => g.Name.StartsWith("Z"));
            if (genre is null)
            {
                return NotFound();
            }
            return Ok(genre);
        }

        [HttpGet("filter")]
        public async Task<IEnumerable<Genre>> Filter()
        {
            return await _context.Genres
                .Where(g => g.Name.StartsWith("C") || g.Name.StartsWith("A"))
                .OrderBy(g => g.Name)
                .ToListAsync();
        }

        [HttpGet("pagination")]
        public async Task<IActionResult> Pagination(int page = 1)
        {
            var quantityPerPage = 2;
            var genres = await _context.Genres
                .Skip((page - 1) * quantityPerPage)
                .Take(quantityPerPage)
                .ToListAsync();

            return Ok(genres);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Genre genre) 
        {
            var status1 = _context.Entry(genre).State; // Detached

            // Esto cambiando el estatus de genre a "agregado" (Esto no agrega a la base de datos solo cambia el estatus del objeto genre)
            // Solo marco el estatus como "agregado" para que cuando ejecute saveChanges, entonces se agregue el genero a la base de datos.
            _context.Add(genre);

            var status2 = _context.Entry(genre).State; // Added

            // Esto verifica todos los objetos que EF Core les esta dando seguimiento, y dependiendo del estatus hacer algo.
            await _context.SaveChangesAsync();

            var status3 = _context.Entry(genre).State; // Unchanged

            return Ok();
        }

        [HttpPost("postMultipleGenres")]
        public async Task<IActionResult> Post(Genre[] genres)
        {
            _context.AddRange(genres);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("add2")]
        public async Task<IActionResult> Add2(int id)
        {
            // Modelo desconectado.
            // Utilizo el mismo DbContext para cargar al genero y utilizo el mismo DbContext para actualizar el genero.
            var genre = await _context.Genres.AsTracking().FirstOrDefaultAsync(g => g.Id == id);

            if (genre is null)
            {
                return NotFound();
            }

            genre.Name += " 2";

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(x => x.Id == id);
            if (genre is null)
            {
                return NotFound();
            }
            _context.Remove(genre);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("softDelete/{id:int}")]
        public async Task<IActionResult> SoftDeleteGenre(int id)
        {
            var genre = await _context.Genres.AsTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (genre is null)
            {
                return NotFound();
            }
            genre.IsDeleted = true; // Model conectado, no es necesario usar el update()
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("restaurar/{id:int}")]
        public async Task<IActionResult> restaurar(int id)
        {
            // Ignore el soft delete, para restaurar el registro
            var genre = await _context.Genres.AsTracking().IgnoreQueryFilters().FirstOrDefaultAsync(x => x.Id == id);
            if (genre is null)
            {
                return NotFound();
            }
            genre.IsDeleted = false;
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
