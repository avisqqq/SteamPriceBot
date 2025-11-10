namespace SteamPriceBot.Application.DTOs;

public record TrackedItemDto(Guid Id, string? MarketHashName,decimal currentPrice, decimal? Threshold, string Currency, Guid marketItemId);
