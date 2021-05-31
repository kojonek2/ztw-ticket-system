using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationAPI.Data;
using ReservationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationAPI.Controllers
{
    [ApiController]
    public class CarController : ControllerBase
    {
        private ReservationsDbContext _context;

        public CarController(ReservationsDbContext context)
        {
            _context = context;
        }

        [HttpPost("car")]
        public IActionResult SaveCar(Car car)
        {
            Car carFromDb = _context.Cars.FirstOrDefault(c => c.Name == car.Name);
            if (carFromDb != null)
                return Conflict();

            _context.Add(car);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet("car/{name}")]
        public IActionResult GetCar(string name)
        {
            Car car = _context.Cars.Include(c => c.Places).Include(c => c.Graphics).FirstOrDefault(c => c.Name == name);
            if (car == null)
                return NotFound();

            return Ok(car);
        }
    }
}
