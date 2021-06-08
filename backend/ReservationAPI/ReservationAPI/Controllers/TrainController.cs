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

        [HttpGet("train/{id}")]
        public IActionResult GetTrain(int id)
        {
            Train train = _context.Trains.Include(t => t.TrainCars).ThenInclude(tc => tc.Car.Places)
                .Include(t => t.TrainCars).ThenInclude(tc => tc.Car.Graphics)
                .FirstOrDefault(t => t.TrainId == id);
            if (train == null)
                return NotFound();

            return Ok(train);
        }

        [HttpGet("train/{trainId}/occupiedPlaces/{fromId}/{toId}")]
        public IActionResult GetOccupiedPlaces(int trainId, int fromId, int toId)
        {
            Stop from = _context.Stops.FirstOrDefault(s => s.StationId == fromId && s.TrainId == trainId);
            Stop to = _context.Stops.FirstOrDefault(s => s.StationId == toId && s.TrainId == trainId);

            if (from == null || to == null)
                return BadRequest("Wrong fromId or toId");

            if (from.StopDateTime >= to.StopDateTime)
                return BadRequest("from stop is not earlier than to stop");

            var occupiedPlaces = _context.PlaceReservations
                .Where(pr => pr.TrainCars.TrainId == trainId)
                .Where(pr => (pr.Reservation.From.StopDateTime < to.StopDateTime && pr.Reservation.To.StopDateTime > from.StopDateTime))
                .ToList()
                .Select(pr => new { placeId = pr.PlaceId, trainCarId = pr.TrainCarsId})
                .ToList();

            return Ok(occupiedPlaces);
        }
    }
}
