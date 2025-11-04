using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SteamPriceBot.Application.Interfaces;
using SteamPriceBot.Infrastructure.Notifications;
using SteamPriceBot.Infrastructure.Persistence;
using SteamPriceBot.Infrastructure.Providers;

namespace SteamPriceBot.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        // EF Core Sqlite
        services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlite(config.GetConnectionString("DefaultConnection") ?? "Data Source =steampricebot.db"));

        //Repositories 
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<IPriceHistoryRepository, PriceHistoryRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Providers
        services.AddHttpClient<IPriceProvider, SteamPriceProviders>();

        // Notification
        var telegramToken = config["Telegram: Token"];
        var chatId = config["Telegram : ChatId"];
        if (!string.IsNullOrEmpty(telegramToken) && !string.IsNullOrEmpty(chatId))
        {
            services.AddSingleton<INotificationService>(new TelegramNotificationService(telegramToken, chatId));
        }
        else
        {
            throw new Exception("Telegram token issue");
        }
        var discordWebhook = config["Discord:WebhookUrl"];
        if (!string.IsNullOrEmpty(discordWebhook))
        {
            services.AddSingleton<INotificationService>(new DiscordNotificationService(discordWebhook));
        }
        else
        {
            throw new Exception("Discord token issue");
        }
        return services;
        
    }

}
