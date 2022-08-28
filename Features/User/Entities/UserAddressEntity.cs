namespace BackendTest.Features.User.Entities;

public class UserAddressEntity
{
    public int Id { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string Complement { get; set; }

    public int UserId { get; set; }
    public UserEntity User { get; set; }
}
