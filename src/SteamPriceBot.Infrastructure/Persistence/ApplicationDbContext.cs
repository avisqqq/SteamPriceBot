using System;
using SteamPriceBot.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace SteamPriceBot.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public DbSet<MarketItem> MarketItems => Set<MarketItem>();
    public DbSet<TrackedItem> TrackedItems => Set<TrackedItem>();
    public DbSet<PriceRecord> PriceRecords => Set<PriceRecord>();
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
