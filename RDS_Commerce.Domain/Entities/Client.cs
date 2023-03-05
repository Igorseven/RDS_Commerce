using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.Domain.Entities;
public sealed class Client
{
    public Guid ClientId { get; set; }
    public string FullName { get; set; }
    public string DocumentNumber { get; set; }
    public ERole Role { get; set; }
    public DateTime RegistrationDate { get; set; }


    public string AccountIdentityId { get; set; }
    public AccountIdentity AccountIdentity { get; set; }
    public List<ShippingAddress> ShippingAddresses { get; set; }
    public List<Order> Orders { get; set; }
}
