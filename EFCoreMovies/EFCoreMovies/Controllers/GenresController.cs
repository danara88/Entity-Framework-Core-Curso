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
    }
}
