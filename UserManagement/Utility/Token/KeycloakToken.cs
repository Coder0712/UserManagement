using Newtonsoft.Json;
using UserManagement.Serialization.Model;
using UserManagement.Utility.KeycloakCredentials;

namespace UserManagement.Utility.Token
{
    internal class KeycloakToken
    {
        public static string Token
        {
            get
            {
                TokenDeserialization response = CreateToken();

                return response.access_token;
            }
        }

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
