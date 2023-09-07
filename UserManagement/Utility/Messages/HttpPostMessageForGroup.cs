using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace UserManagement.Utility.Messages
{
    public class HttpPostMessageForGroup
    {
        /// <inheritdoc />
        public string GetResultMessage<T>(string? token, T content)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            using (var client = new HttpClient())
            {
                var api = "http://localhost:8080/admin/realms/master/groups";

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
