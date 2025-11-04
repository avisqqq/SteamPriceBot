using System;
using SteamPriceBot.Application.Interfaces;
using Discord.Webhook;

namespace SteamPriceBot.Infrastructure.Notifications;

public class DiscordNotificationService : INotificationService
{
    private readonly DiscordWebhookClient _client;

    public DiscordNotificationService(string webhookUrl)
    => _client = new DiscordWebhookClient(webhookUrl);

    public async Task SendAlertAsync(string msg, CancellationToken ct = default)
        => await _client.SendMessageAsync(msg);
}
