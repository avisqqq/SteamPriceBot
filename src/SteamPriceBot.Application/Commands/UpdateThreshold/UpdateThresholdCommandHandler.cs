using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SteamPriceBot.Application.Common;
using SteamPriceBot.Application.Interfaces;
using SteamPriceBot.Domain.ValueObjects;

namespace SteamPriceBot.Application.Commands.UpdateThreshold
{
    public class UpdateThresholdCommandHandler : ICommandHandler<UpdateThresholdCommand>
    {
        private readonly IItemRepository _repo;
        private readonly IUnitOfWork _uow;
        public UpdateThresholdCommandHandler(IItemRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }
        public async Task HandleAsync(UpdateThresholdCommand command, CancellationToken ct = default)
        {
            var item = await _repo.GetByIdAsync(command.TrackItemId, ct)
                ?? throw new Exception($"Tracked item {command.TrackItemId} not found");

            item.UpdateThreshold(AlertThreshold.Create(command.NewThreshold));

            await _uow.CommitAsync(ct);
        }
    }
}