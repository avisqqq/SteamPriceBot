using System;
using SteamPriceBot.Application.Interfaces;
using SteamPriceBot.Domain.Entities;

namespace SteamPriceBot.Application.Services;

public class PriceTrackingService
{
    private readonly IItemRepository _items;
    private readonly IPriceHistoryRepository _history;

    private IPriceProvider _provider;
    private IUnitOfWork _uow;
    public PriceTrackingService(IItemRepository items,
    IPriceHistoryRepository history,
    IPriceProvider provider,
    IUnitOfWork uow)
    {
        _items = items;
        _history = history;
        _provider = provider;
        _uow = uow;
    }
    public async Task RefreshPricesAsync(CancellationToken ct = default)
    {
        var all = await _items.GetAllAsync(ct);
        foreach (var tracked in all)
        {
            var price = await _provider.GetCurrentPrice(tracked.Item.ItemId.MarketHashName,
            "USD", ct);

            if (price is null)
                continue;

            tracked.EvaluatePrice(price);
            await _history.AddRecordAsync(tracked.Id, new PriceRecord(price), ct);
        }

        await _uow.CommitAsync(ct);
    }
}
