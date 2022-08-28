using BackendTest.Features.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendTest.Features.Cart;

public class CartEntityConfiguration : IEntityTypeConfiguration<CartEntity>
{
    public void Configure(EntityTypeBuilder<CartEntity> builder)
    {
        builder.ToTable("Carts");

        builder.HasKey(x => x.Id);

        builder
            .HasMany(c => c.Items)
            .WithOne(i => i.Cart);
    }
}
