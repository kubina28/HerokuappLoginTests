using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuappLoginTests.scr.Constants
{
    public static class Constants
    {// URLs
        public const string LoginUrl = "https://the-internet.herokuapp.com/login";
        public const string SecureAreaUrl = "https://the-internet.herokuapp.com/secure";

        // Credentials
        public static class ValidCredentials
        {
            public const string Username = "tomsmith";
            public const string Password = "SuperSecretPassword!";
        }

        public static class InvalidCredentials
        {
            public const string Username = "zlyuzivatel";
            public const string Password = "zleheslo";
        }
        public static class CaseSensitiveInvalidCredentials
        {
            public const string Username = "TomSmith";
            public const string Password = "supersecretpassword!";
        }

        // Messages
        public const string SuccessfulLoginMessage = "You logged into a secure area!";
        public const string InvalidUsernameMessage = "Your username is invalid!";
        public const string InvalidPasswordMessage = "Your password is invalid!";
        public const string SuccessfulLogoutMessage = "You logged out of the secure area!";
        public const string InvalidSecureAreaMessage = "You must login to view the secure area!";

    }
}
