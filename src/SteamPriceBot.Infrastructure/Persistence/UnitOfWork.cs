using System;
using SteamPriceBot.Application.Interfaces;

namespace SteamPriceBot.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _ctx;
    public UnitOfWork(ApplicationDbContext ctx)
        => _ctx = ctx;

    public async Task CommitAsync(CancellationToken ct = default)
        => await _ctx.SaveChangesAsync(ct);
}
