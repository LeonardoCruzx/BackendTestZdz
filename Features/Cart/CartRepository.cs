using BackendTest.Features.Item;
using BackendTest.Features.Shared;
using Microsoft.EntityFrameworkCore;

namespace BackendTest.Features.Cart;

public interface ICartRepository : IRepository<CartEntity>
{
    Task<IEnumerable<ItemCartEntity>> GetItemsByIdAsync(int cartId);
    Task<CartEntity> GetCartByUserIdAsync(int userId);
    Task AddItemCartAsync(ItemCartEntity itemCart);
}

public class CartRepository : Repository<CartEntity>, ICartRepository
{
    public CartRepository(DbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ItemCartEntity>> GetItemsByIdAsync(int cartId)
    {
        var cart = await Context.Set<CartEntity>().Include(x => x.Items).ThenInclude(i => i.Item).FirstOrDefaultAsync(x => x.Id == cartId);
        return cart?.Items;
    }

    public async Task<CartEntity> GetCartByUserIdAsync(int userId)
    {
        return await Context.Set<CartEntity>().FirstOrDefaultAsync(x => x.UserId == userId);
    }

    public async Task AddItemCartAsync(ItemCartEntity itemCart)
    {
        await Context.Set<ItemCartEntity>().AddAsync(itemCart);
    }
}
