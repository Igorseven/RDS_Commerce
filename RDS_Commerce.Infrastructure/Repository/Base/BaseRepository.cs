using Microsoft.EntityFrameworkCore;
using RDS_Commerce.Infrastructure.ORM.Context;

namespace RDS_Commerce.Infrastructure.Repository.Base;
public abstract class BaseRepository<T> : IDisposable where T : class
{
	protected RdsContext _context;
	protected DbSet<T> _dbSetContext => _context.Set<T>();

    public BaseRepository(RdsContext context)
	{
		_context= context;
	}

	protected async Task<bool> PersistInTheDatabaseAsync() => await _context.SaveChangesAsync() > 0;

    public void Dispose() => _context.Dispose();
}
