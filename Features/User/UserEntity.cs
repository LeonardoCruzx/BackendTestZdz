using BackendTest.Features.Cart;

namespace BackendTest.Features.User;

public class UserEntity
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }

    public int CartId { get; set; }
    public CartEntity Cart { get; set; }
}
