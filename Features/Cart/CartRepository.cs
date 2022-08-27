using BackendTest.Features.Item;
using BackendTest.Features.Shared;
using Microsoft.EntityFrameworkCore;

namespace BackendTest.Features.Cart;

public interface ICartRepository : IRepository<CartEntity>
{
    Task<IEnumerable<ItemEntity>> GetItemsAsync(int cartId);
}

public class CartRepository : Repository<CartEntity>, ICartRepository
{
    public CartRepository(DbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ItemEntity>> GetItemsAsync(int cartId)
    {
        var cart = await Context.Set<CartEntity>().Include(x => x.Items).FirstOrDefaultAsync(x => x.Id == cartId);
        return cart?.Items;
    }
}
