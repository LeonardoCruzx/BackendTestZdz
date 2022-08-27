using Microsoft.EntityFrameworkCore;

namespace BackendTest.Features.User;

public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserEntity> builder)
    {
        
    }
}
