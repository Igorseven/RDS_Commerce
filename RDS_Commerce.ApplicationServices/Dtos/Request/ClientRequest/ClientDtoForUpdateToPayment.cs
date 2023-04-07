using RDS_Commerce.ApplicationServices.Dtos.Request.ShippingAddressRequest;

namespace RDS_Commerce.ApplicationServices.Dtos.Request.ClientRequest;
public sealed class ClientDtoForUpdateToPayment
{
    public Guid UserId { get; set; }
    public string DocumentNumber { get; init; }

    public ShippingAddressDtoForRegister shippingAddressDtoForRegister { get; set; }
}
