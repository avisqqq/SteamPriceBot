using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SteamPriceBot.Infrastructure.Persistence;
using SteamPriceBot.Application.Services;


namespace SteamPriceBot.Infrastructure.Hosted
{
    public class PriceTrackingBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _services;
        private readonly TimeSpan _interval = TimeSpan.FromMinutes(10);
        public PriceTrackingBackgroundService(IServiceProvider services)
        {
            _services = services;
        }
        protected override async Task ExecuteAsync(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                using var scope = _services.CreateScope();
                var tracker = scope.ServiceProvider.GetRequiredService<PriceTrackingService>();
                try
                {
                    await tracker.RefreshPricesAsync(ct);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[PriceTrackingService: Error: {ex.Message}]");
                }
                await Task.Delay(_interval, ct);
            }
        }
    }
}