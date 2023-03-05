using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Infrastructure.ORM.ContextSettings;
using RDS_Commerce.Infrastructure.Repository.Base;
using System.Linq.Expressions;

namespace RDS_Commerce.Infrastructure.Repository;
public sealed class ManagerRepository : BaseRepository<Manager>, IManagerRepository
{
    public ManagerRepository(RdsApplicationDbContext context) 
        : base(context)
    {
    }

    public async Task<bool> ExistInTheDatabaseAsync(Expression<Func<Manager, bool>> where) => await _dbSetContext.AnyAsync(where);

    public async Task<Manager?> FindByIdAsync(Guid managerId, Func<IQueryable<Manager>, IIncludableQueryable<Manager, object>>? include, bool asNoTracking = false)
    {
        IQueryable<Manager> query = _dbSetContext;

        if (asNoTracking)
            query = query.AsNoTracking();

        if (include is not null)
            query = include(query);

        return await query.FirstOrDefaultAsync(m => m.ManagerId == managerId);
    }

    public async Task<Manager?> FindByPredicateAsync(Expression<Func<Manager, bool>> where, Func<IQueryable<Manager>, IIncludableQueryable<Manager, object>>? include, bool asNoTracking = false)
    {
        IQueryable<Manager> query = _dbSetContext;

        if (asNoTracking)
            query = query.AsNoTracking();

        if (include is not null)
            query = include(query);

        return await query.FirstOrDefaultAsync(where);
    }

    public async Task<bool> SaveAsync(Manager manager)
    {
        _dbSetContext.Add(manager);

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> UpdateAsync(Manager manager)
    {
        _dbSetContext.Update(manager);

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> DeleteAsync(Guid managerId)
    {
        var manager = await _dbSetContext.FindAsync(managerId);

        if (manager is null)
            return false;

        if (_context.Entry(manager).State == EntityState.Detached)
            _dbSetContext.Attach(manager);

        _dbSetContext.Remove(manager);

        return await SaveInDatabaseAsync();
    }
}
