using SteamPriceBot.Application.Common;
using SteamPriceBot.Application.DTOs;

namespace SteamPriceBot.Application.Queries.GetTrackedItem;

public record GetTrackedItemQuery() : IQuery<IEnumerable<TrackedItemDto>>;
