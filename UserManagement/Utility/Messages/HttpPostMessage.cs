using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace UserManagement.Utility.Messages
{
    /// <summary>
    /// Defines a http post message.
    /// </summary>
    public class HttpPostMessage : IHttpMessage
    {
        /// <inheritdoc />
        public string GetResultMessage<T>(string endpoints, string? token, T content)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            using (var client = new HttpClient())
            {
                var api = "http://localhost:8080/admin/realms/master/" + endpoints;

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var json = JsonConvert.SerializeObject(content);

                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                response = client.PostAsync(api, stringContent).Result;
            }

            if (response.Content.ReadAsStringAsync().Result == null)
            {
                throw new Exception("Result is null.");
            }
            else
            {
                return response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
