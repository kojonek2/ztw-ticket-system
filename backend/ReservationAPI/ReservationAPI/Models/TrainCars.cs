using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationAPI.Models
{
    public class TrainCars
    {
        public int TrainCarsId { get; set; }
        [Required]
        public int Order { get; set; }
        [Required]
        public String number { get; set; }
        [Required]
        [ForeignKey("Train")]
        public int TrainId { get; set; }
        public Train Train { get; set; }
        [Required]
        [ForeignKey("Car")]
        public int CarId { get; set; }
        public Car Car { get; set; }

    }
}
