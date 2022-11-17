using Microsoft.EntityFrameworkCore.Query;
using RDS_Commerce.Business.Handler.PaginationSettings;
using RDS_Commerce.Domain.Entities;

namespace RDS_Commerce.Business.Interfaces.RepositoryContracts;
public interface IPlantRepository
{
    Task<bool> SaveAsync(Plant entity);
    Task<bool> UpdateAsync(Plant entity);
    Task<bool> DeleteAsync(int plantId);

    Task<Plant?> FindByAsync(int plantId, Func<IQueryable<Plant>, IIncludableQueryable<Plant, object>>? include = null, bool asNoTracking = false);
    Task<PageList<Plant>>? FindByWithPaginationAsync(int plantId, Func<IQueryable<Plant>, IIncludableQueryable<Plant, object>>? include = null, bool asNoTracking = false);
}
