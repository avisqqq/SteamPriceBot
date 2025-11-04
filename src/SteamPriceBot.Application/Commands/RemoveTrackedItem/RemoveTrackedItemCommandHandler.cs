using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SteamPriceBot.Application.Common;
using SteamPriceBot.Application.Interfaces;

namespace SteamPriceBot.Application.Commands.RemoveTrackedItem
{
    public class RemoveTrackedItemCommandHandler : ICommandHandler<RemoveTrackedItemCommand>
    {
        private readonly IItemRepository _repo;
        private readonly IUnitOfWork _uow;

        public RemoveTrackedItemCommandHandler(IItemRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }
        public async Task HandleAsync(RemoveTrackedItemCommand command, CancellationToken ct = default)
        {
            await _repo.RemoveByIdAsync(command.TrackedItemId, ct);
            await _uow.CommitAsync(ct);
        }
    }
}