using EFCoreMovies.Entities;
using EFCoreMovies.Enums;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace EFCoreMovies.Data.Seeding
{
    /// <summary>
    /// Seeding module
    /// In charge of setting data into database.
    /// </summary>
    public static class SeedingModuleConsult
    {
        /// <summary>
        /// Inserts default data into database
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void Seed(ModelBuilder modelBuilder)
        {
            /*
             * Genre
             */
            var action = new Genre { Id = 1, Name = "Action" };
            var animation = new Genre { Id = 2, Name = "Animation" };
            var comedy = new Genre { Id = 3, Name = "Comedy" };
            var scienceFiction = new Genre { Id = 4, Name = "Science fiction" };
            var drama = new Genre { Id = 5, Name = "Drama" };

            modelBuilder.Entity<Genre>().HasData(action, animation, comedy, scienceFiction, drama);

           /*
            * Actor
            */
            var tomHolland = new Actor() { Id = 1, Name = "Tom Holland", Birthdate = new DateTime(1996, 6, 1), Biography = "Thomas Stanley Holland (Kingston upon Thames, Londres; 1 de junio de 1996), conocido simplemente como Tom Holland, es un actor, actor de voz y bailarín británico." };
            var samuelJackson = new Actor() { Id = 2, Name = "Samuel L. Jackson", Birthdate = new DateTime(1948, 12, 21), Biography = "Samuel Leroy Jackson (Washington D. C., 21 de diciembre de 1948), conocido como Samuel L. Jackson, es un actor y productor de cine, televisión y teatro estadounidense. Ha sido candidato al premio Óscar, a los Globos de Oro y al Premio del Sindicato de Actores, así como ganador de un BAFTA al mejor actor de reparto." };
            var robertDowney = new Actor() { Id = 3, Name = "Robert Downey Jr.", Birthdate = new DateTime(1965, 4, 4), Biography = "Robert John Downey Jr. (Nueva York, 4 de abril de 1965) es un actor, actor de voz, productor y cantante estadounidense. Inició su carrera como actor a temprana edad apareciendo en varios filmes dirigidos por su padre, Robert Downey Sr., y en su infancia estudió actuación en varias academias de Nueva York." };
            var chrisEvans = new Actor() { Id = 4, Name = "Chris Evans", Birthdate = new DateTime(1981, 06, 13) };
            var laRoca = new Actor() { Id = 5, Name = "Dwayne Johnson", Birthdate = new DateTime(1972, 5, 2) };
            var auliCravalho = new Actor() { Id = 6, Name = "Auli'i Cravalho", Birthdate = new DateTime(2000, 11, 22) };
            var scarlettJohansson = new Actor() { Id = 7, Name = "Scarlett Johansson", Birthdate = new DateTime(1984, 11, 22) };
            var keanuReeves = new Actor() { Id = 8, Name = "Keanu Reeves", Birthdate = new DateTime(1964, 9, 2) };

            modelBuilder.Entity<Actor>().HasData(tomHolland, samuelJackson,
                           robertDowney, chrisEvans, laRoca, auliCravalho, scarlettJohansson, keanuReeves);

           /*
            * Cinema
            */
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            var agora = new Cinema() { Id = 1, Name = "Agora Mall", Location = geometryFactory.CreatePoint(new Coordinate(-69.9388777, 18.4839233)) };
            var sambil = new Cinema() { Id = 2, Name = "Sambil", Location = geometryFactory.CreatePoint(new Coordinate(-69.911582, 18.482455)) };
            var megacentro = new Cinema() { Id = 3, Name = "Megacentro", Location = geometryFactory.CreatePoint(new Coordinate(-69.856309, 18.506662)) };
            var acropolis = new Cinema() { Id = 4, Name = "Acropolis", Location = geometryFactory.CreatePoint(new Coordinate(-69.939248, 18.469649)) };

            modelBuilder.Entity<Cinema>().HasData(acropolis, sambil, megacentro, agora);


            /*
             * Cinema offer
             */
            var agoraCinemaOffer = new CinemaOffer { Id = 1, CinemaId = agora.Id, StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(7), DiscountPercentage = 10 };
            var acropolisCinemaOffer = new CinemaOffer { Id = 2, CinemaId = acropolis.Id, StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(5), DiscountPercentage = 15 };

            modelBuilder.Entity<CinemaOffer>().HasData(agoraCinemaOffer, acropolisCinemaOffer);

            /**
             * Cinema Hall
             */
            var cinemaHall2DAgora = new CinemaHall()
            {
                Id = 1,
                CinemaId = agora.Id,
                Price = 220,
                CinemaHallType = CinemaHallTypeEnum.TwoDimensions
            };
            var cinemaHall3DAgora = new CinemaHall()
            {
                Id = 2,
                CinemaId = agora.Id,
                Price = 320,
                CinemaHallType = CinemaHallTypeEnum.ThreeDimensions
            };
            var cinemaHall2DSambil = new CinemaHall()
            {
                Id = 3,
                CinemaId = sambil.Id,
                Price = 200,
                CinemaHallType = CinemaHallTypeEnum.TwoDimensions
            };
            var cinemaHall3DSambil = new CinemaHall()
            {
                Id = 4,
                CinemaId = sambil.Id,
                Price = 290,
                CinemaHallType = CinemaHallTypeEnum.ThreeDimensions
            };
            var cinemaHall2DMegacentro = new CinemaHall()
            {
                Id = 5,
                CinemaId = megacentro.Id,
                Price = 250,
                CinemaHallType = CinemaHallTypeEnum.TwoDimensions
            };
            var cinemaHall3DMegacentro = new CinemaHall()
            {
                Id = 6,
                CinemaId = megacentro.Id,
                Price = 330,
                CinemaHallType = CinemaHallTypeEnum.ThreeDimensions
            };
            var cinemaHallVIPMegacentro = new CinemaHall()
            {
                Id = 7,
                CinemaId = megacentro.Id,
                Price = 450,
                CinemaHallType = CinemaHallTypeEnum.VIP
            };

            var cinemaHall2DAcropolis = new CinemaHall()
            {
                Id = 8,
                CinemaId = acropolis.Id,
                Price = 250,
                CinemaHallType = CinemaHallTypeEnum.TwoDimensions
            };

            modelBuilder.Entity<CinemaHall>().HasData(cinemaHall2DAgora, cinemaHall3DAgora, cinemaHall2DSambil, cinemaHall3DSambil, cinemaHall2DMegacentro, cinemaHall3DMegacentro, cinemaHallVIPMegacentro, cinemaHall2DAcropolis);

            /**
             * Movie avengers
             */
            var avengers = new Movie()
            {
                Id = 1,
                Title = "Avengers",
                OnBillboard = false,
                ReleaseDate = new DateTime(2012, 4, 11),
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg",
            };

            var genreMovieEntity = "GenreMovie";
            var genresID = "GenresId";
            var moviesID = "MoviesId";
 
            modelBuilder.Entity(genreMovieEntity).HasData(
                new Dictionary<string, object> { [genresID] = action.Id, [moviesID] = avengers.Id },
                new Dictionary<string, object> { [genresID] = scienceFiction.Id, [moviesID] = avengers.Id }
            );

            /**
             * Movie coco
             */
            var coco = new Movie()
            {
                Id = 2,
                Title = "Coco",
                OnBillboard = false,
                ReleaseDate = new DateTime(2017, 11, 22),
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/9/98/Coco_%282017_film%29_poster.jpg"
            };

            modelBuilder.Entity(genreMovieEntity).HasData(
                new Dictionary<string, object> { [genresID] = animation.Id, [moviesID] = coco.Id }
            );

            /**
             * Movie no way home
             */
            var noWayHome = new Movie()
            {
                Id = 3,
                Title = "Spider-Man: No way home",
                OnBillboard = false,
                ReleaseDate = new DateTime(2021, 12, 17),
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg"
            };

            modelBuilder.Entity(genreMovieEntity).HasData(
               new Dictionary<string, object> { [genresID] = scienceFiction.Id, [moviesID] = noWayHome.Id },
               new Dictionary<string, object> { [genresID] = action.Id, [moviesID] = noWayHome.Id },
               new Dictionary<string, object> { [genresID] = comedy.Id, [moviesID] = noWayHome.Id }
           );

            /**
             * Movie far from home
             */
            var farFromHome = new Movie()
            {
                Id = 4,
                Title = "Spider-Man: Far From Home",
                OnBillboard = false,
                ReleaseDate = new DateTime(2019, 7, 2),
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg"
            };

            modelBuilder.Entity(genreMovieEntity).HasData(
               new Dictionary<string, object> { [genresID] = scienceFiction.Id, [moviesID] = farFromHome.Id },
               new Dictionary<string, object> { [genresID] = action.Id, [moviesID] = farFromHome.Id },
               new Dictionary<string, object> { [genresID] = comedy.Id, [moviesID] = farFromHome.Id }
            );

            /**
             * Movie the matrix resurections
             */
            var theMatrixResurrections = new Movie()
            {
                Id = 5,
                Title = "The Matrix Resurrections",
                OnBillboard = true,
                ReleaseDate = new DateTime(2100, 1, 1),
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/5/50/The_Matrix_Resurrections.jpg",
            };

            modelBuilder.Entity(genreMovieEntity).HasData(
              new Dictionary<string, object> { [genresID] = scienceFiction.Id, [moviesID] = theMatrixResurrections.Id },
              new Dictionary<string, object> { [genresID] = action.Id, [moviesID] = theMatrixResurrections.Id },
              new Dictionary<string, object> { [genresID] = drama.Id, [moviesID] = theMatrixResurrections.Id }
            );

            /**
             * Movie hall and movies relation
             */
            var cinemaHallMovieEntity = "CinemaHallMovie";
            var cinemaHallID = "CinemaHallsId";

            modelBuilder.Entity(cinemaHallMovieEntity).HasData(
                new Dictionary<string, object> { [cinemaHallID] = cinemaHall2DSambil.Id, [moviesID] = theMatrixResurrections.Id },
                new Dictionary<string, object> { [cinemaHallID] = cinemaHall3DSambil.Id, [moviesID] = theMatrixResurrections.Id },
                new Dictionary<string, object> { [cinemaHallID] = cinemaHall2DAgora.Id, [moviesID] = theMatrixResurrections.Id },
                new Dictionary<string, object> { [cinemaHallID] = cinemaHall3DAgora.Id, [moviesID] = theMatrixResurrections.Id },
                new Dictionary<string, object> { [cinemaHallID] = cinemaHall2DMegacentro.Id, [moviesID] = theMatrixResurrections.Id },
                new Dictionary<string, object> { [cinemaHallID] = cinemaHall3DMegacentro.Id, [moviesID] = theMatrixResurrections.Id },
                new Dictionary<string, object> { [cinemaHallID] = cinemaHallVIPMegacentro.Id, [moviesID] = theMatrixResurrections.Id }
            );

            modelBuilder.Entity<Movie>().HasData(avengers, coco, noWayHome, farFromHome, theMatrixResurrections);

            /*
             * Movie Actors relation
             */
            var keanuReevesMatrix = new MovieActor
            {
                ActorId = keanuReeves.Id,
                MovieId = theMatrixResurrections.Id,
                Order = 1,
                Character = "Neo"
            };

            var avengersChrisEvans = new MovieActor
            {
                ActorId = chrisEvans.Id,
                MovieId = avengers.Id,
                Order = 1,
                Character = "Capitán América"
            };

            var avengersRobertDowney = new MovieActor
            {
                ActorId = robertDowney.Id,
                MovieId = avengers.Id,
                Order = 2,
                Character = "Iron Man"
            };

            var avengersScarlettJohansson = new MovieActor
            {
                ActorId = scarlettJohansson.Id,
                MovieId = avengers.Id,
                Order = 3,
                Character = "Black Widow"
            };

            var tomHollandFFH = new MovieActor
            {
                ActorId = tomHolland.Id,
                MovieId = farFromHome.Id,
                Order = 1,
                Character = "Peter Parker"
            };

            var tomHollandNWH = new MovieActor
            {
                ActorId = tomHolland.Id,
                MovieId = noWayHome.Id,
                Order = 1,
                Character = "Peter Parker"
            };

            var samuelJacksonFFH = new MovieActor
            {
                ActorId = samuelJackson.Id,
                MovieId = farFromHome.Id,
                Order = 2,
                Character = "Samuel L. Jackson"
            };

            modelBuilder.Entity<MovieActor>().HasData(samuelJacksonFFH, tomHollandFFH, tomHollandNWH, avengersRobertDowney, avengersScarlettJohansson,
               avengersChrisEvans, keanuReevesMatrix);
        }
    }
}
