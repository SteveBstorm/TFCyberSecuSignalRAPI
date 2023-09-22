using Microsoft.AspNetCore.SignalR;
using SignalRAPI.Models;

namespace SignalRAPI.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message)
        {
            await Clients.All.SendAsync("receiveMessage", message);
        }

        public async Task JoinGroup(string groupName, string username)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await SendToGroup(new Message
            {
                Author = "System",
                Content = "Un nouvel utilisateur s'est connecté : " + username
            }, groupName); 
        }

        public async Task SendToGroup(Message message, string groupName)
        {
            await Clients.Group(groupName).SendAsync("messageFromGroup",message);
        }
    }
}
