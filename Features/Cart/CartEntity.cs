using BackendTest.Features.User.Entities;

namespace BackendTest.Features.Cart;

public class CartEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public UserEntity User { get; set; }
    public ICollection<ItemCartEntity> Items { get; set; }

    public CartEntity()
    {
    }

    public CartEntity(UserEntity user)
    {
        User = user;
    }
}
