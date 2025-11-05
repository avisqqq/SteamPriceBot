using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SteamPriceBot.Application.Services;
using SteamPriceBot.Infrastructure;

using SteamPriceBot.TelegramWorker;
IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddInfrastructure(context.Configuration);
        services.AddScoped<PriceTrackingService>();
        services.AddHostedService<TelegramWorkerService>();
    }
    ).Build();

await host.RunAsync();
