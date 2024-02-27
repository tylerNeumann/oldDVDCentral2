using Microsoft.AspNetCore.SignalR;

namespace TN.DVDCentral.API2.Hubs
{
    public class BingoHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            // do bl stuff - game logic
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
