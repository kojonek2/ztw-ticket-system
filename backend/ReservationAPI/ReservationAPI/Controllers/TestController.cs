using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationAPI.Models;
using ReservationAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationAPI.Controllers
{
    [ApiController]
    public class TestController : ControllerBase
    {
        [Authorize]
        [Route("test")]
        public IActionResult Test()
        {
            User user = HttpContext.Items[Constants.UserKey] as User;
            return Ok($"Testowy tajny ciąg. User: {user.Login}");
        }

        [Route("password/{password}")]
        public IActionResult Test(string password)
        {
            return Ok(PasswordValidator.createHash(password));
        }
    }
}
