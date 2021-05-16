using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ReservationAPI.Models
{
    public class Train
    {
        public int TrainId { get; set; }
        public String name { get; set; }
        [Required]
        public int number { get; set; }
        public ICollection<Stop> Stops { get; set; }
        public ICollection<TrainCars> TrainCars { get; set; }
    }
}
