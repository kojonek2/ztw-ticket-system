using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ReservationAPI.Models
{
    public class PlaceRequest
    {
        public string trainCartNumber { get; set; }
        public int placeNumber { get; set; }
        public int placeId { get; set; }
        public int trainCarsId { get; set; }
        public int ticketTypeId { get; set; }
    }
}
