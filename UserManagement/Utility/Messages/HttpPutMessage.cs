using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace UserManagement.Utility.Messages
{
    public class HttpPutMessage : IHttpMessage
    {
        public string GetResultMessage<T>(string endpoints, string token, T content)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                var api = "http://localhost:8080/admin/realms/master/" + endpoints;

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                response = client.PutAsync(api, null).Result;
            }

            return result;
        }
    }
}
