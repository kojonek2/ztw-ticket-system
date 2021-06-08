using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet("ticketTypes")]
        public IActionResult GetTicketTypes()
        {
            return Ok(_context.TicketTypes.ToList());
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

            var tickets = _context.PlaceReservations.Where(p => p.ReservationId == resId)
                .Include(pr => pr.TrainCars).Include(pr => pr.Place).Include(pr => pr.TicketType);

            foreach (PlaceReservation ticket in tickets)
            {
                array.Add(new TicketResponse()
                {
                    Id = ticket.PlaceReservationId,
                    Place = ticket.Place.Number,
                    Car = ticket.TrainCars.number,
                    Sort = ticket.TicketType.Name,
                    PricePercentage = ticket.TicketType.PricePercentage
                });
            }

            return Ok(array);
        }


    }
}
