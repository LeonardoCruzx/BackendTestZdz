using BackendTest.Features.Cart;
using Microsoft.EntityFrameworkCore;

namespace BackendTest.Features.User;

public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(x => x.Id);

        builder
            .HasOne(u => u.Cart)
            .WithOne(c => c.User)
            .HasForeignKey<UserEntity>(x => x.CartId);
    }
}
