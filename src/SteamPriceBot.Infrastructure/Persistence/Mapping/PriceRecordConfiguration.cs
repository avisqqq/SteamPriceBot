using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SteamPriceBot.Domain.Entities;

namespace SteamPriceBot.Infrastructure.Persistence.Mapping;

public class PriceRecordConfiguration : IEntityTypeConfiguration<PriceRecord>
{
    public void Configure(EntityTypeBuilder<PriceRecord> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.TimestampUtc).IsRequired();

        builder.OwnsOne(x => x.Price, b =>
        {
            b.Property(i => i.Amount)
                .HasColumnName("Amount")
                .IsRequired();
            b.OwnsOne(i => i.Currency, c =>
            {
                c.Property(code => code.Code)
                    .HasColumnName("CurrencyCode")
                    .HasDefaultValue("USD")
                    .IsRequired();
            });
        });
        builder.Property(x => x.TrackedItemId).IsRequired();
    }
}
