using System;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Services;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieListsController : ControllerBase
    {

        private IMovieListService _movieListService;

        public MovieListsController(
            IMovieListService movieListService)
        {
            _movieListService = movieListService;

        }

        [HttpGet("{id}")]
        public IActionResult GetAllByUserId(int id)
        {
            var strands =  _movieListService.GetAllByUserId(id);
            return Ok(strands);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody]MovieList movieList)
        {
            try
            {
                // save
                _movieListService.Create(movieList);
                return Ok();
            }
            catch(AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
