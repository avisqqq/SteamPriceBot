using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SteamPriceBot.Application.Common;
using SteamPriceBot.Application.DTOs;
using SteamPriceBot.Application.Queries.GetMarketPrice;

namespace SteamPriceBot.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarketController : ControllerBase
    {
        
        private readonly IQueryHandler<GetMarketPriceQuery, PriceDto> _get;
        public MarketController(IQueryHandler<GetMarketPriceQuery, PriceDto> get)
        {
            _get = get;
        }
        [HttpGet("{marketHashName}")]
        public async Task<IActionResult> GetPrice(string marketHashName, CancellationToken ct)
        {
            var result = await _get.HandleAsync(new GetMarketPriceQuery(marketHashName, "USD"), ct);
            return Ok(result);
        }
    }
}