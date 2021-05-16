using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationAPI.Models;
using ReservationAPI.Services;
using ReservationAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationAPI.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest request)
        {
            AuthenticateResponse response = _userService.Authenticate(request);

            if (response == null)
                return BadRequest(new { message = "Bad login or password!" });

            return Ok(response);
        }

        [HttpPost("authenticateGoogle")]
        public IActionResult AuthenticateGoogle(AuthenticateRequestGoogle request)
        {
            AuthenticateResponse response = _userService.AuthenticateGoogle(request);

            if (response == null)
                return BadRequest(new { message = "Bad token!" });

            return Ok(response);
        }

        [Authorize]
        [HttpGet("user")]
        public IActionResult GetUser()
        {
            User user = HttpContext.Items[Constants.UserKey] as User;
            if (user == null)
            {
                return Unauthorized(new { Message = "User has to be an admin to use this request!" });
            }

            return Ok(user);
        }
    }
}
