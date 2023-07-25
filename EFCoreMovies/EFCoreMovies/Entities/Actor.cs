using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreMovies.Entities
{
    /// <summary>
    /// Actor Entity
    /// </summary>
    public class Actor
    {
        /// <summary>
        /// Actor ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Mapeo flexible
        /// </summary>
        private string _name;

        /// <summary>
        /// Actor's name
        /// </summary>
        public string Name {
            get
            {
                return _name;
            }
            set
            {
                _name = string.Join(' ', value.Split(' ')
                    .Select(x => x[0].ToString().ToUpper() + x.Substring(1).ToLower())
                    .ToArray());
            } 
        }

        /// <summary>
        /// Actor's biography
        /// </summary>
        public string Biography { get; set; }

        /// <summary>
        /// Actor's birthdate
        /// </summary>
        /// datetime2 -> Significa que en la tabla tambien se guardara la hora
        //[Column(TypeName = "Date")]
        public DateTime? Birthdate { get; set; } // Utilizando ? permitimos nulo

        /// <summary>
        /// Picture URL for actor
        /// </summary>
        public string PictureURL { get; set; }

        /// <summary>
        /// MaviesActors navigation property
        /// </summary>
        public HashSet<MovieActor> MoviesActors { get; set; }

        [NotMapped] // No se va a agregar a la tabla como propiedad
        public int? Age
        { 
            get
            {
                var birthDate = Birthdate.Value;
                var age = DateTime.Today.Year - birthDate.Year;

                // Si estamos antes de su dia de cumple restamos 1 a edad
                if (new DateTime(DateTime.Today.Year, birthDate.Month, birthDate.Day) > DateTime.Today)
                {
                    age--;
                }
                return age;
            }
        }

        /// <summary>
        /// Esta clase sera ignorada
        /// </summary>
        public Direction Direction { get; set; }
    }
}
