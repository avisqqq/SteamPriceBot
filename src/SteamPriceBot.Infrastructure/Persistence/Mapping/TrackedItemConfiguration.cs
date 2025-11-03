using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SteamPriceBot.Domain.Entities;
using SteamPriceBot.Domain.ValueObjects;

namespace SteamPriceBot.Infrastructure.Persistence.Mapping;

public class TrackedItemConfiguration : IEntityTypeConfiguration<TrackedItem>
{
    public void Configure(EntityTypeBuilder<TrackedItem> builder)
    {
        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.Threshold, b =>
        {
            b.Property(i => i.Amount).HasColumnName("ThresholdAmount");

        });
        builder.HasOne(x => x.Item)
            .WithMany()
            .HasForeignKey("MarketItemId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
