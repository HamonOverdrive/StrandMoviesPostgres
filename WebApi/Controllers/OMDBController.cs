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

        [HttpGet("/search/")]
        public async Task<IActionResult> MovieSearchQuery()
        {
            var result =  await _omdbService.MovieSearchQuery();
            return Ok(result);
        }
    }
}
