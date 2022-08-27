using BackendTest.Features.Cart;
using Microsoft.EntityFrameworkCore;

namespace BackendTest.Features.User;

public class CartEntityConfiguration : IEntityTypeConfiguration<CartEntity>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CartEntity> builder)
    {
        builder.ToTable("Carts");

        builder.HasKey(x => x.Id);

        builder
            .HasOne(c => c.User)
            .WithOne(u => u.Cart)
            .HasForeignKey<CartEntity>(x => x.UserId);

        builder
            .HasMany(c => c.Items)
            .WithOne(i => i.Cart);
    }
}
