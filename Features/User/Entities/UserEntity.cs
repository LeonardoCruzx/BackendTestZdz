using BackendTest.Features.Cart;

namespace BackendTest.Features.User.Entities;

public class UserEntity
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }

    public CartEntity Cart { get; set; }

    public ICollection<UserAddressEntity> Addresses { get; set; }
    public ICollection<UserPaymentMethodEntity> PaymentMethods { get; set; }
}
