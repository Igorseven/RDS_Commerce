using RDS_Commerce.ApplicationServices.Dtos.Request.ShippingAddressRequest;

namespace RDS_Commerce.ApplicationServices.Interfaces;
public interface IShippingAddressCommandService : IDisposable
{
    Task<bool> CreateShippingAddressAsync(ShippingAddressDtoForRegister shippingAddressDtoForRegister);
    Task<bool> UpdateShippingAddressAsync(ShippingAddressDtoForUpdate shippingAddressDtoForUpdate);
}
