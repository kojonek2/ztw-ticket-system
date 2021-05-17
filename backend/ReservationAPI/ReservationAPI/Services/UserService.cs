using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ReservationAPI.Data;
using ReservationAPI.Models;
using ReservationAPI.Utils;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ReservationAPI.Services
{
    public class UserService : IUserService
    {
        private readonly ReservationsDbContext _context;
        private readonly IConfiguration _configuration;

        public UserService(ReservationsDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest request)
        {
            if (request == null)
                return null;

            if (request.Login == null || request.Password == null)
                return null;

            User user = _context.Users.FirstOrDefault(u => u.Login == request.Login && u.UserType == UserType.Normal);
            if (user == null) //login not found!
                return null;

            
            if (!PasswordValidator.isValid(request.Password, user.Password))
                return null;

            string token = generateJwtToken(user);

            return new AuthenticateResponse() { Token = token };
        }

        public AuthenticateResponse AuthenticateGoogle(AuthenticateRequestGoogle request)
        {
            if (request == null)
                return null;

            if (request.Token == null)
                return null;

            var httpClient = new HttpClient();
            var requestUri = new Uri(string.Format(Constants.GoogleApiTokenInfoUrl, request.Token));

            GoogleTokenInfo tokenInfo;
            try
            {
                HttpResponseMessage httpResponseMessage = httpClient.GetAsync(requestUri).Result;
                if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
                {
                    return null;
                }

                tokenInfo = JsonConvert.DeserializeObject<GoogleTokenInfo>(httpResponseMessage.Content.ReadAsStringAsync().Result);
            }
            catch (Exception ex)
            {
                return null;
            }

            if (tokenInfo.aud != Constants.GoogleClientId)
                return null;

            User user = _context.Users.FirstOrDefault(u => u.Login == tokenInfo.email && u.UserType == UserType.Google);
            if (user == null) //login not found! Create user
            {
                user = new User() { Login = tokenInfo.email, UserType = UserType.Google, Email = tokenInfo.email};
                _context.Users.Add(user);
                _context.SaveChanges();
            }

            string token = generateJwtToken(user);

            return new AuthenticateResponse() { Token = token };
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        private string generateJwtToken(User user)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            string secret = _configuration.GetSection(Constants.AppSettingsSection)[Constants.SecretValueName];
            byte[] key = Encoding.ASCII.GetBytes(secret);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(Constants.ClaimTypeId, user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
