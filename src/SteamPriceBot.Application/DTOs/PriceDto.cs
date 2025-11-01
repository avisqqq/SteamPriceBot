namespace SteamPriceBot.Application.DTOs;

public record PriceDto(string MarketHashName, decimal Amount, string Currency);