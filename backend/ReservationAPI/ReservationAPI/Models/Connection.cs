using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationAPI.Models
{
    public class Connection
    {
        public int ConnectionId { get; set; }
        [Required]
        public int? FirstStationId { get; set; }
        public Station FirstStation { get; set; }
        [Required]
        public int? SecondStationId { get; set; }
        public Station SecondStation { get; set; }
        [Required]
        public double Distance { get; set; }
    }
}
