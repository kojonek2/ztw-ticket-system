using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ReservationAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }

        public UserType UserType { get; set; } = UserType.Normal;

        [JsonIgnore]
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }

    }

    public enum UserType
    {
        Normal = 1,
        Google = 2
    }
}
