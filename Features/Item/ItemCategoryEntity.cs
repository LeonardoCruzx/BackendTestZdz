namespace BackendTest.Features.Item;

public class ItemCategoryEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<ItemEntity> Items { get; set; }
}
