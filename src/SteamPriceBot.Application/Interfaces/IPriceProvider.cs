using SteamPriceBot.Domain.ValueObjects;

namespace SteamPriceBot.Application.Interfaces;

public interface IPriceProvider
{
    Task<PriceValue?> GetCurrentPriceAsync(string marketHashName, string currencyCode, CancellationToken cancellationToken = default);
}