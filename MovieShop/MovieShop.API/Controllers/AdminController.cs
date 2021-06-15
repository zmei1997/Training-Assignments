using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models.Request;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMovieService _movieService;

        public AdminController(IUserService userService, IMovieService movieService)
        {
            _userService = userService;
            _movieService = movieService;
        }

        [HttpPost]
        [Route("movie")]
        public async Task<IActionResult> CreateMovie([FromBody] CreateMovieRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var movie = await _movieService.CreatMovie(model);
                return Ok(movie);
            }
            return BadRequest("Please check the data you entered");
        }

        [HttpPut]
        [Route("movie")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] CreateMovieRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var movie = await _movieService.UpdateMovie(id, model);
                return Ok(movie);
            }
            return BadRequest("Please check the data you entered");
        }

        [HttpGet]
        [Route("purchases")]
        public async Task<IActionResult> GetPurchase(int id)
        {
            var purchase = await _userService.GetAllPurchasedMovies(id);
            return Ok(purchase);
        }
    }
}
