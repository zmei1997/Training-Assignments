using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Movie()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Purchases()
        {
            return View();
        }
    }
}
