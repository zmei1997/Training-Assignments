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
        [HttpGet]
        public IActionResult GetMovies()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult GetMoviesById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult GetMoviesTopRated()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult GetMoviesTopRevenue()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult GetMoviesGenre(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult GetMoviesReviews(int id)
        {
            throw new NotImplementedException();
        }
    }
}
