using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationAPI.Models
{
    public class TicketResponse
    {
        public int Id { get; set; }
        public int Place { get; set; }
        public string Car { get; set; }
        public string Sort { get; set; }
        public double PricePercentage { get; set; }
    }
}
