using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SteamPriceBot.Domain.Entities;

namespace SteamPriceBot.Application.Interfaces
{
    public interface IMarketItemRepository
    {
        Task AddAsync(MarketItem marketItem, CancellationToken cancellationToken = default);
        Task<MarketItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<MarketItem>> GetAllAsync(CancellationToken cancellationToken = default);
        Task RemoveByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<MarketItem?> GetMarketItemByHashName(string MarketHashName, CancellationToken ct = default);
    }
}