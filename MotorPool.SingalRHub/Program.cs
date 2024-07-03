using MotorPool.SingalRHub;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

var app = builder.Build();

app.UseRouting();

app.MapHub<TelemetryHub>("/telemetryHub");

app.Run();