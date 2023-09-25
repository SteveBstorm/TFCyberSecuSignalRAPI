using Microsoft.AspNetCore.SignalR;

namespace SignalRAPI.Hubs
{
    public class ArticleHub : Hub
    {
        public async Task RefreshArticle()
        {
            await Clients.All.SendAsync("notifyNewArticle");
        }
    }
}
