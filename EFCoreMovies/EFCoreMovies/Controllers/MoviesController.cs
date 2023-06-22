using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreMovies.Data;
using EFCoreMovies.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Controllers
{
    /**
     * Maneras para cargar data relacionada:
     * 
     * Que es el eager loding?
     * Consiste en cargar data relacionada manualmente. (Eficiente)
     *  
     * Que es explicit loading?
     * Consiste en cargar la data relacionada posterior a la carga de la entidad principal.
     * Ex. Podemo scargar primero la pelicula y luego la data relacionada. (Eficiente)
     * 
     * Que es el select Loading?
     * Tecnica para cargar data relacionada. Nos permite indicar las columnas de una tabla y cargar data relacionada.
     * 
     * Que es Lazy Loading?
     * Es una tecnica done al acceder a una propiedad de navegacion, si la data relacionada no ha sido cargada, se carga desde
     * la base de datos. Sin embargo, si ya fue cargada se se usa la que se encuentra en memoria.
     * Puede ser deficiente en general es mas lento hacer varios queries separados.
     * Para esto debemos instala un paquete llamado .Proxies A cada una de nuestras entidades todas las propiedades de navegacion deben ser
     * "virtual". 
     * Lazy Loading hace una query por cada propiedad de navegacion si no se ha cargado con anterioridad.
     * 
     */
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public MoviesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            // ThenInclude: Entra dentro de CinemaHalls y accede a la propiedad de navegacion de CinemaHalls que en este caso es Cinema
            var movie = await _context.Movies
                .Include(m => m.Genres.OrderByDescending(g => g.Name))
                .Include(m => m.CinemaHalls)
                    .ThenInclude(cinemaHall => cinemaHall.Cinema)
                .Include(m => m.MoviesActors.Where(ma => ma.Actor.Birthdate.Value.Year >= 1980))
                    .ThenInclude(movieActor => movieActor.Actor)
                .FirstOrDefaultAsync(m => m.Id == id);

            if(movie is null)
            {
                return NotFound();
            }

            var movieDTO = _mapper.Map<MovieDTO>(movie);

            movieDTO.Cinemas = movieDTO.Cinemas.DistinctBy(x => x.Id).ToList();

            return Ok(movieDTO);
        }

        [HttpGet("withProjectTo{id:int}")]
        public async Task<IActionResult> GetProjectTo(int id)
        {
            // ThenInclude: Entra dentro de CinemaHalls y accede a la propiedad de navegacion de CinemaHalls que en este caso es Cinema
            var movie = await _context.Movies
                .ProjectTo<MovieDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie is null)
            {
                return NotFound();
            }

            movie.Cinemas = movie.Cinemas.DistinctBy(x => x.Id).ToList();

            return Ok(movie);
        }

        [HttpGet("select/{id:int}")]
        public async Task<IActionResult> GetSelect(int id)
        {
            var movie = await _context.Movies
                .Select(m => new 
                { 
                    Id = m.Id, 
                    Title = m.Title, 
                    ActorsQuantity = m.MoviesActors.Count(),
                    CinemasQuantity = m.CinemaHalls.Select(ch => ch.CinemaId).Distinct().Count(),
                    Genres = m.Genres.OrderByDescending(g => g.Name).Select(g => g.Name).ToList() 
                })
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie is null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpGet("ExplicitLoading/{id:int}")]
        public async Task<IActionResult> ExplicitLoading(int id)
        {
            var movie = await _context.Movies.AsTracking().FirstOrDefaultAsync(m => m.Id == id);

            // Aqui se hacen 2 queries, uno para pelicula y otra para generos.
            // Esto es util cuando queremos separar la carga de la entidad principal de la data relacionada.
            // Desventaja: No son muy eficientes porque tienes que volver a cargar la entidad principal.
            // Es mas lento al hacer varias consultas. Todo lo podemos hacer desde una sola consulta
            await _context.Entry(movie).Collection(m => m.Genres).LoadAsync(); // Explicit loading

            var quantityGenres = await _context.Entry(movie).Collection(m => m.Genres).Query().CountAsync();
          
            if (movie is null)
            {
                return NotFound();
            }

            var movieDTO = _mapper.Map<MovieDTO>(movie);

            return Ok(movieDTO);
        }

        [HttpGet("GroupByOnBillboard")]
        public async Task<IActionResult> GroupByOnBillboard()
        {
            var groupedMovies = await _context.Movies.GroupBy(m => m.OnBillboard).Select(m => new
            {
                OnBillboard = m.Key, // OnBillboard value (True or False),
                Quantity = m.Count(),
                Movies = m.ToList()
            }).ToListAsync();

            return Ok(groupedMovies);
        }

        [HttpGet("GroupByGenresQuantity")]
        public async Task<IActionResult> GroupByGenresQuantity()
        {
            // SelectMany: Me permite aplanar una coleccion de colecciones, en una sola coleccion
            var groupedMovies = await _context.Movies.GroupBy(m => m.Genres.Count()).Select(m => new
            {
                Quantity = m.Key,
                Titles = m.Select(x => x.Title),
                Genres = m.Select(m => m.Genres)
                    .SelectMany(genre => genre) // Esta colocando los genres en una sola coleccion
                    .Select(g => g.Name) // Selecciono solo el nombre
                    .Distinct() // No quiero generos repetidos
            }).ToListAsync();

            return Ok(groupedMovies);
        }

        [HttpGet("Filter")]
        public async Task<IActionResult> Filter([FromQuery] MoviesFilterDTO input)
        {
            // Esto es ejecucion diferida
            // Este tipo de dato nos permite ir construyendo nuestras queries paso a paso y al final ejecutarlo una sola vez.
            var moviesQueryable = _context.Movies.AsQueryable();

            if (!string.IsNullOrEmpty(input.Title))
            {
                moviesQueryable = moviesQueryable.Where(m => m.Title.Contains(input.Title));
            }

            if (input.OnBillboard)
            {
                moviesQueryable = moviesQueryable.Where(m => m.OnBillboard);
            }

            if (input.NextReleases)
            {
                var today = DateTime.Today;
                moviesQueryable = moviesQueryable.Where(m => m.ReleaseDate > today);
            }

            if (input.GenreId != 0)
            {
                moviesQueryable = moviesQueryable.Where(m => m.Genres.Select(g => g.Id).Contains(input.GenreId));
            }

            var movies = await moviesQueryable.Include(m => m.Genres).ToListAsync(); // Ejecutar la query

            return Ok(_mapper.Map<List<MovieDTO>>(movies));
        }
    }
}
