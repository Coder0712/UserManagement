using UserManagement.Model;

namespace UserManagement.Services
{
    public interface IKeycloakService
    {
        string KeycloakLogin(KeycloakCredentials credentials);

        string CreateUsers(User user);

        List<Serialization.Model.Users> GetUser();

        string CreateGroup(KcGroup kcGroup);

        List<Serialization.Model.KcGroups> GetGroups();

        string AddUserToGroup(Guid userId, Guid groupId);
    }
}
