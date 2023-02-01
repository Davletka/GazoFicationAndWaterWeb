using Microsoft.AspNetCore.SignalR;

namespace GazoFicationAndWaterWeb.Data
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {0900

            await Clients.All.SendAsync("ReceiveMessage", user , message);
        }
    }
}
