using ATMSimulation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ATMSimulation.Infrastructure.Persistence.Configurations;

public class CardConfiguration : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.HasKey(pk => pk.Id);
        builder.HasIndex(ix => ix.CardNumber).IsUnique();
        builder.ToTable("Cards", schema: "S001");


        builder.Property(prop => prop.ExpirationDate).IsRequired();
        builder.Property(prop => prop.CardType).IsRequired().HasConversion<string>();
        builder.Property(prop => prop.IsActive).HasDefaultValue(true);
        builder.Property(prop => prop.IsFirstUseForCard).HasDefaultValue(true);
        builder.Property(prop => prop.ReachLimitPerDay).HasDefaultValue(false);
        builder.Property(prop => prop.CurrentLimitPerDay).HasDefaultValue(25000m); ;

    }
}
