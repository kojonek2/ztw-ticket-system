using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ReservationAPI.Models
{
    public class TicketType
    {
        public int TicketTypeId { get; set; }
        [Required]
        public double PricePercentage { get; set; }
        [Required]
        public String Name { get; set; }
    }
}
