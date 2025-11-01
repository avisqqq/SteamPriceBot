namespace SteamPriceBot.Application.DTOs;

public record TrackedItemDto(Guid Id, string MarketHashName, decimal? Threshold, string Currency);
