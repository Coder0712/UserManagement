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

            return postMessage.GetResultMessage("users", token, user);
        }

        public List<Serialization.Model.Users> GetUser()
        {
            List<Serialization.Model.Users>? user = new List<Serialization.Model.Users>();

            var getMessage = new HttpGetMessage();

            var token = KeycloakToken.Token;

            var result = getMessage.GetResultMessage<string>("users", token, string.Empty);

            if(result != null)
            {
                user = JsonConvert.DeserializeObject<List<Serialization.Model.Users>>(result);
            }

            if (user != null)
            {
                return user;
            }

            throw new Exception("Result is null");
        }

        public string CreateGroup(KcGroup kcGroup)
        {
            var postMessage = new HttpPostMessage();

            var token = KeycloakToken.Token;

            return postMessage.GetResultMessage("groups", token, kcGroup);
        }

        public List<Serialization.Model.KcGroups> GetGroups()
        {
            List<Serialization.Model.KcGroups>? groups = new List<Serialization.Model.KcGroups>();

            var getMessage = new HttpGetMessage();

            var token = KeycloakToken.Token;

            var result = getMessage.GetResultMessage<string>("groups", token, string.Empty);

            if (result != null)
            {
                groups = JsonConvert.DeserializeObject<List<Serialization.Model.KcGroups>>(result);
            }

            if (groups != null)
            {
                return groups;
            }

            throw new Exception("Result is null");
        }

        public string AddUserToGroup(Guid userId, Guid groupId)
        {
            var token = KeycloakToken.Token;

            var putMessage = new HttpPutMessage();

            _ = putMessage.GetResultMessage<string>("users/" + userId.ToString() + "/groups/" + groupId.ToString(), token, null);

            return "User added to group.";
        }
    }
}
