using System;
using SteamPriceBot.Application.Interfaces;
using SteamPriceBot.Domain.Events;

namespace SteamPriceBot.Application.Services;

public class AlertService
{
    private readonly INotificationService _notifier;
    public AlertService(INotificationService notifier)
    {
        _notifier = notifier;
    }
    public async Task HandlePriceThresholdAsync(PriceThresholdReached evt, CancellationToken ct = default)
    {
        var msg = $"⚠️ {evt.Item.DisplayName} dropped below {evt.Threshold.Amount}!\n" +
                $"Current price : {evt.CurrentPrice.Amount} {evt.CurrentPrice.Currency.Code}";
        await _notifier.SendAlertAsync(msg, ct);
    }
}
