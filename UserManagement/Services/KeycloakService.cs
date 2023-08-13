using UserManagement.Model;
using UserManagement.Utility.Messages;
using Newtonsoft.Json;
using UserManagement.Utility.Token;
using UserManagement.Utility.KeycloakCredentials;

namespace UserManagement.Services
{
    /// <summary>
    /// Defines operations for keycloak
    /// </summary>
    public class KeycloakService : IKeycloakService
    {
        /// <summary>
        /// Provides a logi for keycloak.
        /// </summary>
        /// <param name="credentials">The KeycloakCredentials for keycloak login.</param>
        /// <returns>A string if the validation is successful.</returns>
        public string KeycloakLogin(KeycloakCredentials credentials)
        {
            var validation = string.Empty;

            Credentials.Login(credentials.Username, credentials.Password);

            if(KeycloakToken.Token != null)
            {
                validation = "Login successful.";
            }
            
            return validation;
        }

        public string CreateUsers(User user)
        {
            var postMessage = new HttpPostMessage();

            var token = KeycloakToken.Token;

            return postMessage.GetResultMessage(token, user);
        }

        public List<User> GetUser()
        {
            List<User>? user = new List<User>();

            var getMessage = new HttpGetMessage();

            var token = KeycloakToken.Token;

            var result = getMessage.GetResultMessage<string>(token, string.Empty);

            if(result != null)
            {
                user = JsonConvert.DeserializeObject<List<User>>(result);
            }

            if (user != null)
            {
                return user;
            }

            throw new Exception("Result is null");
        }
    }
}
