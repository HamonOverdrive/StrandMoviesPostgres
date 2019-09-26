using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.Helpers;
using WebApi.Entities;
using WebApi.Dtos;
using Newtonsoft.Json;

namespace WebApi.Services
{
    public interface IOMDBService
    {
         Task<List<MovieDto>> MovieSearchQuery(string input);
    }

    public class OMDBService : IOMDBService
    {
        private DataContext _context;
        private readonly IHttpClientFactory _clientFactory;
        private IMapper _mapper;

        public OMDBService(DataContext context, IMapper mapper, IHttpClientFactory clientFactory)
        {
            _context = context;
            _mapper = mapper;
            _clientFactory = clientFactory;
        }

        // takes in movie string and queries search from omdb api
        public async Task<List<MovieDto>> MovieSearchQuery(string input)
        {

            var encoded = Uri.EscapeUriString(input);
            var request = new HttpRequestMessage(HttpMethod.Get,
            $"?s={encoded}&page=1&apikey=27630fb");

            var client = _clientFactory.CreateClient("omdb");
            var response = await client.SendAsync(request);

            string responseBody = await response.Content.ReadAsStringAsync();

            dynamic movieQuery = JsonConvert.DeserializeObject<dynamic>(responseBody);

            var movies = _mapper.Map<List<MovieDto>>(movieQuery.Search);

            foreach(var mov in movies)
            {
                Console.Write(mov.Title);
            }
             Console.WriteLine("Save Complete");

            return movies;
        }
    }
}
