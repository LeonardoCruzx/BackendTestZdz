using BackendTest.Features.Cart;

namespace BackendTest.Features.Item;

public class ItemEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string PictureUri { get; set; }

    public int ItemCategoryId { get; set; }
    public ItemCategoryEntity ItemCategory { get; set; }
}
