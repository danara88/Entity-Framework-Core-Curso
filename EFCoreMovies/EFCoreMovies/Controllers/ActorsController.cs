using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreMovies.Data;
using EFCoreMovies.DTOs;
using EFCoreMovies.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Controllers
{
    [Route("api/actors")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ActorsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Select: Me permite mapear de Actor a otro tipo de dato
            //List<ActorDTO> actors = await _context.Actors.Select(a => new ActorDTO
            //{
            //    Id = a.Id,
            //    Name = a.Name,
            //}).ToListAsync();

            var actorsDTO =  await _context.Actors.ProjectTo<ActorDTO>(_mapper.ConfigurationProvider).ToListAsync();
            return Ok(actorsDTO);
        }
    }
}
