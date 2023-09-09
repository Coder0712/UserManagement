using System.Net.Http.Headers;

namespace UserManagement.Utility.Messages
{
    /// <summary>
    /// Defines a http put message.
    /// </summary>
    public class HttpPutMessage : IHttpMessage
    {
        /// <inheritdoc />
        public string GetResultMessage<T>(string endpoint, string token, T content)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                var api = "http://localhost:8080/admin/realms/master/" + endpoint;

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                response = client.PutAsync(api, null).Result;
            }

            return result;
        }
    }
}
