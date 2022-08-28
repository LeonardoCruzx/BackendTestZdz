using BackendTest.Features.Cart;
using BackendTest.Features.Item;
using BackendTest.Features.User;
using BackendTest.Features.User.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendTest.Features.Shared;

public class BackendTestContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<CartEntity> Carts { get; set; }
    public DbSet<ItemEntity> Items { get; set; }
    public DbSet<ItemCartEntity> CartItems { get; set; }

    public BackendTestContext(DbContextOptions<BackendTestContext> options) : base(options)
    {
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        
        modelBuilder.ApplyConfiguration(new CartEntityConfiguration());

        modelBuilder.ApplyConfiguration(new ItemEntityConfiguration());
    }
}
