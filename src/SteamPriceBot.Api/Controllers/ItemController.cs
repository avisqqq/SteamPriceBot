using Microsoft.AspNetCore.Mvc;
using SteamPriceBot.Application.Commands.RemoveTrackedItem;
using SteamPriceBot.Application.Commands.TrackItem;
using SteamPriceBot.Application.Commands.UpdateThreshold;
using SteamPriceBot.Application.Common;
using SteamPriceBot.Application.DTOs;
using SteamPriceBot.Application.Queries.GetTrackedItem;

namespace SteamPriceBot.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly ICommandHandler<TrackItemCommand> _track;
        private readonly ICommandHandler<UpdateThresholdCommand> _update;
        private readonly ICommandHandler<RemoveTrackedItemCommand> _remove;
        private readonly IQueryHandler<GetTrackedItemQuery, IEnumerable<TrackedItemDto>> _get;

        public ItemsController(
            ICommandHandler<TrackItemCommand> track,
            ICommandHandler<UpdateThresholdCommand> update,
            ICommandHandler<RemoveTrackedItemCommand> remove,
            IQueryHandler<GetTrackedItemQuery, IEnumerable<TrackedItemDto>> get)
        {
            _track = track;
            _update = update;
            _remove = remove;
            _get = get;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
            => Ok(await _get.HandleAsync(new GetTrackedItemQuery(), ct));

        [HttpPost]
        public async Task<IActionResult> Track([FromBody] TrackItemCommand cmd, CancellationToken ct)
        {
            await _track.HandleAsync(cmd, ct);
            return Ok();
        }
        [HttpPut("{id:guid}/threshold")]
        public async Task<IActionResult> UpdateThreshold(Guid id, [FromBody] decimal threshold, CancellationToken ct)
        {
            await _update.HandleAsync(new UpdateThresholdCommand(id, threshold), ct);
            return Ok("Threshold updated");
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> RemoveItem(Guid id, CancellationToken ct)
        {
            await _remove.HandleAsync(new RemoveTrackedItemCommand(id), ct);
            return Ok("Item removed");
        }
    }
}