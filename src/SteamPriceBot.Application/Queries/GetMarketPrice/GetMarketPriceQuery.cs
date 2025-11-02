using SteamPriceBot.Application.Common;
using SteamPriceBot.Application.DTOs;

namespace SteamPriceBot.Application.Queries.GetMarketPrice;

public record GetMarketPriceQuery(string MarketHashName, string CurrencyCode) : IQuery<PriceDto>;