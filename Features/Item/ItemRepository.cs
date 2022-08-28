using BackendTest.Features.Shared;
using Microsoft.EntityFrameworkCore;

namespace BackendTest.Features.Item;

public interface IItemRepository : IRepository<ItemEntity>
{
    
}

public class ItemRepository : Repository<ItemEntity>, IItemRepository
{
    public ItemRepository(DbContext context) : base(context)
    {
    }
}
