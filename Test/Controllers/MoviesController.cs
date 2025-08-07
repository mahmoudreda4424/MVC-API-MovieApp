using Microsoft.AspNetCore.Mvc;
using Test.Data;
using Test.Model;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IRepository<Movie> _repository;
        public MoviesController(IRepository<Movie> repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetAll()
        {
            var movies = _repository.GetAll();
            return Ok(movies);
        }


        [HttpGet("{id}")]
        public ActionResult<Movie> GetById(int id)
        {
            var movies = _repository.GetById(id);
            if (movies == null)
            {
                return NotFound();
            }
            return Ok(movies);
        }

        [HttpPost]
        public ActionResult<Movie> Create(Movie movies)
        {
            if (movies == null)
            {
                return BadRequest("Product Can't be Null");
            }
            _repository.Add(movies);
            return CreatedAtAction(nameof(GetById), new { id = movies.Id }, movies);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest("Product Id MisMatch");
            }
            var existingMovie = _repository.GetById(id);
            if (existingMovie == null)
            {
                return NotFound();
            }
            _repository.Update(movie);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var movies = _repository.GetById(id);
            if (movies == null)
            {
                return NotFound();
            }
            _repository.Delete(id);
            return NoContent();
        }


    }
}
