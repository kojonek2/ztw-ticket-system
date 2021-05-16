using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ReservationAPI.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        [Required]
        public int UserId { get; set; }
        // public User User { get; set }
        [Required]
        public int FromId { get; set; }
        public Stop From { get; set; }
        [Required]
        public int ToId { get; set; }
        public Stop To { get; set; }
        public ICollection<PlaceReservation> PlaceReservations { get; set; }
    }
}
