using Microsoft.EntityFrameworkCore.Query;
using RDS_Commerce.Business.Handler.PaginationSettings;
using RDS_Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace RDS_Commerce.Business.Interfaces.RepositoryContracts;
public interface IPlantRepository : IDisposable
{
    Task<bool> SaveAsync(Plant entity);
    Task<bool> UpdateAsync(Plant entity);
    Task<bool> DeleteAsync(int plantId);

    Task<bool> ExistInTheDatabaseAsync(Expression<Func<Plant, bool>> where);
    Task<Plant?> FindByPredicateAsync(Expression<Func<Plant, bool>> where, Func<IQueryable<Plant>, IIncludableQueryable<Plant, object>>? include = null, bool asNoTracking = false);
    Task<List<Plant>?> FindAllAsync(Expression<Func<Plant, bool>> where, Func<IQueryable<Plant>, IIncludableQueryable<Plant, object>>? include = null);
    Task<Plant?> FindByAsync(int plantId, Func<IQueryable<Plant>, IIncludableQueryable<Plant, object>>? include = null, bool asNoTracking = false);
    Task<PageList<Plant>>? FindByWithPaginationAsync(PageParams pageParams, Func<IQueryable<Plant>, IIncludableQueryable<Plant, object>>? include = null, bool asNoTracking = false);
}
