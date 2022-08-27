using BackendTest.Features.Item;
using BackendTest.Features.Shared;

namespace BackendTest.Features.Cart;

public interface ICartService
{
    Task<IEnumerable<ItemEntity>> GetItemsAsync(int cartId);
}

public class CartService : ICartService
{
    private IUnitOfWork UnitOfWork { get; set; } 

    public CartService(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ItemEntity>> GetItemsAsync(int cartId)
        => await UnitOfWork.CartRepository.GetItemsAsync(cartId);
    
}

