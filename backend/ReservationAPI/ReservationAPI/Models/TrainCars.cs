using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public Train Train { get; set; }
        [Required]
        [ForeignKey("Car")]
        public int CarId { get; set; }
        public Car Car { get; set; }

    }
}
