using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RDS_Commerce.Business.Handler.PaginationSettings;
using RDS_Commerce.Business.Interfaces.OthersContracts;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Infrastructure.ORM.Context;
using RDS_Commerce.Infrastructure.Repository.Base;
using System.Linq.Expressions;

namespace RDS_Commerce.Infrastructure.Repository;
public sealed class PlantRepository : BaseRepository<Plant>,  IPlantRepository
{
    private readonly IPaginationService<Plant> _paginationService;

    public PlantRepository(RdsContext context, IPaginationService<Plant> paginationService)
        : base(context)
    {
        _paginationService = paginationService;
    }

    public async Task<bool> ExistInTheDatabaseAsync(Expression<Func<Plant, bool>> where) => await _dbSetContext.AnyAsync(where);

    public async Task<Plant?> FindByPredicateAsync(Expression<Func<Plant, bool>> where) => await _dbSetContext.FirstOrDefaultAsync(where);

    public async Task<Plant?> FindByAsync(int plantId, Func<IQueryable<Plant>, IIncludableQueryable<Plant, object>>? include = null, bool asNoTracking = false)
    {
        IQueryable<Plant> query = _dbSetContext;

        if (asNoTracking)
            query = query.AsNoTracking();

        if (include is not null)
            query = include(query);

        return await query.FirstOrDefaultAsync(p => p.Id == plantId);
    }

    public Task<PageList<Plant>>? FindByWithPaginationAsync(PageParams pageParams, Func<IQueryable<Plant>, IIncludableQueryable<Plant, object>>? include = null, bool asNoTracking = false)
    {
        IQueryable<Plant> query = _dbSetContext;

        if (asNoTracking)
            query = query.AsNoTracking();

        if (include is not null)
            query = include(query);

        return _paginationService.CreatePaginationAsync(query, pageParams.PageSize, pageParams.PageNumber);
    }

    public async Task<bool> SaveAsync(Plant entity)
    {
        _dbSetContext.Add(entity);
        _context.Entry(entity).State = EntityState.Added;
        return await PersistInTheDatabaseAsync();
    }

    public async Task<bool> UpdateAsync(Plant entity)
    {
        _dbSetContext.Update(entity);
        _context.Entry(entity).State = EntityState.Modified;
        return await PersistInTheDatabaseAsync();
    }

    public async Task<bool> DeleteAsync(int plantId)
    {
        var entity = await _dbSetContext.FindAsync(plantId);
        if (entity is null)
            return false;

        if (_context.Entry(entity).State == EntityState.Detached)
            _dbSetContext.Attach(entity);

        _dbSetContext.Remove(entity);
        return await PersistInTheDatabaseAsync();
    }
}
