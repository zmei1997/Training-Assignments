using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using ApplicationCore.Models.Request;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;

        public UserController(IUserService userService, ICurrentUserService currentUserService)
        {
            _userService = userService;
            _currentUserService = currentUserService;
        }

        [Authorize]
        [HttpGet]
        [Route("{id:int}/purchases")]
        public async Task<IActionResult> GetUserPurchaseByUserId(int id)
        {
            if (_currentUserService.UserId != id)
            {
                return Unauthorized("please send correct id");
            }

            // we need to check if the client who is calling this method is sending a valid token
            var purchases = await _userService.GetAllPurchasedMovies(id);
            return Ok(purchases);
        }

        [Authorize]
        [HttpPost]
        [Route("purchase")]
        public async Task<IActionResult> AddUserPurchase([FromBody] UserPurchaseMovieRequestModel model)
        {
            if (_currentUserService.UserId != model.UserId)
            {
                return Unauthorized("please send correct id");
            }
            await _userService.AddPurchasedMovie(model);
            return Ok();
        }

        [Authorize]
        [HttpGet]
        [Route("{id:int}/reviews")]
        public async Task<IActionResult> GetUserReviewsByUserId(int id)
        {
            if (_currentUserService.UserId != id)
            {
                return Unauthorized("please send correct id");
            }
            var reviews = await _userService.GetReviewsByUserId(id);
            if (reviews.Any())
            {
                return Ok(reviews);
            }
            return NotFound("no review found");
        }

        [Authorize]
        [HttpPost]
        [Route("review")]
        public async Task<IActionResult> AddUserReview([FromBody] UserReviewRequestModel model)
        {
            if (_currentUserService.UserId != model.UserId)
            {
                return Unauthorized("please send correct id");
            }
            await _userService.AddReview(model);
            return Ok();
        }

        [Authorize]
        [HttpPut]
        [Route("review")]
        public async Task<IActionResult> UpdateUserReview([FromBody] UserReviewRequestModel model)
        {
            if (_currentUserService.UserId != model.UserId)
            {
                return Unauthorized("please send correct id");
            }
            await _userService.UpdateReview(model);
            return Ok();
        }

        [Authorize]
        [HttpDelete("{userId:int}/movie/{movieId:int}")]
        public async Task<ActionResult> DeleteReview(int userId, int movieId)
        {
            if (_currentUserService.UserId != userId)
            {
                return Unauthorized("please send correct id");
            }
            await _userService.DeleteReview(userId, movieId);
            return NoContent();
        }

        [Authorize]
        [HttpGet]
        [Route("{id:int}/favorites")]
        public async Task<IActionResult> GetUserFavoritesByUserId(int id)
        {
            if (_currentUserService.UserId != id)
            {
                return Unauthorized("please send correct id");
            }
            var favorites = await _userService.GetFavoritesByUserId(id);
            if (favorites.Any())
            {
                return Ok(favorites);
            }
            return NotFound("no favorite movie found");
        }

        [Authorize]
        [HttpPost]
        [Route("favorite")]
        public async Task<IActionResult> AddUserFavorite([FromBody] UserFavoriteRequestModel model)
        {
            if (_currentUserService.UserId != model.UserId)
            {
                return Unauthorized("please send correct id");
            }
            await _userService.AddFavorite(model);
            return Ok();
        }

        [Authorize]
        [HttpPost]
        [Route("unfavorite")]
        public async Task<IActionResult> UnFavorite([FromBody] UserFavoriteRequestModel model)
        {
            if (_currentUserService.UserId != model.UserId)
            {
                return Unauthorized("please send correct id");
            }
            await _userService.RemoveFavorite(model);
            return Ok();
        }

        [Authorize]
        [HttpGet]
        [Route("{id:int}/movie/{movieId}/favorite")]
        public async Task<ActionResult> IsFavoriteExists(int id, int movieId)
        {
            if (_currentUserService.UserId != id)
            {
                return Unauthorized("please send correct id");
            }
            var favoriteExists = await _userService.FavoriteExists(id, movieId);
            return Ok(new { isFavorited = favoriteExists });
        }
    }
}
