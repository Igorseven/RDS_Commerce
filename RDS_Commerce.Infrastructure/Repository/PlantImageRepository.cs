using Microsoft.EntityFrameworkCore;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Infrastructure.ORM.ContextSettings;
using RDS_Commerce.Infrastructure.Repository.Base;
using System.Linq.Expressions;

namespace RDS_Commerce.Infrastructure.Repository;
public sealed class PlantImageRepository : BaseRepository<PlantImage>, IPlantImageRepository
{
    public PlantImageRepository(RdsApplicationDbContext context) 
        : base(context)
    {
    }

    public async Task<PlantImage?> FindByPredicateAsync(Expression<Func<PlantImage, bool>> where, bool withBytes = true, bool asNoTracking = false)
    {
        IQueryable<PlantImage> query = _dbSetContext;

        if (asNoTracking)
            query = query.AsNoTracking();

        if (!withBytes)
        {
            query = query.Select(pi => new PlantImage
            {
                Id = pi.Id,
                FileExtension = pi.FileExtension,
                FileName = pi.FileName,
                MainImage = pi.MainImage,
                PlantId = pi.PlantId,
                RegistrationDate = pi.RegistrationDate
            });
        }

        return await query.FirstOrDefaultAsync(where);
    }

    public async Task<PlantImage?> FindByAsync(int plantImageId, bool withBytes = true, bool asNoTracking = false)
    {
        IQueryable<PlantImage> query = _dbSetContext;

        if (asNoTracking)
            query = query.AsNoTracking();

        if (!withBytes)
        {
            query = query.Select(pi => new PlantImage
            {
                Id = pi.Id,
                FileExtension = pi.FileExtension,
                FileName = pi.FileName,
                MainImage = pi.MainImage,
                PlantId = pi.PlantId,
                RegistrationDate = pi.RegistrationDate
            });
        }

        return await query.FirstOrDefaultAsync(pi => pi.Id == plantImageId);
    }

    public async Task<bool> UpdateImageSeveralplantsAsync(List<PlantImage> plants)
    {
        _dbSetContext.UpdateRange(plants);

        return await SaveInDatabaseAsync();
    }
}
