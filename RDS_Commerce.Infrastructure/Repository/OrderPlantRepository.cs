using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Infrastructure.ORM.ContextSettings;
using RDS_Commerce.Infrastructure.Repository.Base;
using System.Linq.Expressions;

namespace RDS_Commerce.Infrastructure.Repository;
public sealed class OrderPlantRepository : BaseRepository<OrderPlant>, IOrderPlantRepository
{
    public OrderPlantRepository(RdsApplicationDbContext context) : base(context)
    {
    }

    public async Task<OrderPlant?> FindByPredicateAsync(Expression<Func<OrderPlant, bool>> where, Func<IQueryable<OrderPlant>, IIncludableQueryable<OrderPlant, object>>? include = null, bool asNoTracking = false)
    {
        IQueryable<OrderPlant> query = _dbSetContext;

        if (asNoTracking)
            query = query.AsNoTracking();

        if (include is not null)
            query = include(query);

        return await query.FirstOrDefaultAsync(where);
    }

    public async Task<bool> SaveAsync(OrderPlant orderPlant)
    {
        _dbSetContext.Add(orderPlant);

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> UpdateAsync(OrderPlant orderPlant)
    {
        _dbSetContext.Update(orderPlant);
        _context.Entry(orderPlant).State = EntityState.Modified;

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> DeleteAsync(int orderPlantId)
    {
        var orderPlat = await _dbSetContext.FindAsync(orderPlantId);

        if (orderPlat is null) return false;

        DetachedObject(orderPlat);

        _dbSetContext.Remove(orderPlat);

        return await SaveInDatabaseAsync();
    }
}
