using System;
using SteamPriceBot.Application.Common;
using SteamPriceBot.Application.DTOs;
using SteamPriceBot.Application.Interfaces;
using SteamPriceBot.Domain.Entities;

namespace SteamPriceBot.Application.Queries.GetTrackedItem;

public class GetTrackedItemQueryHandler : IQueryHandler<GetTrackedItemQuery, IEnumerable<TrackedItemDto>>
{
     private readonly IItemRepository _repo;
        public GetTrackedItemQueryHandler(IItemRepository repo)
        {
            _repo = repo;
        }
    public async Task<IEnumerable<TrackedItemDto>> HandleAsync (GetTrackedItemQuery query, CancellationToken ct = default)
    {
        var item = await _repo.GetAllAsync(ct);
        return item.Select(t => new TrackedItemDto(
        t.Id,
        t.Item!.DisplayName,
        t.Threshold?.Amount,
        t.Threshold is null ? "N/A" : "USD",
        t.Item.Id)
        );       
    }
}
