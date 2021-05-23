using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationAPI.Models
{
    public class Car
    {
        public int CarId { get; set; }
        [Required]
        public String Name { get; set; }
        public int TrainCarId { get; set; }
        public TrainCars TrainCar { get; set; }
        public ICollection<Graphic> Graphics { get; set; }
        public ICollection<Place> Places { get; set; }
    }
}
