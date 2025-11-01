namespace SteamPriceBot.Application.Interfaces;

public interface INotificationService
{
    Task SendAlertAsync(string msg, CancellationToken ct = default);
}