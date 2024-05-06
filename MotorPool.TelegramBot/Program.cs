using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MotorPool.TelegramBot;
using Serilog;
using Telegram.Bot;

HostApplicationBuilder hostBuilder = Host.CreateApplicationBuilder();

hostBuilder.Logging.ClearProviders();
hostBuilder.Logging.AddSerilog();

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{hostBuilder.Environment.EnvironmentName}.json", optional: true)
    .Build();
hostBuilder.Services.AddSerilog(loggerConfiguration => loggerConfiguration.ReadFrom.Configuration(configuration));

string botToken = hostBuilder.Configuration.GetValue<string>("Telegram:BotToken") ?? throw new InvalidOperationException();
hostBuilder.Services.AddSingleton<ITelegramBotClient>(_ => new TelegramBotClient(botToken));
hostBuilder.Services.AddScoped<BotHandler, DefaultBotHandler>();
hostBuilder.Services.AddHostedService<BotHostedService>();

hostBuilder.Build().Run();