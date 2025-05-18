using Microsoft.AspNetCore.SignalR;

namespace SignalRServer
{
    public class MessageSenderService : BackgroundService
    {
        private readonly IHubContext<TestHub> _hubContext;

        public MessageSenderService(IHubContext<TestHub> hubContext)
        {
            _hubContext = hubContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var message = $"Broadcast: {DateTime.Now:HH:mm:ss}";
                await _hubContext.Clients.All.SendAsync("ReceiveMessage", message, cancellationToken: stoppingToken);
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}