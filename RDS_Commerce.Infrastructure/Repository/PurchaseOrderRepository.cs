using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Infrastructure.ORM.ContextSettings;
using RDS_Commerce.Infrastructure.Repository.Base;
using System.Linq.Expressions;

namespace RDS_Commerce.Infrastructure.Repository;
public sealed class PurchaseOrderRepository : BaseRepository<PurchaseOrder>, IPurchaseOrderRepository
{
    public PurchaseOrderRepository(RdsApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<PurchaseOrder>?> FindAllAsync(Expression<Func<PurchaseOrder, bool>>? where = null, Func<IQueryable<PurchaseOrder>, IIncludableQueryable<PurchaseOrder, object>>? include = null)
    {
        IQueryable<PurchaseOrder> query = _dbSetContext;

        if (where is not null)
            query = query.Where(where);

        if (include is not null)
            query = include(query);

        query = query.OrderByDescending(o => o.Id);

        return await query.AsNoTracking().ToListAsync();
    }

    public async Task<PurchaseOrder?> FindByPredicateAsync(Expression<Func<PurchaseOrder, bool>> where, Func<IQueryable<PurchaseOrder>, IIncludableQueryable<PurchaseOrder, object>>? include = null, bool asNoTracking = false)
    {
        IQueryable<PurchaseOrder> query = _dbSetContext;

        if (asNoTracking)
            query = query.AsNoTracking();

        if (include is not null)
            query = include(query);

        return await query.FirstOrDefaultAsync(where);
    }

    public async Task<bool> SaveAsync(PurchaseOrder order)
    {
        _dbSetContext.Add(order);

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> UpdateAsync(PurchaseOrder order)
    {
        _dbSetContext.Update(order);
        _context.Entry(order).State = EntityState.Modified;

        return await SaveInDatabaseAsync();
    }
}
