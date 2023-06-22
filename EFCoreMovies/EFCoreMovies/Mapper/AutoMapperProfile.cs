using AutoMapper;
using EFCoreMovies.DTOs;
using EFCoreMovies.Entities;

namespace EFCoreMovies.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Actor, ActorDTO>().ReverseMap();
            CreateMap<Cinema, CinemaDTO>()
                .ForMember(dto => dto.Latitude, ent => ent.MapFrom(prop => prop.Location.Y))
                .ForMember(dto => dto.Longitude, ent => ent.MapFrom(prop => prop.Location.X))
                .ReverseMap();
            CreateMap<Genre, GenreDTO>().ReverseMap();

            // El projectTo respeta esta configuracion
            // Configuracion sin projectTo
            CreateMap<Movie, MovieDTO>()
                .ForMember(dto => dto.Cinemas, ent => ent.MapFrom(prop => prop.CinemaHalls.Select(ch => ch.Cinema)))
                .ForMember(dto => dto.Actors, ent => ent.MapFrom(prop => prop.MoviesActors.Select(ma => ma.Actor)));

            // Configuracion con projectTo
            //CreateMap<Movie, MovieDTO>()
            //  .ForMember(dto => dto.Cinemas, ent => ent.MapFrom(prop => prop.CinemaHalls.Select(ch => ch.Cinema)))
            //  .ForMember(dto => dto.Actors, ent => ent.MapFrom(prop => prop.MoviesActors.Select(ma => ma.Actor)))
            //  .ForMember(dto => dto.Genres, ent => ent.MapFrom(prop => prop.Genres.OrderByDescending(g => g.Name)));
        }
    }
}
