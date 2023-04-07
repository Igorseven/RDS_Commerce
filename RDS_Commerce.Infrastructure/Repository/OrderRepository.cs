using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Infrastructure.ORM.ContextSettings;
using RDS_Commerce.Infrastructure.Repository.Base;
using System.Linq.Expressions;

namespace RDS_Commerce.Infrastructure.Repository;
public sealed class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(RdsApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Order>?> FindAllAsync(Expression<Func<Order, bool>>? where = null, Func<IQueryable<Order>, IIncludableQueryable<Order, object>>? include = null)
    {
        IQueryable<Order> query = _dbSetContext;

        if (where is not null)
            query = query.Where(where);

        if (include is not null)
            query = include(query);

        query = query.OrderByDescending(o => o.Id);

        return await query.AsNoTracking().ToListAsync();
    }

    public async Task<Order?> FindByPredicateAsync(Expression<Func<Order, bool>> where, Func<IQueryable<Order>, IIncludableQueryable<Order, object>>? include = null, bool asNoTracking = false)
    {
        IQueryable<Order> query = _dbSetContext;

        if (asNoTracking)
            query = query.AsNoTracking();

        if (include is not null)
            query = include(query);

        return await query.FirstOrDefaultAsync(where);
    }

    public async Task<bool> SaveAsync(Order order)
    {
        _dbSetContext.Add(order);

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> UpdateAsync(Order order)
    {
        _dbSetContext.Update(order);
        _context.Entry(order).State = EntityState.Modified;

        return await SaveInDatabaseAsync();
    }
}
