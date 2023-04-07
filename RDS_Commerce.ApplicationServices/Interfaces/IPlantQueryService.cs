using Microsoft.EntityFrameworkCore.Query;
using RDS_Commerce.ApplicationServices.Dtos.Response.PlantResponse;
using RDS_Commerce.Business.Handler.PaginationSettings;
using RDS_Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace RDS_Commerce.ApplicationServices.Interfaces;
public interface IPlantQueryService
{
    Task<PlantDtoResponse?> FindByAsync(int plantId);
    Task<PageList<PlantsDtoResponse>>? FindAllWithPaginationAsync(PageParams pageParams);
    Task<Plant?> FindByDomainObjectAsync(Expression<Func<Plant, bool>> where,
                                         Func<IQueryable<Plant>, IIncludableQueryable<Plant, object>>? include = null,
                                         bool AsNoTracking = false);
}
