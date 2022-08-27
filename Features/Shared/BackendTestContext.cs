using BackendTest.Features.User;
using Microsoft.EntityFrameworkCore;

namespace BackendTest.Features.Shared;

public class BackendTestContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }

    public BackendTestContext(DbContextOptions<BackendTestContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());

        
    }
}
