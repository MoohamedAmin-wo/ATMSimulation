using ATMSimulation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ATMSimulation.Infrastructure.Persistence.Configurations;

public class TrasnactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(fk => fk.Id);
        builder.ToTable("Transactions" , schema : "S001");

        builder.Property(prop => prop.Amount).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(prop => prop.TransactionType).IsRequired().HasConversion<string>();
        builder.Property(prop => prop.TransactionDate).IsRequired();
        builder.Property(prop => prop.Description).HasMaxLength(500);
        builder.Property(prop => prop.ToAccountNumber).HasMaxLength(20);
    }
}
