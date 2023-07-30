using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using UserManagement.Model;

namespace UserManagement.Services
{
    /// <summary>
    /// Defines operations for keycloak
    /// </summary>
    public class KeycloakService : IKeycloakService
    {
        public void CreateUsers(User user)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            var token = GetToken();

            using (var client = new HttpClient())
            {
                var api = "http://localhost:8080/admin/realms/master/users";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var json = JsonConvert.SerializeObject(user);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                response = client.PostAsync(api, content).Result;
            }

            if (response.Content.ReadAsStringAsync().Result == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        public List<User> GetUser()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            var token = GetToken();

            using (var client = new HttpClient())
            {
                var api = "http://localhost:8080/admin/realms/master/users";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                response = client.GetAsync(api).GetAwaiter().GetResult();
            }

            if (response.Content.ReadAsStringAsync().Result == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                return JsonConvert.DeserializeObject<List<User>>(response.Content.ReadAsStringAsync().Result);
            }
        }
    }
}
