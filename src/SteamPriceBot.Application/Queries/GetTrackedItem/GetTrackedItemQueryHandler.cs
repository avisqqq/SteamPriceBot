using System;
using SteamPriceBot.Application.Common;
using SteamPriceBot.Application.DTOs;

namespace SteamPriceBot.Application.Queries.GetTrackedItem;

public class GetTrackedItemQueryHandler : IQueryHandler<GetTrackedItemQuery, IEnumerable<TrackedItemDto>>
{
    public Task<IEnumerable<TrackedItemDto>> HandleAsync (GetTrackedItemQuery query, CancellationToken ct = default)
    {
        throw new NotImplementedException();    
    }
}
