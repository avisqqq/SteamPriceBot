using Microsoft.AspNetCore.Mvc;
using SteamPriceBot.Application.Commands.TrackItem;
using SteamPriceBot.Application.Common;
using SteamPriceBot.Application.DTOs;
using SteamPriceBot.Application.Queries.GetTrackedItem;

namespace SteamPriceBot.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly ICommandHandler<TrackItemCommand> _track;
    private readonly IQueryHandler<GetTrackedItemQuery, IEnumerable<TrackedItemDto>> _get;

    public ItemsController(
        ICommandHandler<TrackItemCommand> track,
        IQueryHandler<GetTrackedItemQuery, IEnumerable<TrackedItemDto>> get)
    {
        _track = track;
        _get = get;
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken ct)
        => Ok(await _get.HandleAsync(new GetTrackedItemQuery(), ct));

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TrackItemCommand cmd, CancellationToken ct)
    {
        await _track.HandleAsync(cmd, ct);
        return Ok();
    }
}