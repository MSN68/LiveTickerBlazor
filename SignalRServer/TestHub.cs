using Microsoft.AspNetCore.SignalR;

namespace SignalRServer
{
    public class TestHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("ReceiveMessage", $"Connected at: {DateTime.Now:HH:mm:ss}");
            await base.OnConnectedAsync();
        }
    }
}
