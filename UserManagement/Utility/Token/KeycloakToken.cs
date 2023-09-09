using Newtonsoft.Json;
using UserManagement.Serialization.Model;
using UserManagement.Utility.KeycloakCredentials;

namespace UserManagement.Utility.Token
{
    /// <summary>
    /// Defines a message to create a bearer token.
    /// </summary>
    internal class KeycloakToken
    {
        /// <summary>
        /// Gets a token.
        /// </summary>
        public static string Token
        {
            get
            {
                TokenDeserialization response = CreateToken();

                return response.access_token;
            }
        }

        /// <summary>
        /// Creates a bearer token.
        /// </summary>
        /// <returns>A message with the token.</returns>
        /// <exception cref="Exception">Cant create a token.</exception>
        private static TokenDeserialization CreateToken()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            var deserializeToken = new TokenDeserialization();
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                var api = "http://localhost:8080/realms/master/protocol/openid-connect/token";

                var data = new[]
                {
                    new KeyValuePair<string, string>("username", Credentials.Instance.Username),
                    new KeyValuePair<string, string>("password", Credentials.Instance.Password),
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("client_id", "admin-cli"),
                };

                response = client.PostAsync(api, new FormUrlEncodedContent(data)).GetAwaiter().GetResult();
            }

            if (response != null)
            {
                result = response.Content.ReadAsStringAsync().Result;
            }

            if (result != null)
            {
                deserializeToken = JsonConvert.DeserializeObject<TokenDeserialization>(result);
            }

            if (deserializeToken != null)
            {
                return deserializeToken;
            }

            throw new Exception("Cant create a token.");
        }
    }
}
