using SteamPriceBot.Domain.ValueObjects;

namespace SteamPriceBot.Application.Interfaces;

public interface IPriceProvider
{
    Task<PriceValue?> GetCurrentPrice(string marketHashName, string currenyCode, CancellationToken cancellationToken = default);
}