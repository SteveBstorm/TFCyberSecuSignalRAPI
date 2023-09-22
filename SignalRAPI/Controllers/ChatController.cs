using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRAPI.Hubs;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly ChatHub hub;

        public ChatController(ChatHub Hub)
        {
            hub = Hub;
        }
        [HttpPost]
        public async Task<IActionResult> Login(string password, string email)
        {
            //sur base de l'id de connection, je vais récup la liste des groupe du user
            //et je le reinscrit dans ses groupes au niveau du hub
            await hub.JoinGroup("groupname", "username");
            return Ok();
        }
    }
}
