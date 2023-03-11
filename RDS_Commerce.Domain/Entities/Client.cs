using RDS_Commerce.Domain.Entities.Base;

namespace RDS_Commerce.Domain.Entities;
public sealed class Client : User
{
    public string DocumentNumber { get; set; }
    public bool AcceptTermsAndPolicy { get; init; }
    public DateTime AcceptanceOfTermsAndPolicies { get; set; }

    //criar fk para table de terms and policy
    public List<ShippingAddress> ShippingAddresses { get; set; }
    public List<Order> Orders { get; set; }
}
