using BackendTest.Features.Item;

namespace BackendTest.Features.Cart;

public class ItemCartEntity
{
    public int Id { get; set; }
    
    public int CartId { get; set; }
    public CartEntity Cart { get; set; }

    public int ItemId { get; set; }
    public ItemEntity Item { get; set; }

    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
