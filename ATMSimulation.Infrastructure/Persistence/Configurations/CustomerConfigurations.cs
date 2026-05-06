using ATMSimulation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ATMSimulation.Infrastructure.Persistence.Configurations;

public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(fk => fk.Id);
        builder.ToTable("Customers" , schema: "S001");
        builder.Property(prop => prop.NationalId).IsRequired().HasMaxLength(14);

        builder.HasOne(c => c.User)
            .WithOne(u => u.Customer)
            .HasForeignKey<Customer>(c => c.UserId);
    }
}