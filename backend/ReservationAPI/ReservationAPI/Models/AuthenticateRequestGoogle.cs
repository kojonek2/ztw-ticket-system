using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationAPI.Models
{
    public class AuthenticateRequestGoogle
    {
        public string Token { get; set; }
    }
}
