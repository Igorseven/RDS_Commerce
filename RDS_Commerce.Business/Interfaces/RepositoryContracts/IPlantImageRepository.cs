using RDS_Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace RDS_Commerce.Business.Interfaces.RepositoryContracts;
public interface IPlantImageRepository : IDisposable
{
    Task<bool> UpdateImageSeveralplantsAsync(List<PlantImage> plants);
    Task<PlantImage?> FindByAsync(int plantImageId, bool withBytes = true, bool asNoTracking = false);
    Task<PlantImage?> FindByPredicateAsync(Expression<Func<PlantImage, bool>> where, bool withBytes = true, bool asNoTracking = false);
}
