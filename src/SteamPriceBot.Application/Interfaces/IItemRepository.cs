using SteamPriceBot.Domain.Entities;

namespace SteamPriceBot.Application.Interfaces;

public interface IItemRepository
{
    Task AddAsync(TrackedItem trackedItem, CancellationToken cancellationToken = default);
    Task<TrackedItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<TrackedItem>> GetAllAsync(CancellationToken cancellationToken = default);
    Task RemoveByIdAsync(Guid id, CancellationToken cancellationToken = default);
}