using System;
using Microsoft.EntityFrameworkCore;
using SteamPriceBot.Application.Interfaces;
using SteamPriceBot.Domain.Entities;

namespace SteamPriceBot.Infrastructure.Persistence.Repositories;

public class PriceHistoryRepository : IPriceHistoryRepository
{
    private readonly ApplicationDbContext _ctx;
    public PriceHistoryRepository(ApplicationDbContext ctx)
        => _ctx = ctx;

    public async Task AddRecordAsync(PriceRecord priceRecord, CancellationToken ct = default)
        => await _ctx.PriceRecords.AddAsync(priceRecord, ct);

    public async Task<IEnumerable<PriceRecord>> GetHistoryAsync(Guid id, CancellationToken ct = default) 
        => await _ctx.PriceRecords
        .Where(x => x.TrackedItemId == id)
        .OrderByDescending(x => x.TimestampUtc)
        .ToListAsync(ct);
}
