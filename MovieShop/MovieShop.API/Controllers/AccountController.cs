using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.Models.Request;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequestModel model)
        {
            if (ModelState.IsValid)
            {
                // save to db, register user
                var createdUser = await _userService.RegisterUser(model);
                // 201 Created
                return Ok(createdUser);
            }
            // 400
            return BadRequest("Please check the data you entered");
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserDetails(id);
            return Ok(user);
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult> EmailExists([FromQuery] string email)
        {
            var user = await _userService.GetUser(email);
            return Ok(user == null ? new { emailExists = false } : new { emailExists = true });
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> LoginAsync([FromBody] UserLoginRequestModel loginRequest)
        {
            var user = await _userService.Login(loginRequest.Email, loginRequest.Password);
            if (user == null) 
                return Unauthorized();

            return Ok(user);
        }
    }
}
