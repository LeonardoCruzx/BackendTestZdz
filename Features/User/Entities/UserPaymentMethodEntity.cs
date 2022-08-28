namespace BackendTest.Features.User.Entities;

public class UserPaymentMethodEntity
{
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }
    public PaymentOption PaymentOption { get; set; }
    
    public int UserId { get; set; }
    public UserEntity User { get; set; }
}
