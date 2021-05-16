using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ReservationAPI.Models
{
    public class PlaceReservation
    {
        public int PlaceReservationId { get; set; }
        [Required]
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        [Required]
        public int PlaceId { get; set; }
        public Place Place { get; set; }
        [Required]
        public int TicketTypeId { get; set; }
        public TicketType TicketType { get; set; }

    }
}
