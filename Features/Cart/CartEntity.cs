using BackendTest.Features.Item;
using BackendTest.Features.User;

namespace BackendTest.Features.Cart;

public class CartEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public UserEntity User { get; set; }
    public ICollection<ItemEntity> Items { get; set; }
}
