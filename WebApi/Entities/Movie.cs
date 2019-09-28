
namespace WebApi.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Rated { get; set; }
        public string Released { get; set; }
        public string Genre { get; set; }

        public string Director { get; set; }
        public string Writer { get; set; }

        public string Plot { get; set; }
        public string Poster { get; set; }
        public string MetaScore { get; set; }
        public int CurrentRate { get; set; }

        public MovieList MovieList { get; set; }

    }
}
