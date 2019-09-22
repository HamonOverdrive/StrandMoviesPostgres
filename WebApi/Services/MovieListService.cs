using WebApi.Helpers;
using System.Linq;
using WebApi.Entities;
namespace WebApi.Services
{
    public interface IMovieListService
    {
        MovieList Create(MovieList movieList);
    }
    public class MovieListService : IMovieListService
    {
        private DataContext _context;
        public MovieListService(DataContext context)
        {
            _context = context;
        }


        public MovieList Create(MovieList movieList)
        {
            var currentUser = _context.Users.Find(movieList.UserId);

            movieList.User = currentUser;

            _context.MovieLists.Add(movieList);
            _context.SaveChanges();

            return movieList;
        }
    }
}
