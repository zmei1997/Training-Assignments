using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _movieService.GetAllMovies();

            if (movies.Any())
            {
                return Ok(movies);
            }
            return NotFound("no movies found");
        }

        [HttpGet]
        [Route("toprevenue")]
        public async Task<IActionResult> GetHighestGrossingMovies()
        {
            var movies = await _movieService.GetTopRevenueMovies();

            if (movies.Any())
            {
                return Ok(movies);
            }
            return NotFound("no movies found");
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetMovieDetailsById(int id)
        {
            var movie = await _movieService.GetMovieDetailsById(id);
            return Ok(movie);
        }

        [HttpGet]
        [Route("toprated")]
        public async Task<IActionResult> GetTopRatedMovies()
        {
            var movies = await _movieService.GetTopRatedMovies();

            if (movies.Any())
            {
                return Ok(movies);
            }
            return NotFound("no movies found");
        }

        [HttpGet]
        [Route("{id:int}/reviews")]
        public async Task<IActionResult> GetMovieReviews(int id)
        {
            var reviews = await _movieService.GetMovieReviewsByMovieId(id);

            if (reviews.Any())
            {
                return Ok(reviews);
            }
            return NotFound("no movie review found");
        }

        [HttpGet]
        [Route("genre/{genreId:int}")]
        public async Task<IActionResult> GetMoviesByGenreId(int genreId)
        {
            var movies = await _movieService.GetMoviesByGenreId(genreId);

            if (movies.Any())
            {
                return Ok(movies);
            }
            return NotFound("no movie found");
        }
    }
}
