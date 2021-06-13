using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationAPI.Data;
using ReservationAPI.Models;
using ReservationAPI.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
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
                    DateTo = to.StopDateTime.ToString("dd/MM/yyyy HH:mm"),
                    isAbleToResign = from.StopDateTime > DateTime.Now
                });

                var today = DateTime.Now;
                var another = from.StopDateTime;
                var result = from.StopDateTime > DateTime.Now;


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
                DateTo = to.StopDateTime.ToString("dd/MM/yyyy HH:mm"),
                FromId = _context.Stations.First(s => s.StationId == from.StationId).StationId,
                ToId = _context.Stations.First(s => s.StationId == to.StationId).StationId,
                TrainId = from.TrainId,
                isAbleToResign = from.StopDateTime > DateTime.Now
            };

            return Ok(response);
        }

        [Authorize]
        [HttpGet("reservations/resign/{id}")]
        public async Task<IActionResult> Resign(int id)
        {
            User user = HttpContext.Items[Constants.UserKey] as User;
            if (user == null)
            {
                return Unauthorized();
            }

            var userId = user.Id;

            var reservation = _context.Reservations.Include(r => r.From).FirstOrDefault(r => r.UserId == userId && r.ReservationId == id);

            if (reservation == null)
            {
                return Unauthorized();
            }

            if (reservation.From.StopDateTime <= DateTime.Now)
            {
                return BadRequest("This reservation cannot be canceled!");
            }

            var places = _context.PlaceReservations.Where(pr => pr.ReservationId == id).ToList();
            foreach (PlaceReservation place in places)
            {
                _context.PlaceReservations.Remove(place);
                _context.SaveChanges();
            }

            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
            

            return Ok();
        }

        [Authorize]
        [HttpPost("reservations")]
        public async Task<IActionResult> Confirm([FromBody]ReservationRequest request)
        {
            User user = HttpContext.Items[Constants.UserKey] as User;
            if (user == null)
            {
                return Unauthorized();
            }

            Stop from = _context.Stops.FirstOrDefault(s => s.StationId == request.FromId && s.TrainId == request.TrainId);
            Stop to = _context.Stops.FirstOrDefault(s => s.StationId == request.ToId && s.TrainId == request.TrainId);

            if (from == null || to == null)
                return Ok(new { reservationId = -1, message = "Wrong fromId or toId" });

            if (from.StopDateTime >= to.StopDateTime)
                return Ok(new { reservationId = -1, message = "from stop is not earlier than to stop" });

            var occupiedPlaces = _context.PlaceReservations
                .Where(pr => pr.TrainCars.TrainId == request.TrainId)
                .Where(pr => (pr.Reservation.From.StopDateTime < to.StopDateTime && pr.Reservation.To.StopDateTime > from.StopDateTime))
                .ToList()
                .Select(pr => new { placeId = pr.PlaceId, trainCarId = pr.TrainCarsId })
                .ToList();

            foreach (PlaceRequest place in request.Places)
            {
                if (occupiedPlaces.Any(o => o.placeId == place.placeId && o.trainCarId == place.trainCarsId))
                    return Ok(new { reservationId = -1, message = "One of the places is occupied!" });
            }

            Reservation reservation = null;

            try
            {

                reservation = new Reservation()
                {
                    UserId = user.Id,
                    FromId = from.StopId,
                    ToId = to.StopId
                };

                _context.Reservations.Add(reservation);
                _context.SaveChanges();

                foreach (PlaceRequest place in request.Places)
                {
                    PlaceReservation placeRes = new PlaceReservation()
                    {
                        ReservationId = reservation.ReservationId,
                        PlaceId = place.placeId,
                        TicketTypeId = place.ticketTypeId,
                        TrainCarsId = place.trainCarsId
                    };

                    _context.PlaceReservations.Add(placeRes);
                    _context.SaveChanges();
                }
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return Ok(new { reservationId = -1, message = "Unexpected error!" });
            }

            //------------------------

            string fromStationName = _context.Stations.FirstOrDefault(s => s.StationId == request.FromId).Name;
            string toStationName = _context.Stations.FirstOrDefault(s => s.StationId == request.ToId).Name;

            MailSender sender = new MailSender(
                user,
                fromStationName,
                toStationName,
                from,
                to,
                _context.TicketTypes.ToList(),
                reservation.ReservationId,
                request.Places,
                GetReservationPrice(request)
            );

            sender.prepareMessage();
            sender.sendMail();

            return Ok(new { reservationId = reservation.ReservationId, message = "Success!" });
        }


        [Route("reservations")]
        public double GetReservationPrice(ReservationRequest request)
        {
            Stop from = _context.Stops.FirstOrDefault(s => s.StationId == request.FromId && s.TrainId == request.TrainId);
            Stop to = _context.Stops.FirstOrDefault(s => s.StationId == request.ToId && s.TrainId == request.TrainId);

            double price = 0;

            foreach (PlaceRequest place in request.Places)
            {
                TicketType ticket = _context.TicketTypes.First(t => t.TicketTypeId == place.ticketTypeId);

                List<Stop> trainStops = _context.Stops.Where(s => s.TrainId == request.TrainId)
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
                        return -1;

                    distance += connection.Distance;
                }

                price += (distance / 4) * ticket.PricePercentage;
            }

            return Math.Round(price, 2);
        }

    }
}
