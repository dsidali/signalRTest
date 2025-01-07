using Microsoft.AspNetCore.SignalR;

namespace signalRTest
{
    public class ChatHub:Hub
    {
        public override async Task OnConnectedAsync()
        {
        //this is a comment
            await Clients.All.SendAsync("ReceiveMessage", $"{Context.ConnectionId} is here");
        }
    }
}
