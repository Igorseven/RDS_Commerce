using Microsoft.EntityFrameworkCore;
using RDS_Commerce.Business.Handler.PaginationSettings;
using RDS_Commerce.Business.Interfaces.OthersContracts;

namespace RDS_Commerce.Infrastructure.Services;
public sealed class PaginationService<T> : IPaginationService<T> where T : class
{
    public async Task<PageList<T>> CreatePaginationAsync(IQueryable<T> source, int pageSize, int pageNumber)
    {
        var count = await source.CountAsync();
        var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PageList<T>(items, count, pageNumber, pageSize);
    }
}
