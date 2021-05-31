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
    public class TrainController : ControllerBase
    {
        private ReservationsDbContext _context;

        public TrainController(ReservationsDbContext context)
        {
            _context = context;
        }

        [HttpGet("train/{name}")]
        public IActionResult GetCar(string name)
        {
            Train train = _context.Trains.Include(t => t.TrainCars).ThenInclude(tc => tc.Car.Places)
                .Include(t => t.TrainCars).ThenInclude(tc => tc.Car.Graphics)
                .FirstOrDefault(t => t.name == name);
            if (train == null)
                return NotFound();

            return Ok(train);
        }
    }
}
