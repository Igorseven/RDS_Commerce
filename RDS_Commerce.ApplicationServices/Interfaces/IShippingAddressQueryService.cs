using RDS_Commerce.ApplicationServices.Dtos.Response.ShippingAddressResponse;
using RDS_Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace RDS_Commerce.ApplicationServices.Interfaces;
public interface IShippingAddressQueryService
{
    Task<ShippingAddress?> FindByDomainObjectAsync(Expression<Func<ShippingAddress, bool>> where, bool asNoTracking = false);
    Task<ShippingAddressDtoForSearchResponse?> FindByIdAsync(int shippingAddressId);
    Task<List<ShippingAddressDtoForSearchResponse>?> FindallAsync(Guid clientId);
}
