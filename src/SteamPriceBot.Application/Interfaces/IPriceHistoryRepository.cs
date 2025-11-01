using SteamPriceBot.Domain.Entities;
namespace SteamPriceBot.Application.Interfaces;

public interface IPriceHistoryRepository
{
    Task AddRecordAsync(PriceRecord record, CancellationToken cancellationToken = default);
    Task <IEnumerable<PriceRecord>> GetHistoryAsync(Guid id, CancellationToken cancellationToken = default);
}