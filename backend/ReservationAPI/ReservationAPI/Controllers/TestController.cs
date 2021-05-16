using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return Ok("Testowy tajny ciąg");
        }

        [Route("password/{password}")]
        public IActionResult Test(string password)
        {
            return Ok(PasswordValidator.createHash(password));
        }
    }
}
