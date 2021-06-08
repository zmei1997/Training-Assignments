using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Services;

namespace MovieShop.MVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var movieDetailsModel = await _movieService.GetMovieDetailsById(id);
            return View(movieDetailsModel);
        }

        [HttpGet]
        public async Task<IActionResult> TopRated()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> TopRevenue()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Genre()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Reviews()
        {
            return View();
        }
    }
}
