﻿using Microsoft.EntityFrameworkCore;
using RDS_Commerce.Infrastructure.ORM.ContextSettings;

namespace RDS_Commerce.Infrastructure.Repository.Base;
public abstract class BaseRepository<T> : IDisposable where T : class
{
	protected readonly RdsApplicationDbContext _context;
	protected DbSet<T> _dbSetContext => _context.Set<T>();

    public BaseRepository(RdsApplicationDbContext context)
	{
		_context= context;
	}

	protected async Task<bool> SaveInDatabaseAsync() => await _context.SaveChangesAsync() > 0;

    protected void DetachedObject(T entity)
    {
        if (_context.Entry(entity).State == EntityState.Detached)
            _dbSetContext.Attach(entity);
    }

    public void Dispose() => _context.Dispose();
}
