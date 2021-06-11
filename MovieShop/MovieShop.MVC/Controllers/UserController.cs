using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using ApplicationCore.RepositoryInterfaces;

namespace MovieShop.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IPurchaseRepository _purchaseRepository;

        public UserController(ICurrentUserService currentUserService, IPurchaseRepository purchaseRepository)
        {
            _currentUserService = currentUserService;
            _purchaseRepository = purchaseRepository;
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
            var purchases = _purchaseRepository.GetPurchasesByUserId(userId);

            return View();
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PurchaseMovie()
        {
            // get userid from CurrentUser and create a row in Purchase Table
            return View();
        }
    }
}
