using Microsoft.EntityFrameworkCore.Query;
using RDS_Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace RDS_Commerce.Business.Interfaces.RepositoryContracts;
public interface IOrderPlantRepository : IDisposable
{
    Task<bool> SaveAsync(OrderPlant orderPlant);
    Task<bool> UpdateAsync(OrderPlant orderPlant);
    Task<bool> DeleteAsync(int orderPlantId);
    Task<OrderPlant?> FindByPredicateAsync(Expression<Func<OrderPlant, bool>> where, Func<IQueryable<OrderPlant>, IIncludableQueryable<OrderPlant, object>>? include = null, bool asNoTracking = false);
}
