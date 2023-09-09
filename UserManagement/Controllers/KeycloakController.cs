using Microsoft.AspNetCore.Mvc;
using UserManagement.Model;
using UserManagement.Services;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeycloakController : ControllerBase
    {
        private readonly IKeycloakService _keycloakService;

        public KeycloakController(IKeycloakService keycloakService)
        {
            _keycloakService = keycloakService;
        }

        [HttpPost]
        public async Task<ActionResult<string>> KeycloakLogin(KeycloakCredentials credentials)
        {
            return Ok(_keycloakService.KeycloakLogin(credentials));
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<User>> CreateUsers(User user)
        {
            return Ok(_keycloakService.CreateUsers(user));
        }

        [HttpGet("Users")]
        public async Task<ActionResult<List<User>>> GetUser()
        {
            return Ok(_keycloakService.GetUser());
        }

        [HttpPost("CreateGroup")]
        public async Task<ActionResult<KcGroup>> CreateGroup(KcGroup kcGroup)
        {
            return Ok(_keycloakService.CreateGroup(kcGroup));
        }

        [HttpGet("Groups")]
        public async Task<ActionResult<List<Serialization.Model.KcGroups>>> GetGroups()
        {
            return Ok(_keycloakService.GetGroups());
        }

        [HttpPut("AddUserToGroup")]
        public async Task<ActionResult<string>> AddUserToGroup(Guid userId, Guid groupId)
        {
            return Ok(_keycloakService.AddUserToGroup(userId, groupId));
        }
    }
}
