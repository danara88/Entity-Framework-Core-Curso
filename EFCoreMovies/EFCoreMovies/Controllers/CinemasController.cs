using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreMovies.Data;
using EFCoreMovies.DTOs;
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
    }
}
