using ATMSimulation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ATMSimulation.Infrastructure.Persistence.Configurations;

public class AccountConfigurations : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(Pk => Pk.Id);
        builder.ToTable("Accounts", schema: "S001");
        builder.HasIndex(ix => ix.AccountNumber).IsUnique();

        builder.HasOne(c => c.Customer)
            .WithMany(a => a.Accounts)
            .HasForeignKey(Fk => Fk.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(a => a.Transactions)
         .WithOne(t => t.Account)
         .HasForeignKey(t => t.AccountId);

        builder.HasOne(c => c.Card)
            .WithOne(a => a.Account);

        builder.Property(prop => prop.IsActive).HasDefaultValue(true);
        builder.Property(prop => prop.Balance).HasColumnType("decimal(18,2)");
        builder.Property(prop => prop.AccountType).IsRequired().HasConversion<string>();

        builder.Ignore(ev => ev.DomainEvents);
    }
}
