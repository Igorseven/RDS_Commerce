using RDS_Commerce.Business.Handler.PaginationSettings;
using RDS_Commerce.Business.Interfaces.OthersContracts;

namespace RDS_Commerce.Infrastructure.Services;
public sealed class PaginationService<T> : IPaginationService<T> where T : class
{
    public Task<PageList<T>> CreatePaginationAsync(IQueryable<T> entity, int pageSize, int pageNumber)
    {
        throw new NotImplementedException();
    }
}
