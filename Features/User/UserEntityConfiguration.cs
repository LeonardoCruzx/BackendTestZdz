using BackendTest.Features.Cart;
using BackendTest.Features.User.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendTest.Features.User;

public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(x => x.Id);

        builder
            .HasOne(u => u.Cart)
            .WithOne(c => c.User)
            .HasForeignKey<CartEntity>(c => c.UserId);

        builder
            .HasMany(u => u.Addresses)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId);

        builder
            .HasMany(u => u.PaymentMethods)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
    }
}
