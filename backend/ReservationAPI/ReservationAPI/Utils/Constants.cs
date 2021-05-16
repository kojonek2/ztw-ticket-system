using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationAPI.Utils
{
    public static class Constants
    {
        public const string AppSettingsSection = "AppSettings";
        public const string SecretValueName = "Secret";

        public const string Authorization = "Authorization";

        public const string ClaimTypeId = "id";
        public const string UserKey = "User";

        public const string GoogleApiTokenInfoUrl = "https://oauth2.googleapis.com/tokeninfo?id_token={0}";
        public const string GoogleClientId = "512875819210-kj997qkdnvsn3reuf6a1ee4egfu97ns3.apps.googleusercontent.com";
    }
}
