using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RDS_Commerce.Business.Handler.PaginationSettings;
using RDS_Commerce.Business.Interfaces.OthersContracts;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Infrastructure.ORM.ContextSettings;
using RDS_Commerce.Infrastructure.Repository.Base;
using System.Linq.Expressions;

namespace RDS_Commerce.Infrastructure.Repository;
public sealed class PlantRepository : BaseRepository<Plant>,  IPlantRepository
{
    private readonly IPaginationService<Plant> _paginationService;

    public PlantRepository(RdsApplicationDbContext context, IPaginationService<Plant> paginationService)
        : base(context)
    {
        _paginationService = paginationService;
    }

    public async Task<bool> ExistInTheDatabaseAsync(Expression<Func<Plant, bool>> where) => await _dbSetContext.AnyAsync(where);

    public async Task<Plant?> FindByPredicateAsync(Expression<Func<Plant, bool>> where, Func<IQueryable<Plant>, IIncludableQueryable<Plant, object>>? include = null, bool asNoTracking = false)
    {
        IQueryable<Plant> query = _dbSetContext;

        if (asNoTracking)
            query = query.AsNoTracking();

        if (include is not null)
            query = include(query);

        return await query.FirstOrDefaultAsync(where);
    }

    public async Task<Plant?> FindByAsync(int plantId, Func<IQueryable<Plant>, IIncludableQueryable<Plant, object>>? include = null, bool asNoTracking = false)
    {
        IQueryable<Plant> query = _dbSetContext.Include(p => p.Images);

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

        //teste de projeção
        //query.Select(p => new Plant
        //{

        //}).Include(i => i.Images.Select(pi => new PlantImage
        //{
        //    FileName = pi.FileName,
        //    FileExtension = pi.FileExtension,
        //}));

        return _paginationService.CreatePaginationAsync(query, pageParams.PageSize, pageParams.PageNumber);
    }

    public async Task<bool> SaveAsync(Plant plant)
    {
        _dbSetContext.Add(plant);

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> UpdateAsync(Plant plant)
    {
        _dbSetContext.Update(plant);

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> DeleteAsync(int plantId)
    {
        var plant = await _dbSetContext.FindAsync(plantId);

        if (plant is null)
            return false;

        if (_context.Entry(plant).State == EntityState.Detached)
            _dbSetContext.Attach(plant);

        _dbSetContext.Remove(plant);
        return await SaveInDatabaseAsync();
    }
}
