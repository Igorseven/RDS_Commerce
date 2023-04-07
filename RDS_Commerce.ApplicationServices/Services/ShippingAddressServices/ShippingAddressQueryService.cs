using Microsoft.EntityFrameworkCore.Query;
using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.ApplicationServices.Dtos.Response.ShippingAddressResponse;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace RDS_Commerce.ApplicationServices.Services.ShippingAddressServices;
public sealed class ShippingAddressQueryService : IShippingAddressQueryService
{
    private readonly IShippingAddressRepository _shippingAddressRepository;

    public ShippingAddressQueryService(IShippingAddressRepository shippingAddressRepository)
    {
        _shippingAddressRepository = shippingAddressRepository;
    }

    public async Task<List<ShippingAddressDtoForSearchResponse>?> FindallAsync(Guid clientId)
    {
        var addresses = await _shippingAddressRepository.FindAllAsync(sa => sa.ClientId == clientId);

        return addresses?.MapTo<List<ShippingAddress>, List<ShippingAddressDtoForSearchResponse>>();
    }

    public async Task<ShippingAddress?> FindByDomainObjectAsync(Expression<Func<ShippingAddress, bool>> where, bool asNoTracking = false) =>
        await _shippingAddressRepository.FindByPredicateAsync(where, asNoTracking);

    public async Task<ShippingAddressDtoForSearchResponse?> FindByIdAsync(int shippingAddressId)
    {
        var address = await _shippingAddressRepository.FindByIdAsync(shippingAddressId);

        return address?.MapTo<ShippingAddress, ShippingAddressDtoForSearchResponse>();
    }
}
