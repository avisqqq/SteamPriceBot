using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SteamPriceBot.Application.Common;
using SteamPriceBot.Application.DTOs;
using SteamPriceBot.Application.Queries.GetItemHistory;

namespace SteamPriceBot.Api.Controllers{

    [ApiController]
    [Route("api/[controller]")]
    public class HistoryController : ControllerBase
    {
        
        private readonly IQueryHandler<GetItemHistoryQuery, IEnumerable<HistoryRecordDto>> _get;
        public HistoryController(IQueryHandler<GetItemHistoryQuery, IEnumerable<HistoryRecordDto>> get)
        {
            _get = get;
        }
        [HttpGet("{trackedItemId:guid}")]
        public async Task<IActionResult> GetItemHistory(Guid trackedItemId, CancellationToken ct)
        {
            var result = await _get.HandleAsync(new GetItemHistoryQuery(trackedItemId), ct);
            return Ok(result);
        }
    }
}