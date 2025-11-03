using System;
using SteamPriceBot.Application.Interfaces;
using SteamPriceBot.Domain.Entities;

namespace SteamPriceBot.Application.Services;

public class HistoryService
{
    private readonly IPriceHistoryRepository _history;
    private readonly IUnitOfWork _uow;
    public HistoryService(IPriceHistoryRepository history, IUnitOfWork uow)
    {
        _history = history;
        _uow = uow;
    }
    public async Task AddRecordAsync(Guid trackedItemId, PriceRecord record,CancellationToken ct = default)
    {
        await _history.AddRecordAsync(trackedItemId, record, ct);
        await _uow.CommitAsync();
    }
}
