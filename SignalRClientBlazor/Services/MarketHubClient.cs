using Microsoft.AspNetCore.SignalR.Client;

namespace SignalRClientBlazor.Services;

public class MarketHubClient : IAsyncDisposable
{
    private HubConnection _connection;
    private readonly ILogger<MarketHubClient> _logger;
    private readonly string hubUrl;

    public event Action<string>? OnDataReceived;

    public MarketHubClient(IConfiguration config, ILogger<MarketHubClient> logger)
    {
        _logger = logger;
        hubUrl = config["SignalR:HubUrl"] ?? throw new Exception("HubUrl not configured");

        
    }

    public async Task StartAsync()
    {
        if (_connection is { State: HubConnectionState.Connected or HubConnectionState.Connecting })
            return;
        _connection = new HubConnectionBuilder()
            .WithUrl(hubUrl)
            .WithAutomaticReconnect()
            .Build();

        _connection.On<string>("ReceiveMessage", data =>
        {
            _logger.LogInformation("📥 Received Data: {data}", data);
            OnDataReceived?.Invoke(data);
        });

        if (_connection.State == HubConnectionState.Disconnected)
        {
            _logger.LogInformation("🔄 Starting SignalR connection...");
            await _connection.StartAsync();
            _logger.LogInformation("✅ SignalR connected.");
        }
        else
        {
            _logger.LogWarning("⛔ SignalR already started. Current state: " + _connection.State);
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_connection != null)
        {
            await _connection.DisposeAsync();
        }
    }
}
