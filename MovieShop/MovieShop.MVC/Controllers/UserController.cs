using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Purchase()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Favorite()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Unfavorite()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Review()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Movie()
        {
            return View();
        }
    }
}
