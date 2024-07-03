using Microsoft.AspNetCore.SignalR.Client;

namespace MotorPool.TelemetryService;

public class Worker(ILogger<Worker> logger) : BackgroundService
{
    private HubConnection _hubConnection;

    public override async Task StartAsync(CancellationToken cancellationToken)
    {
        _hubConnection = new HubConnectionBuilder()
                        .WithUrl("http://localhost:5000/telemetryHub")
                        .Build();

        _hubConnection.On<CANTelemetry>("ReceiveTelemetry", TelemetryProcessor.Process);

        await _hubConnection.StartAsync(cancellationToken);
        TelemetryProcessor.SpeedFilter();

        await base.StartAsync(cancellationToken);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            logger.LogInformation("Worker running at: {Time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        await _hubConnection.StopAsync(cancellationToken);
        await _hubConnection.DisposeAsync();
        await base.StopAsync(cancellationToken);
    }
}