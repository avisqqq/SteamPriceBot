using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SteamPriceBot.Application.Common;
using SteamPriceBot.Application.Interfaces;
using SteamPriceBot.Domain.Entities;
using SteamPriceBot.Domain.ValueObjects;

namespace SteamPriceBot.Application.Commands.TrackItem
{
    public class TrackItemCommandHandler : ICommandHandler<TrackItemCommand>
    {
        private readonly IItemRepository _repo;
        private readonly IPriceProvider _priceProvider;
        private readonly IUnitOfWork _uow;
        public TrackItemCommandHandler(IItemRepository repo, IPriceProvider priceProvider, IUnitOfWork uow)
        {
            _repo = repo;
            _priceProvider = priceProvider;
            _uow = uow;
        }

        public async Task HandleAsync(TrackItemCommand command, CancellationToken ct = default)
        {
            var price = await _priceProvider.GetCurrentPrice(command.MarketHashName, command.CurrencyCode, ct)
                ?? throw new ApplicationException($"Price for {command.MarketHashName} not found");
            var itemId = new ItemId(730, command.MarketHashName);
            var marketItem = new MarketItem(itemId, command.MarketHashName);
            AlertThreshold? threshold = command.AlertThreshold is not null
                ? AlertThreshold.Create(command.AlertThreshold.Value)
                : null;
            var trackedItem = new TrackedItem(marketItem, threshold);
            trackedItem.EvaluatePrice(price);

            await _repo.AddAsync(trackedItem, ct);
            await _uow.CommitAsync(ct);
        }
    }
}