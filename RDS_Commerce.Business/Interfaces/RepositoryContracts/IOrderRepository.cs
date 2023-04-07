using Microsoft.EntityFrameworkCore.Query;
using RDS_Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace RDS_Commerce.Business.Interfaces.RepositoryContracts;
public interface IOrderRepository : IDisposable
{
    Task<bool> SaveAsync(Order order);
    Task<bool> UpdateAsync(Order order);
    Task<Order?> FindByPredicateAsync(Expression<Func<Order, bool>> where, Func<IQueryable<Order>, IIncludableQueryable<Order, object>>? include = null, bool asNoTracking = false);
    Task<IEnumerable<Order>?> FindAllAsync(Expression<Func<Order, bool>>? where = null, Func<IQueryable<Order>, IIncludableQueryable<Order, object>>? include = null);
}
