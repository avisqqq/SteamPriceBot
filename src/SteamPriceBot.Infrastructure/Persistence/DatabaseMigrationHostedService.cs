using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SteamPriceBot.Infrastructure.Persistence;
/// <summary>
/// Ensure all EF Core migration are applied automatically at startup
/// Safe for dev/local environments
/// </summary>
public class DatabaseMigrationHostedService : IHostedService
{
    private readonly ILogger<DatabaseMigrationHostedService> _logger;
    private readonly IServiceProvider _services;

    public DatabaseMigrationHostedService(IServiceProvider services, ILogger<DatabaseMigrationHostedService> logger)
    {
        _logger = logger;
        _services = services;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        try
        {
            using var scope = _services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            _logger.LogInformation("Applying pending migrations...");
            await db.Database.MigrateAsync(cancellationToken);
            _logger.LogInformation("Migrations applied.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while migrating the database.");
        }
    }
    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}