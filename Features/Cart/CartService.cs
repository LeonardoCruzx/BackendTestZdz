using BackendTest.Features.Cart.Resources;
using BackendTest.Features.Item;
using BackendTest.Features.Shared;

namespace BackendTest.Features.Cart;

public interface ICartService
{
    Task<IEnumerable<ItemCartEntity>> GetItemsByIdAsync(int cartId);
    Task AddItemCartAsync(AddItemResource addItemResource);
    void RemoveItemCartAsync(int itemCartId);
}

public class CartService : ICartService
{
    private IUnitOfWork UnitOfWork { get; set; } 

    public CartService(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ItemCartEntity>> GetItemsByIdAsync(int cartId)
        => await UnitOfWork.CartRepository.GetItemsByIdAsync(cartId);

    public async Task AddItemCartAsync(AddItemResource addItemResource)
    {
        var cart = await UnitOfWork.CartRepository.GetByIdAsync(addItemResource.CartId);

        var item = await UnitOfWork.ItemRepository.GetByIdAsync(addItemResource.ItemId);

        var itemCart = new ItemCartEntity
        {
            Cart = cart,
            Item = item,
            Quantity = addItemResource.Quantity,
            Price = item.Price * addItemResource.Quantity
        };

        await UnitOfWork.CartRepository.AddItemCartAsync(itemCart);
    }

    public void RemoveItemCartAsync(int itemCartId)
        => UnitOfWork.CartRepository.RemoveItemCart(itemCartId);
}

