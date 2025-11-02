using System;
using SteamPriceBot.Application.Common;
using SteamPriceBot.Application.DTOs;

namespace SteamPriceBot.Application.Queries.GetItemHistory;

public class GetItemHistoryQueryHandler : IQueryHandler<GetItemHistoryQuery, IEnumerable<HistoryRecordDto>>
{
    public Task<IEnumerable<HistoryRecordDto>> HandleAsync(GetItemHistoryQuery query, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}
