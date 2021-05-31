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
    public class TicketsController : Controller
    {
        private readonly ReservationsDbContext _context;

        public TicketsController(ReservationsDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("tickets/{resId}")]
        public async Task<IActionResult> Index(int resId)
        {
            User user = HttpContext.Items[Constants.UserKey] as User;
            if (user == null)
            {
                return Unauthorized();
            }

            var userId = user.Id;

            var reservation = _context.Reservations.First(r => r.UserId == userId && r.ReservationId == resId);

            if(reservation == null)
            {
                return Unauthorized();
            }

            List<TicketResponse> array = new List<TicketResponse>();

            var tickets = _context.PlaceReservations.Where(p => p.ReservationId == resId);

            foreach (PlaceReservation ticket in tickets)
            {
                var place = _context.Places.First(p => p.PlaceId == ticket.PlaceId);
                array.Add(new TicketResponse()
                {
                    Id = ticket.PlaceReservationId,
                    Place = place.Number,
                    Car = _context.Cars.First(c => c.CarId == place.CarId).Name,
                    Sort = _context.TicketTypes.First(t => t.TicketTypeId == ticket.TicketTypeId).Name,
                    PricePercentage = _context.TicketTypes.First(t => t.TicketTypeId == ticket.TicketTypeId).PricePercentage
                });
            }

            return Ok(array);
        }


    }
}
