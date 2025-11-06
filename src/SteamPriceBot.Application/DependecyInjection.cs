using Microsoft.Extensions.DependencyInjection;
using SteamPriceBot.Application.Commands.RemoveTrackedItem;
using SteamPriceBot.Application.Common; 
using SteamPriceBot.Application.Commands.TrackItem;
using SteamPriceBot.Application.Queries.GetTrackedItem;

namespace SteamPriceBot.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register all ICommandHandler<T>
        services.Scan(scan => scan
            .FromAssemblyOf<RemoveTrackedItemCommandHandler>()
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        // Register all IQueryHandler<TQuery, TResult>
        services.Scan(scan => scan
            .FromAssemblyOf<GetTrackedItemQueryHandler>()
            .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}