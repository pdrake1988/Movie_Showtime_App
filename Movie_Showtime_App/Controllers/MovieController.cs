using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movie_Showtime_App.Core.Services;
using Movie_Showtime_App.API_Models;
using Movie_Showtime_App.Core.Models;

namespace Movie_Showtime_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var movies = _movieService.GetAll().ToList();
            return Ok(movies.ToApiModels());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var movie = _movieService.Get(id);
                if (movie == null) return NotFound();
                return Ok(movie.ToApiModel());
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Get", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Movie movie)
        {
            try
            {
                return Ok(_movieService.Add(movie).ToApiModel());
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Post", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Movie movie)
        {
            try
            {
                return Ok(_movieService.Update(movie).ToApiModel());
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Put", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _movieService.Remove(id);
                return Ok();
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Delete", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
