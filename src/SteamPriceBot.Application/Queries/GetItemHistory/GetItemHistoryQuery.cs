using SteamPriceBot.Application.Common;
using SteamPriceBot.Application.DTOs;

namespace SteamPriceBot.Application.Queries.GetItemHistory;

public record GetItemHistoryQuery(Guid TrackedItem) : IQuery<IEnumerable<HistoryRecordDto>>;
