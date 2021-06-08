using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;

namespace MovieShop.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Purchase()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Favorite()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Unfavorite()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Review()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Movie()
        {
            return View();
        }
    }
}
