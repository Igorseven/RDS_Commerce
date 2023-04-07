using RDS_Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace RDS_Commerce.Business.Interfaces.RepositoryContracts;
public interface IShippingAddressRepository : IDisposable
{
    Task<bool> SaveAsync(ShippingAddress shippingAddress);
    Task<bool> UpdateAsync(ShippingAddress shippingAddress);
    Task<bool> DeleteAsync(int shippingAddressId);
    Task<ShippingAddress?> FindByIdAsync(int shippingAddressId, bool asNoTracking = false);
    Task<ShippingAddress?> FindByPredicateAsync(Expression<Func<ShippingAddress, bool>> where, bool asNoTracking = false);
    Task<List<ShippingAddress>?> FindAllAsync(Expression<Func<ShippingAddress, bool>> where);
}
