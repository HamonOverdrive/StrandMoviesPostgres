using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Services;
using WebApi.Helpers;


namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OMDBController : ControllerBase
    {
        private IOMDBService _omdbService;

        public OMDBController(
            IOMDBService omdbService)
        {
            _omdbService = omdbService;

        }

        [HttpGet("findimdb/{imdbID}")]
        public async Task<IActionResult> getByImdb(string imdbID)
        {
            var mov =  await _omdbService.getByImdb(imdbID);
            return Ok(mov);
        }

        [HttpGet("/search/")]
        public async Task<IActionResult> MovieSearchQuery([FromQuery]string input)
        {
            var result =  await _omdbService.MovieSearchQuery(input);
            return Ok(result);
        }
    }
}
