using Microsoft.AspNetCore.SignalR;

namespace signalRTest
{
    public class ChatHub:Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("ReceiveMessage", $"{Context.ConnectionId} is here");
        }
    }
}
