using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebApi.Services;
using WebApi.Helpers;
using WebApi.Entities;


namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private IMovieService _movieService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
        public MoviesController(
            IMovieService movieService,
            IMapper mapper,
            IOptions<AppSettings> appSettings
            )
        {
            _movieService = movieService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
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

        [HttpPut("updaterate/{id}")]
        public IActionResult UpdateCurrentRate(int id, [FromBody] Movie movieR)
        {
            try
            {
                // save
                _movieService.UpdateCurrentRate(movieR);
                return Ok();
            }
            catch(AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _movieService.Delete(id);
            return Ok();
        }

    }
}
