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
    public class PriceController : ControllerBase
    {
        private readonly ReservationsDbContext _context;

        public PriceController(ReservationsDbContext context)
        {
            _context = context;
        }

        [HttpGet("price/{trainId}/{fromId}/{toId}")]
        public IActionResult GetNormalPrice(int trainId, int fromId, int toId)
        {
            Stop from = _context.Stops.FirstOrDefault(s => s.StationId == fromId && s.TrainId == trainId);
            Stop to = _context.Stops.FirstOrDefault(s => s.StationId == toId && s.TrainId == trainId);

            List<Stop> trainStops = _context.Stops.Where(s => s.TrainId == trainId)
                .Where(s => s.StopDateTime >= from.StopDateTime && s.StopDateTime <= to.StopDateTime)
                .OrderBy(s => s.StopDateTime)
                .ToList();

            List<int> stationIds = trainStops.Select(ts => ts.StationId).ToList();
            List<Connection> connections = _context.Connections.Where(s => stationIds.Contains(s.FirstStationId ?? -1) && stationIds.Contains(s.SecondStationId ?? -1)).ToList();

            double distance = 0;
            for (int i = 1; i < trainStops.Count; i++)
            {
                Stop first = trainStops[i - 1];
                Stop second = trainStops[i];

                Connection connection = connections
                    .FirstOrDefault(c => (c.FirstStationId == first.StationId && c.SecondStationId == second.StationId)
                    || (c.FirstStationId == second.StationId && c.SecondStationId == first.StationId));

                if (connection == null)
                    return StatusCode(StatusCodes.Status500InternalServerError);

                distance += connection.Distance;
            }

            return Ok(new { price = Math.Round(distance / 4, 2) });
        }
    }
}
