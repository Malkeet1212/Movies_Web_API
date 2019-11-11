using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies_Web_API.BusinessLayer;
using Movies_Web_API.Models;

namespace Movies_Web_API.Controllers
{

    //Movies ApiPI controller
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly Movies_Web_APIDatabaseContext _context;

        public MoviesController(Movies_Web_APIDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Movies
        //Gets all movies using a linq query.
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetMovie()
        {
            return (from movies in _context.Movie select movies).ToList();
        }

        // GET: api/Movies/5
        //Get movie details using a linq query.
        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovie(int id)
        {
            var movie = (from movies in _context.Movie
                         where movies.Id == id
                         select movies).FirstOrDefault();

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Updates the movie.
        [HttpPut("{id}")]
        public IActionResult PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Movies
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Adds a movie to the database.
        [HttpPost]
        public ActionResult<Movie> PostMovie(Movie movie)
        {
            _context.Movie.Add(movie);
             _context.SaveChanges();

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        // DELETE: api/Movies/5
        //Deletes a movie from database. uses a linq query to select the movie.
        [HttpDelete("{id}")]
        public ActionResult<Movie> DeleteMovie(int id)
        {
            var movie = (from movies in _context.Movie
                         where movies.Id == id
                         select movies).FirstOrDefault();
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movie.Remove(movie);
             _context.SaveChanges();

            return movie;
        }

        //Checks the movie for existance using a lamda query.
        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
