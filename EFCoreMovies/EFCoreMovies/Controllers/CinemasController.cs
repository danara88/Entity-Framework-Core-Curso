using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreMovies.Data;
using EFCoreMovies.DTOs;
using EFCoreMovies.Entities;
using EFCoreMovies.Entities.NotKeys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/cinemas")]
    public class CinemasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CinemasController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("WithNotLocation")]
        public async Task<IActionResult> GetCinemasWithNotLocation()
        {
            // var result = await _context.Set<CinemaWithNotLocation>().ToListAsync();
            var result = await _context.CinemaWithNotLocation.ToListAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cinemasDTO = await _context.Cinemas.ProjectTo<CinemaDTO>(_mapper.ConfigurationProvider).ToListAsync();
            return Ok(cinemasDTO);
        }

        [HttpGet("closer")]
        public async Task<IActionResult> Closer(double longitude, double latitude)
        {
            // srid: 4326 Hace mediciones en la tierra.
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            var myLocation = geometryFactory.CreatePoint(new Coordinate(longitude, latitude));
            var maxDistanceMeters = 2000;

            var cinemas = await _context.Cinemas
                .OrderBy(c => c.Location.Distance(myLocation))
                .Where(c => c.Location.IsWithinDistance(myLocation, maxDistanceMeters))
                .Select(c => new { Name = c.Name, Distance = Math.Round(c.Location.Distance(myLocation)) })
                .ToListAsync();

            return Ok(cinemas);
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            var cinemaLocation = geometryFactory.CreatePoint(new Coordinate(-69.896979, 18.476276));

            // Entidad principal = Cinema
            // Las entidades secundarias tambien se van a crear

            var cinema = new Cinema
            {
                Name = "New Cinema con monedas",
                Location = cinemaLocation,
                CinemaOffer = new CinemaOffer
                {
                    DiscountPercentage = 5,
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Today.AddDays(7)
                },
                CinemaHalls = new HashSet<CinemaHall>()
                {
                    new CinemaHall
                    {
                        Price = 200,
                        Currency = Currency.Pesos,
                        CinemaHallType = Enums.CinemaHallTypeEnum.TwoDimensions
                    },
                    new CinemaHall
                    {
                        Price = 350,
                        Currency = Currency.USDollar,
                        CinemaHallType = Enums.CinemaHallTypeEnum.ThreeDimensions
                    },
                }
            };

            _context.Add(cinema);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("withDTO")]
        public async Task<IActionResult>Post(CreateCinemaDTO createCinemaDTO)
        {
            var cinema = _mapper.Map<Cinema>(createCinemaDTO);
            _context.Add(cinema);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
