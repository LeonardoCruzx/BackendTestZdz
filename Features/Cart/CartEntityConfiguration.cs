using BackendTest.Features.User;
using Microsoft.EntityFrameworkCore;

namespace BackendTest.Features.Cart;

public class CartEntityConfiguration : IEntityTypeConfiguration<CartEntity>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CartEntity> builder)
    {
        builder.ToTable("Carts");

        builder.HasKey(x => x.Id);

        builder
            .HasMany(c => c.Items)
            .WithOne(i => i.Cart);
    }
}
