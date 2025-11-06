using System;
using Microsoft.EntityFrameworkCore;
using SteamPriceBot.Application.Interfaces;
using SteamPriceBot.Domain.Entities;

namespace SteamPriceBot.Infrastructure.Persistence.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly ApplicationDbContext _ctx;
    public ItemRepository(ApplicationDbContext ctx)
        => _ctx = ctx;

    public async Task AddAsync(TrackedItem trackedItem, CancellationToken ct = default)
        => await _ctx.TrackedItems.AddAsync(trackedItem, ct);

    public async Task<TrackedItem?> GetByIdAsync(Guid id, CancellationToken ct = default)
        => await _ctx.TrackedItems.Include(x => x.Item).FirstOrDefaultAsync(x => x.Id == id, ct);

    public async Task<IEnumerable<TrackedItem>> GetAllAsync(CancellationToken ct = default)
        => await _ctx.TrackedItems.Include(x => x.Item).ToListAsync(ct);

    public async Task RemoveByIdAsync(Guid id, CancellationToken ct = default)
    => await _ctx.TrackedItems.Where(x => x.Id == id)
    .ExecuteDeleteAsync(ct);

}
