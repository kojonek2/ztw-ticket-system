using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ReservationAPI.Models
{
    public class Graphic
    {
        public int GraphicId { get; set; }
        [Required]
        public double X { get; set; }
        [Required]
        public double Y { get; set; }
        [Required]
        public String Type { get; set; }
        [Required]
        public double Width { get; set; }
        [Required]
        public double Height { get; set; }
        public int CarId { get; set; }

        [JsonIgnore]
        public Car Car { get; set; }
    }
}
