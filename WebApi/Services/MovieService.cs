using WebApi.Entities;
using WebApi.Helpers;
using System.Net.Http;

namespace WebApi.Services
{
    public interface IMovieService
    {
        void GetByTitle(string title);
    }

    public class MovieService : IMovieService
    {
        private DataContext _context;
        private readonly IHttpClientFactory _clientFactory;

        public MovieService(DataContext context, IHttpClientFactory clientFactory)
        {
            _context = context;
            _clientFactory = clientFactory;
        }


        public void GetByTitle(string title)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            "t=kara+no+kyoukai");
            var client = _clientFactory.CreateClient("omdb");
            // var response = await client.SendAsync(request);
            var response = client.SendAsync(request);
            Console.Write(response);

        }


    }
}
