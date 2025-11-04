using System;
using System.Net.Http.Json;
using System.Text.Json;
using SteamPriceBot.Application.Interfaces;
using SteamPriceBot.Domain.ValueObjects;

namespace SteamPriceBot.Infrastructure.Providers;

public class SteamPriceProviders : IPriceProvider
{
    private readonly HttpClient _http;

    public SteamPriceProviders(HttpClient http)
    {
        _http = http;
        _http.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (SteamPriceBot)");
    }
    public async Task<PriceValue?> GetCurrentPriceAsync(string marketHashName,
    string currencyCode,
    CancellationToken ct = default)
    {
        var currency = currencyCode.ToUpperInvariant()
        switch
        {
            "USD" => 1,
            "EUR" => 3,
            "PLN" => 6,
            _ => 1
        };
        try
        {


            var url =
            $"https://steamcommunity.com/market/priceoverview/?appid=730&market_hash_name={marketHashName}&currency={currency}";
            var json = await _http.GetFromJsonAsync<JsonElement>(url, ct);
            if (!json.TryGetProperty("lowest_price", out var priceElement))
                return null;
            var raw = priceElement.GetString()?.Replace("$", "").Replace(",", ".").Trim();
            if (decimal.TryParse(raw, out var amount))
                return new PriceValue(amount, new Currency(currencyCode));

            return null;
        }
        catch
        {
            return null;
        }
    }
}
