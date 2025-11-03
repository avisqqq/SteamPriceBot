using System;
using SteamPriceBot.Application.Common;
using SteamPriceBot.Application.DTOs;
using SteamPriceBot.Application.Interfaces;

namespace SteamPriceBot.Application.Queries.GetItemHistory;

public class GetItemHistoryQueryHandler : IQueryHandler<GetItemHistoryQuery, IEnumerable<HistoryRecordDto>>
{
    private readonly IPriceHistoryRepository _repo;
    public GetItemHistoryQueryHandler(IPriceHistoryRepository repo)
    {
        _repo = repo;
    }
    public async Task<IEnumerable<HistoryRecordDto>> HandleAsync(GetItemHistoryQuery query, CancellationToken ct = default)
    {
        var history = await _repo.GetHistoryAsync(query.TrackedItemId, ct);
        return history.Select(h => new HistoryRecordDto(
            h.TimestampUtc,
            h.Price.Amount,
            h.Price.Currency.Code
        ));
    }
}
