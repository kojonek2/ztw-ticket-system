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
    public class StopsController : ControllerBase
    {
        private readonly ReservationsDbContext _context;

        public StopsController(ReservationsDbContext context)
        {
            _context = context;
        }

        [HttpGet("stops/train/{trainId}/station/{stationId}")]
        public IActionResult GetStopFromStataionAndTrain(int trainId, int stationId)
        {
            Stop stop = _context.Stops.Where(s => s.TrainId == trainId && s.StationId == stationId)
                .Include(s => s.Station)
                .FirstOrDefault();

            if (stop == null)
                return NotFound();

            return Ok(stop);
        }
    }
}
