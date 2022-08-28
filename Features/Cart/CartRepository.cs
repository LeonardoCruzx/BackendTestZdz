using BackendTest.Features.Item;
using BackendTest.Features.Shared;
using Microsoft.EntityFrameworkCore;

namespace BackendTest.Features.Cart;

public interface ICartRepository : IRepository<CartEntity>
{
    Task<IEnumerable<ItemEntity>> GetItemsByIdAsync(int cartId);
    Task<CartEntity> GetCartByUserIdAsync(int userId);
}

public class CartRepository : Repository<CartEntity>, ICartRepository
{
    public CartRepository(DbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ItemEntity>> GetItemsByIdAsync(int cartId)
    {
        var cart = await Context.Set<CartEntity>().Include(x => x.Items).FirstOrDefaultAsync(x => x.Id == cartId);
        return cart?.Items;
    }

    public async Task<CartEntity> GetCartByUserIdAsync(int userId)
    {
        return await Context.Set<CartEntity>().FirstOrDefaultAsync(x => x.UserId == userId);
    }
}
