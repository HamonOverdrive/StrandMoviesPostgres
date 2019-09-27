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


        [HttpGet("{id}")]
        public IActionResult GetAllFromCurrentStrand(int strandid)
        {
            var allmovies =  _movieService.GetAllFromCurrentStrand(strandid);
            return Ok(allmovies);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Movie movie, [FromQuery]string listId)
        {
            int convertedId = Convert.ToInt32(listId);
            var mov = _movieService.Create(movie, convertedId);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _movieService.Delete(id);
            return Ok();
        }
    }
}
