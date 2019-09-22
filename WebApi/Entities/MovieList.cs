using System.Collections.Generic;

namespace WebApi.Entities
{
    public class MovieList
    {
        public int Id { get; set; }
        public string ListName { get; set; }

        public ICollection<Movie> Movies { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
