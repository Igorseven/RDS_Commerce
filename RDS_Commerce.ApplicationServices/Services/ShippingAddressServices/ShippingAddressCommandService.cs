using RDS_Commerce.ApplicationServices.Dtos.Request.ShippingAddressRequest;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.Business.Interfaces.OthersContracts;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;

namespace RDS_Commerce.ApplicationServices.Services.ShippingAddressServices;
public sealed class ShippingAddressCommandService : BaseService<ShippingAddress>, IShippingAddressCommandService
{
    private readonly IShippingAddressRepository _shippingAddressRepository;

    public ShippingAddressCommandService(INotificationHandler notification,
                                         IValidate<ShippingAddress> validate,
                                         IShippingAddressRepository shippingAddressRepository)
        : base(notification, validate)
    {
        _shippingAddressRepository = shippingAddressRepository;
    }

    public void Dispose() => _shippingAddressRepository.Dispose();

    public Task<bool> CreateShippingAddressAsync(ShippingAddressDtoForRegister shippingAddressDtoForRegister)
    {
        throw new NotImplementedException();
    }


    public Task<bool> UpdateShippingAddressAsync(ShippingAddressDtoForUpdate shippingAddressDtoForUpdate)
    {
        throw new NotImplementedException();
    }
}
