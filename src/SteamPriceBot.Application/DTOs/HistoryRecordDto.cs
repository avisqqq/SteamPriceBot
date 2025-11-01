namespace SteamPriceBot.Application.DTOs;

public record HistoryRecordDto(DateTime TimestampUtc, decimal Price, string Currency);