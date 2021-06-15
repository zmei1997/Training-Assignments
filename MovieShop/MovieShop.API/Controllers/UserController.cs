using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("{id:int}/purchases")]
        public async Task<IActionResult> GetUserPurchaseByUserId(int id)
        {
            var purchases = await _userService.GetAllPurchasedMovies(id);
            if (purchases.Any())
            {
                return Ok(purchases);
            }
            return NotFound("no purchase found");
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
    }
}
