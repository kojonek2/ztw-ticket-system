﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationAPI.Models
{
    public class ReservationsResponse
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
        public int TrainId { get; set; }
        public bool isAbleToResign { get; set; }


    }
}
