using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;

namespace MotorPool.TelegramBot;

public interface BotHandler
{
    Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken);

    Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken);
}

public class DefaultBotHandler(ILogger<DefaultBotHandler> logger) : BotHandler
{
    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message is not { } message) return;

        if (message.Text is not { } messageText) return;

        long chatId = message.Chat.Id;

        await botClient.SendTextMessageAsync(chatId, "Ya zhestoko drochil allochke v rot", cancellationToken: cancellationToken);
    }

    public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        var ErrorMessage = exception switch
        {
            ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };

        logger.LogError(ErrorMessage, "Error occured");
        return Task.CompletedTask;
    }
}