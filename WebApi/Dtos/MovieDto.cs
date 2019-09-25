using System.Collections.Generic;
using WebApi.Entities;
namespace WebApi.Dtos
{
    public class MovieDto
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Poster { get; set; }
        public string imdbID { get; set; }
    }
}
