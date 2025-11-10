using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SteamPriceBot.Application.Common;
using SteamPriceBot.Application.DTOs;
using SteamPriceBot.Application.Interfaces;
using SteamPriceBot.Domain.Entities;
using SteamPriceBot.Domain.ValueObjects;

namespace SteamPriceBot.Application.Queries.GetTrackedItem;

public class GetTrackedItemQueryHandler : IQueryHandler<GetTrackedItemQuery, IEnumerable<TrackedItemDto>>
{
    private readonly IItemRepository _repo;
    private readonly IPriceProvider _price;

    public GetTrackedItemQueryHandler(IItemRepository repo, IPriceProvider price)
    {
        _repo = repo;
        _price = price;
    }

    public async Task<IEnumerable<TrackedItemDto>> HandleAsync(GetTrackedItemQuery query, CancellationToken ct = default)
    {
        var items = await _repo.GetAllAsync(ct);

        var dtoTasks = items.Select(async t =>
        {
            PriceValue? currentPrice = null;

            if (t.Item != null)
            {
                try
                {
                    // adapt parameters if your provider signature differs
                    currentPrice = await _price.GetCurrentPriceAsync(t.Item.DisplayName, "USD" ,ct);
                }
                catch
                {
                    // swallow provider errors and leave price as null
                    currentPrice = null;
                }
            }

        return new TrackedItemDto(
            t.Id,
            t.Item?.DisplayName,
            currentPrice.Amount,
            t.Threshold?.Amount,
            t.Threshold is null ? "N/A" : "USD",
            t.Item.Id
            );
        });

        var dtos = await Task.WhenAll(dtoTasks);
        return dtos.AsEnumerable();
    }
}
