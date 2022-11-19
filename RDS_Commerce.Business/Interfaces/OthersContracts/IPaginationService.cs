using RDS_Commerce.Business.Handler.PaginationSettings;

namespace RDS_Commerce.Business.Interfaces.OthersContracts;
public interface IPaginationService<T> where T : class
{
    Task<PageList<T>> CreatePaginationAsync(IQueryable<T> source, int pageSize, int pageNumber);
}
