using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ReservationAPI.Models
{
    public class ReservationRequest
    {

        public int FromId { get; set; }

        public int ToId { get; set; }
        public List<PlaceRequest> Places { get; set; }
        public int TrainId { get; set; }
    }
}
