using System.Net;

namespace UserManagement.Utility.KeycloakCredentials
{
    /// <summary>
    /// Provides login
    /// </summary>
    public class Credentials
    {
        internal static Credentials Instance { get; private set; }

        private Credentials()
        {
        }

        public static Credentials Login(string username, string password)
        {
            if (Instance== null)
            {
                Instance = new Credentials();
                Instance.Username = username;
                Instance.Password = password;
                return Instance;
            }

            return Instance;
        }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string Username { get; private set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; private set; }
    }
}
