using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SteamPriceBot.Application.Services;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace SteamPriceBot.TelegramWorker;

public class TelegramWorkerService : BackgroundService
{
    private readonly ILogger<TelegramWorkerService> _logger;
    private readonly IServiceProvider _service;
    private readonly string? _token;

    public TelegramWorkerService(ILogger<TelegramWorkerService> logger, IConfiguration config, IServiceProvider service)
    {
        _logger = logger;
        _service = service;
        _token = config["Telegram:Token"];
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (!string.IsNullOrEmpty(_token))
        {
            _logger.LogWarning("Telegram token missing");
            var bot = new TelegramBotClient(_token!);
            var me = await bot.GetMe(stoppingToken);

            _logger.LogInformation($"Telegram bot connected as @{me.Username}");
            bot.StartReceiving(HandleUpdate, HandleError, cancellationToken: stoppingToken);
            await Task.Delay(-1, stoppingToken);
        }
    }
    private async Task HandleUpdate(ITelegramBotClient bot, Update update, CancellationToken ct)
    {
        using var scope = _service.CreateScope();
        var _tracker = scope.ServiceProvider.GetRequiredService<PriceTrackingService>();
        if (update.Type != UpdateType.Message || update.Message?.Text is null) return;
        var text = update.Message.Text.Trim().ToLowerInvariant();
        var chatId = update.Message.Chat.Id;
        switch (text)
        {
            case "/start":
                await bot.SendMessage(chatId, "Welcome! Use /refresh to update prices.", cancellationToken: ct);
                break;
            case "/refresh":
                await bot.SendMessage(chatId, "Refreshing prices...", cancellationToken: ct);
                await _tracker.RefreshPricesAsync(ct);
                await bot.SendMessage(chatId, "Done", cancellationToken: ct);
                break;
            default:
                await bot.SendMessage(chatId, "Commands: /start /refresh", cancellationToken: ct);
                break;
        }
    }
    private Task HandleError(ITelegramBotClient bot, Exception ex, CancellationToken ct)
    {
        _logger.LogError(ex, "Telegram error");
        return Task.CompletedTask;
    }
}
