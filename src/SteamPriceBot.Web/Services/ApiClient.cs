using System.Net.Http.Json;
using SteamPriceBot.Application.DTOs;

namespace SteamPriceBot.Web.Services;


public class ApiClient
{
    private HttpClient _api;

    public ApiClient(HttpClient http)
    {
        _api = http;
    }

    public async Task<IEnumerable<TrackedItemDto>> GetTrackedItemAsync()
        => await _api.GetFromJsonAsync<IEnumerable<TrackedItemDto>>($"/api/items")
            ?? Enumerable.Empty<TrackedItemDto>();
}