using System;
using SteamPriceBot.Application.Common;
using SteamPriceBot.Application.DTOs;
using SteamPriceBot.Application.Interfaces;

namespace SteamPriceBot.Application.Queries.GetMarketPrice;

public class GetMarketPriceQueryHandler : IQueryHandler<GetMarketPriceQuery, PriceDto>
{
    private readonly IPriceProvider _provider;
    public GetMarketPriceQueryHandler(IPriceProvider provider)
    {
        _provider = provider;
    }
    public async Task<PriceDto> HandleAsync(GetMarketPriceQuery query, CancellationToken ct = default)
    {
        var price = await _provider.GetCurrentPriceAsync(query.MarketHashName, query.CurrencyCode, ct)
             ?? throw new ApplicationException($"Could not fetch price for {query.MarketHashName}");
        return new PriceDto(query.MarketHashName, price.Amount, price.Currency.Code);
    }
}
