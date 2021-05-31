using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationAPI.Data;
using ReservationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ReservationAPI.Controllers
{
    [ApiController]
    public class StationsController : Controller
    {
        private readonly ReservationsDbContext _context;

        public StationsController(ReservationsDbContext context)
        {
            _context = context;
        }

        // GET: StationsController
        [HttpGet("stations")]
        public async Task<IActionResult> Index()
        {
            return Ok(_context.Stations);
        }

        // GET: StationsController/Details/5
        [HttpGet("stations/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Station station = await _context.Stations
                .FirstOrDefaultAsync(s => s.StationId == id);
            if (station == null)
            {
                return NotFound();
            }

            return Ok(station);
        }
    }
}
