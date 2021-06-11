using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.Models.Response;
using ApplicationCore.Models.Request;
using ApplicationCore.Entities;

namespace MovieShop.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserService _userService;
        private readonly IMovieService _movieService;

        public UserController(ICurrentUserService currentUserService, IUserService userService, IMovieService movieService)
        {
            _currentUserService = currentUserService;
            _userService = userService;
            _movieService = movieService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUserPurchasedMovies()
        {

            var userId = _currentUserService.UserId;
            // get the user id
            //
            // make a request to the database and get info from Purchase Table 
            // select * from Purchase where userid = @getfromcookie
            var purchasedMovies = await _userService.GetAllPurchasedMovies(userId);
            return View(purchasedMovies);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> PurchaseMovie(int id)
        {
            var purchasedMovieDetail = await _movieService.GetMovieDetailsById(id);
            return View(purchasedMovieDetail);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PurchaseMovie(int id, UserPurchaseMovieRequestModel model)
        {
            model.MovieId = id;
            // get userid from CurrentUser and create a row in Purchase Table
            await _userService.AddPurchasedMovie(model);
            return LocalRedirect("~/User/GetUserPurchasedMovies");
        }
    }
}
