using Microsoft.AspNetCore.SignalR;

namespace TN.DVDCentral.API2.Hubs
{
    public class BingoHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("RecieveMessage", user, message);
        }
    }
}
