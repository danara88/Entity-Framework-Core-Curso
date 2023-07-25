using AutoMapper;
using EFCoreMovies.DTOs;
using EFCoreMovies.Entities;
using NetTopologySuite;
using NetTopologySuite.Geometries;

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
            CreateMap<Genre, GenreDTO>();

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

            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            CreateMap<CreateCinemaDTO, Cinema>()
                .ForMember(ent => ent.Location, 
                           dto => dto.MapFrom(prop => geometryFactory.CreatePoint(new Coordinate(prop.Longitude, prop.Latitude))));
            CreateMap<CreateCinemaOfferDTO, CinemaOffer>();
            CreateMap<CreateCinemaHallDTO, CinemaHall>();

            CreateMap<CreateMovieDTO, Movie>()
                .ForMember(ent => ent.Genres, dto => dto.MapFrom(prop => prop.Genres.Select(id => new Genre() { Id = id })))
                .ForMember(ent => ent.CinemaHalls, dto => dto.MapFrom(prop => prop.CinemaHalls.Select(id => new CinemaHall() { Id = id })));

            CreateMap<CreateMovieActorDTO, MovieActor>();

            CreateMap<CreateActorDTO, Actor>();
        }
    }
}
