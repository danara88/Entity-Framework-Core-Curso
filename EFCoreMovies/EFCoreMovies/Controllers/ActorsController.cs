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

        [HttpPost]
        public async Task<IActionResult> Post(CreateActorDTO createActorDTO)
        {
            var actor = _mapper.Map<Actor>(createActorDTO);
            _context.Add(actor);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("conectado/{id:int}")]
        public async Task<IActionResult> Put(CreateActorDTO createActorDTO, int id)
        {
            var actorDB = await _context.Actors.AsTracking().FirstOrDefaultAsync(a => a.Id == id);
            if (actorDB is null)
            {
                return NotFound();
            }
            // El mapper nos ayuda a mappear de un objeto a otro.
            // Aqui estamos mapeando de createActorDTO a actorDB
            // Estamos manteniendo en memoria actorDB, solo estamos modificando el valor de las propiedades de actorDB que mandamos por createActorDTO.
            // No Estamos cambiando la instancia de actorDB.
            // Estos es util porque asi EFCore le puede seguir dando seguimiento a actorDB,
            // de este modo EF Core va a saber que el estatus de actorDB va a ser modificado. (Modelo conectado)
            // Y como es modificado al hacer saveChanges, se van a modifica los datos.
            actorDB = _mapper.Map(createActorDTO, actorDB);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("desconectado/{id:int}")]
        public async Task<IActionResult> PutDesconectado(CreateActorDTO createActorDTO, int id)
        {
            // Modelo desconectado
            // 1. Primero yo cargo la entidad con un dbContext
            // 2. Luego con otra instancia del dbContext hago la operacion de actualizacion
            var actorExists = await _context.Actors.AnyAsync(x => x.Id == id);

            if (!actorExists)
            {
                return NotFound();
            }

            var actor = _mapper.Map<Actor>(createActorDTO);
            actor.Id = id;

            _context.Update(actor); // Poner el estatus como modificado
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
