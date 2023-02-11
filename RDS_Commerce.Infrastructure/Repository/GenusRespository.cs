using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Infrastructure.ORM.ContextSettings;
using RDS_Commerce.Infrastructure.Repository.Base;
using System.Linq.Expressions;

namespace RDS_Commerce.Infrastructure.Repository;
public sealed class GenusRespository : BaseRepository<Genus>, IGenusRespository
{
    public GenusRespository(RdsApplicationDbContext context) 
        : base(context)
    {
    }

    public async Task<bool> ExistInTheDatabaseAsync(Expression<Func<Genus, bool>> where) => await _dbSetContext.AnyAsync(where);

    public async Task<Genus?> FindByNameAsync(Expression<Func<Genus, bool>> where, bool asNoTracking = false)
    {
        IQueryable<Genus> query = _dbSetContext;

        if (asNoTracking)
            query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync(where);
    }


    public async Task<Genus?> FindByAsync(int genusId, Func<IQueryable<Genus>, IIncludableQueryable<Genus, object>>? include = null, bool asNoTracking = false)
    {
        IQueryable<Genus> query = _dbSetContext;

        if (asNoTracking)
            query = query.AsNoTracking();

        if (include is not null)
            query = include(query);

        return await query.FirstOrDefaultAsync(g => g.Id == genusId);
    }

    public async Task<bool> SaveAsync(Genus genus)
    {
        await _dbSetContext.AddAsync(genus);

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> UpdateAsync(Genus genus)
    {
        _dbSetContext.Update(genus);

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> DeleteAsync(int genusId)
    {
        var genus = await _dbSetContext.FindAsync(genusId);

        if (genus is null)
            return false;

        if (_context.Entry(genus).State == EntityState.Detached)
            _dbSetContext.Attach(genus);

        _dbSetContext.Remove(genus);

        return await SaveInDatabaseAsync();
    }
}
