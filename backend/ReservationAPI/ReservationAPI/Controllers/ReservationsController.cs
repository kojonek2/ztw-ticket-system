using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationAPI.Data;
using ReservationAPI.Models;
using ReservationAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationAPI.Controllers
{
    [ApiController]
    public class ReservationsController : Controller
    {
        private readonly ReservationsDbContext _context;

        public ReservationsController(ReservationsDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("reservations")]
        public async Task<IActionResult> Index()
        {
            User user = HttpContext.Items[Constants.UserKey] as User;
            if (user == null)
            {
                return Unauthorized();
            }

            var userId = user.Id;

            var reservations = _context.Reservations.Where(r => r.UserId == userId);

            List<ReservationsResponse> array = new List<ReservationsResponse>();

            foreach (Reservation item in reservations)
            {

                var from = _context.Stops.First(x => Convert.ToInt32(x.StopId) == Convert.ToInt32(item.FromId));
                var to = _context.Stops.FirstOrDefault(s => s.StopId == item.ToId);
                array.Add(new ReservationsResponse()
                {
                    Id = item.ReservationId,
                    From = _context.Stations.First(s => s.StationId == from.StationId).Name,
                    To = _context.Stations.First(s => s.StationId == to.StationId).Name,
                    DateFrom = from.StopDateTime.ToString("dd/MM/yyyy HH:mm"),
                    DateTo = to.StopDateTime.ToString("dd/MM/yyyy HH:mm")
                });
                
            }

            return Ok(array);
        }

        [Authorize]
        [HttpGet("reservations/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            User user = HttpContext.Items[Constants.UserKey] as User;
            if (user == null)
            {
                return Unauthorized();
            }

            var userId = user.Id;

            var reservation = _context.Reservations.First(r => r.UserId == userId && r.ReservationId == id);

            if(reservation == null)
            {
                return Unauthorized();
            }

            var from = _context.Stops.First(x => Convert.ToInt32(x.StopId) == Convert.ToInt32(reservation.FromId));
            var to = _context.Stops.FirstOrDefault(s => s.StopId == reservation.ToId);

            ReservationsResponse response = new ReservationsResponse()
            {
                Id = reservation.ReservationId,
                From = _context.Stations.First(s => s.StationId == from.StationId).Name,
                To = _context.Stations.First(s => s.StationId == to.StationId).Name,
                DateFrom = from.StopDateTime.ToString("dd/MM/yyyy HH:mm"),
                DateTo = to.StopDateTime.ToString("dd/MM/yyyy HH:mm")
            };

            return Ok(response);
        }


    }
}
