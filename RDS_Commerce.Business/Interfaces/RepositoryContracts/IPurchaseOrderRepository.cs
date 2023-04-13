using Microsoft.EntityFrameworkCore.Query;
using RDS_Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace RDS_Commerce.Business.Interfaces.RepositoryContracts;
public interface IPurchaseOrderRepository : IDisposable
{
    Task<bool> SaveAsync(PurchaseOrder order);
    Task<bool> UpdateAsync(PurchaseOrder order);
    Task<PurchaseOrder?> FindByPredicateAsync(Expression<Func<PurchaseOrder, bool>> where, Func<IQueryable<PurchaseOrder>, IIncludableQueryable<PurchaseOrder, object>>? include = null, bool asNoTracking = false);
    Task<IEnumerable<PurchaseOrder>?> FindAllAsync(Expression<Func<PurchaseOrder, bool>>? where = null, Func<IQueryable<PurchaseOrder>, IIncludableQueryable<PurchaseOrder, object>>? include = null);
}
