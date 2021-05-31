using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationAPI.Data;
using ReservationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace ReservationAPI.Controllers
{
    [ApiController]
    public class ConnectionsController : Controller
    {
        private readonly ReservationsDbContext _context;

        public ConnectionsController(ReservationsDbContext context)
        {
            _context = context;
        }

        [HttpGet("connections/{fromId}/{toId}/{time}")]
        public async Task<IActionResult> Index(int fromId, int toId, string time)
        {
            DateTime date = DateTime.ParseExact(time, "yyyy-MM-dd-HH-mm", CultureInfo.InvariantCulture);

            var trains = _context.Trains.Where(t => t.Stops.Any(s => s.StationId == fromId) && t.Stops.Any(s => s.StationId == toId) && t.Stops.First(s => s.StationId == toId).StopDateTime > t.Stops.First(s => s.StationId == fromId).StopDateTime);

            return Ok(_context.Stops.Where(s => trains.Contains(s.Train) && s.StationId == fromId && s.StopDateTime >= date && s.StopDateTime < date.AddDays(1)));
        }

        [HttpPost("stop/")]
        public async Task<IActionResult> AddStop(int StationId, int TrainId, string Time)
        {
            DateTime date = DateTime.ParseExact(Time, "yyyy-MM-dd-HH-mm", CultureInfo.InvariantCulture);
            Stop stop = new Stop()
            {
                StationId = StationId,
                TrainId = TrainId,
                StopDateTime = date
            };

            _context.Stops.Add(stop);
            _context.SaveChanges();
            return Ok();
        }
    }
}
