using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ReservationAPI.Models
{
    public class Stop
    {
        public int StopId { get; set; }
        [Required]
        public int StationId { get; set; }
        public Station Station { get; set; }
        [Required]
        public int TrainId { get; set; }   
        public Train Train { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:HH.mm dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StopDateTime { get; set; }
    }
}
