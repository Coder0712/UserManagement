using UserManagement.Model;

namespace UserManagement.Services
{
    public interface IKeycloakService
    {
        void CreateUsers(User user);

        List<User> GetUser();
    }
}
