using RDS_Commerce.Domain.Entities.Base;

namespace RDS_Commerce.Domain.Entities;
public sealed class Client : User
{
    public string DocumentNumber { get; set; }

    public List<ShippingAddress> ShippingAddresses { get; set; }
    public List<Order> Orders { get; set; }
}
