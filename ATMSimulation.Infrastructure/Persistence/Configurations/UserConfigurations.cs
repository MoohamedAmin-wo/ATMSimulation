using ATMSimulation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ATMSimulation.Infrastructure.Persistence.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("Users", schema: "S001");
        builder.HasKey(Pk => Pk.Id);
        builder.HasOne(C => C.Customer).WithOne(u => u.User);

        builder.HasIndex(ix => ix.UserName).IsUnique();
        builder.HasIndex(ix => ix.Email).IsUnique();
        builder.HasIndex(ix => ix.PhoneNumber).IsUnique();


        builder.Property(prop => prop.Firstname).HasMaxLength(50);
        builder.Property(prop => prop.Lastname).HasMaxLength(150);
        builder.Property(prop => prop.Email).HasMaxLength(250);
        builder.Property(prop => prop.UserName).HasMaxLength(50);
        builder.Property(prop => prop.NormalizedUserName).HasMaxLength(50);

    }
}