using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SteamPriceBot.Domain.Entities;

namespace SteamPriceBot.Infrastructure.Persistence.Mapping;

public class MarketItemConfiguration : IEntityTypeConfiguration<MarketItem>
{
    public void Configure(EntityTypeBuilder<MarketItem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.OwnsOne(x => x.ItemId, b =>
        {
            b.Property(i => i.AppId).HasColumnName("AppId");
            b.Property(i => i.MarketHashName).HasColumnName("MarketHashName");
        });
        builder.Property(x => x.DisplayName).IsRequired();
    }
}
