
using Microsoft.EntityFrameworkCore;
using SteamPriceBot.Application.Interfaces;
using SteamPriceBot.Domain.Entities;

namespace SteamPriceBot.Infrastructure.Persistence.Repositories
{
    public class MarketItemRepository : IMarketItemRepository
    {
        
        private readonly ApplicationDbContext _ctx;
    public MarketItemRepository(ApplicationDbContext ctx)
        => _ctx = ctx;

    public async Task AddAsync(MarketItem marketItem, CancellationToken ct = default)
        => await _ctx.MarketItems.AddAsync(marketItem, ct);

    public async Task<MarketItem?> GetByIdAsync(Guid id, CancellationToken ct = default)
        => await _ctx.MarketItems.FirstOrDefaultAsync(x => x.Id == id, ct);

        public async Task<IEnumerable<MarketItem>> GetAllAsync(CancellationToken ct = default)
            =>await _ctx.MarketItems.ToListAsync(ct);

        public async Task RemoveByIdAsync(Guid id, CancellationToken ct = default)
        => await _ctx.MarketItems.Where(x => x.Id == id)
        .ExecuteDeleteAsync(ct);
        public async Task<MarketItem?> GetMarketItemByHashName(string marketHashName, CancellationToken ct)
        {
            return await _ctx.MarketItems.FirstOrDefaultAsync(x => x.DisplayName == marketHashName, ct);
        }
    }
}