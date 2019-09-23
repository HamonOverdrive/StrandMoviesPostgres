using WebApi.Helpers;
using System.Linq;
using System.Collections.Generic;
using WebApi.Entities;
namespace WebApi.Services
{
    public interface IMovieListService
    {
        MovieList Create(MovieList movieList);
        IEnumerable<MovieList> GetAllByUserId(int id);
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


        public IEnumerable<MovieList> GetAllByUserId(int id)
        {
            return _context.MovieLists.Where(x => x.UserId == id).ToList();
        }
    }
}
