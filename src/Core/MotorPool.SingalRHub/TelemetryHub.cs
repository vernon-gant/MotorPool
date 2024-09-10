using Microsoft.AspNetCore.SignalR;
using MotorPool.TelemetryService;

namespace MotorPool.SingalRHub;

public class TelemetryHub : Hub
{
    public async Task SendTelemetry(CANTelemetry telemetry)
    {
        await Clients.All.SendAsync("ReceiveTelemetry", telemetry);
    }
}