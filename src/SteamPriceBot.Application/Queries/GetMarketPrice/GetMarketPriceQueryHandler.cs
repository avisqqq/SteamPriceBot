using System;
using SteamPriceBot.Application.Common;
using SteamPriceBot.Application.DTOs;

namespace SteamPriceBot.Application.Queries.GetMarketPrice;

public class GetMarketPriceQueryHandler : IQueryHandler<GetMarketPriceQuery, PriceDto>
{ 
    public Task<PriceDto> HandleAsync(GetMarketPriceQuery query, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}
