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

        [HttpPost]
        [Route("purchase")]
        public async Task<IActionResult> AddUserPurchase([FromBody] UserPurchaseMovieRequestModel model)
        {
            await _userService.AddPurchasedMovie(model);
            return Ok();
        }

        [HttpGet]
        [Route("{id:int}/reviews")]
        public async Task<IActionResult> GetUserReviewsByUserId(int id)
        {
            var reviews = await _userService.GetReviewsByUserId(id);
            if (reviews.Any())
            {
                return Ok(reviews);
            }
            return NotFound("no review found");
        }

        [HttpPost]
        [Route("review")]
        public async Task<IActionResult> AddUserReview([FromBody] UserReviewRequestModel model)
        {
            await _userService.AddReview(model);
            return Ok();
        }

        [HttpPut]
        [Route("review")]
        public async Task<IActionResult> UpdateUserReview([FromBody] UserReviewRequestModel model)
        {
            await _userService.UpdateReview(model);
            return Ok();
        }

        [HttpDelete("{userId:int}/movie/{movieId:int}")]
        public async Task<ActionResult> DeleteReview(int userId, int movieId)
        {
            await _userService.DeleteReview(userId, movieId);
            return NoContent();
        }

        [HttpGet]
        [Route("{id:int}/favorites")]
        public async Task<IActionResult> GetUserFavoritesByUserId(int id)
        {
            var favorites = await _userService.GetFavoritesByUserId(id);
            if (favorites.Any())
            {
                return Ok(favorites);
            }
            return NotFound("no favorite movie found");
        }

        [HttpPost]
        [Route("favorite")]
        public async Task<IActionResult> AddUserFavorite([FromBody] UserFavoriteRequestModel model)
        {
            await _userService.AddFavorite(model);
            return Ok();
        }

        [HttpPost]
        [Route("unfavorite")]
        public async Task<IActionResult> UnFavorite([FromBody] UserFavoriteRequestModel model)
        {
            await _userService.RemoveFavorite(model);
            return Ok();
        }

        [HttpGet]
        [Route("{id:int}/movie/{movieId}/favorite")]
        public async Task<ActionResult> IsFavoriteExists(int id, int movieId)
        {
            var favoriteExists = await _userService.FavoriteExists(id, movieId);
            return Ok(new { isFavorited = favoriteExists });
        }
    }
}
