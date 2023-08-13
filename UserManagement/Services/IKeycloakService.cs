using UserManagement.Model;
using UserManagement.Utility.KeycloakCredentials;

namespace UserManagement.Services
{
    public interface IKeycloakService
    {
        string KeycloakLogin(KeycloakCredentials credentials);

        //string CreateUsers(User user);

        List<User> GetUser();
    }
}
