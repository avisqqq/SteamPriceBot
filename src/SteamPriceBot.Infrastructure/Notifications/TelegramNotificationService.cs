using System;
using SteamPriceBot.Application.Interfaces;
using Telegram.Bot;

namespace SteamPriceBot.Infrastructure.Notifications;

public class TelegramNotificationService : INotificationService
{
    private readonly TelegramBotClient _bot;
    private readonly string _chatId;
    public TelegramNotificationService(string token,
    string chatId)
    {
        _bot = new TelegramBotClient(token);
        _chatId = chatId;
    }
    public async Task SendAlertAsync(string msg, CancellationToken ct = default)
        => await _bot.SendMessage(_chatId, msg, cancellationToken: ct);
}
