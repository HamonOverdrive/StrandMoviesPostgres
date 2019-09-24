using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;
using System.Net.Http;
using Newtonsoft.Json;
using AutoMapper;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public interface IMovieService
    {
         Task<Movie> GetByTitle();
         IEnumerable<Movie> GetAllFromCurrentStrand(int strandid);
    }

    public class MovieService : IMovieService
    {
        private DataContext _context;
        private readonly IHttpClientFactory _clientFactory;
        private IMapper _mapper;

        public MovieService(DataContext context, IMapper mapper, IHttpClientFactory clientFactory)
        {
            _context = context;
            _mapper = mapper;
            _clientFactory = clientFactory;
        }

        // example request look like http://www.omdbapi.com/?i=tt3896198&apikey=27630fb
        // request by title name and convert to json and map to movie object
        public async Task<Movie> GetByTitle()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            "?t=kara+no+kyoukai&apikey=27630fb");

            var client = _clientFactory.CreateClient("omdb");
            var response = await client.SendAsync(request);

            string responseBody = await response.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<object>(responseBody);
            Movie testMovie = _mapper.Map<Movie>(json);
            Console.Write(responseBody);
            Console.WriteLine(testMovie.Title);
            _context.Movies.Add(testMovie);
            await _context.SaveChangesAsync();

             Console.WriteLine("Save Complete");

            return testMovie;
        }

        public IEnumerable<Movie> GetAllFromCurrentStrand(int strandid)
        {
            return _context.Movies.Where(x => x.MovieList.Id == strandid).ToList();
        }


    }
}
