using System;
using WebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebApi.Services;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private IMovieService _movieService;
        private IMapper _mapper;
        public MoviesController(
            IMovieService movieService,
            IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        [HttpPost("kara")]
        public async Task<IActionResult> GetByTitle()
        {
           var mov =  await _movieService.GetByTitle();

            return Ok();
        }
    }
}
