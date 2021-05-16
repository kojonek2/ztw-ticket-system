using ReservationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationAPI.Services
{
    public interface IUserService
    {
        public AuthenticateResponse Authenticate(AuthenticateRequest request);
        public AuthenticateResponse AuthenticateGoogle(AuthenticateRequestGoogle request);

        public User GetById(int id);
    }
}
