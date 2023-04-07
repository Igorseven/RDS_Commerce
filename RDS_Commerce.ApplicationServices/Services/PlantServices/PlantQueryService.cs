using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.ApplicationServices.Dtos.Response.PlantResponse;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.Business.Handler.PaginationSettings;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace RDS_Commerce.ApplicationServices.Services.PlantServices;
public sealed class PlantQueryService : IPlantQueryService
{
    private readonly IPlantRepository _plantRepository;

    public PlantQueryService(IPlantRepository plantRepository)
    {
        _plantRepository = plantRepository;
    }

    public async Task<PageList<PlantsDtoResponse>>? FindAllWithPaginationAsync(PageParams pageParams)
    {
        var plants = await _plantRepository.FindByWithPaginationAsync(pageParams, i => i.Include(p => p.Images.Where(pi => pi.MainImage)), true)!;

        return plants.MapTo<PageList<Plant>, PageList<PlantsDtoResponse>>();
    }

    public async Task<PlantDtoResponse?> FindByAsync(int plantId)
    {
        var plantAndImages = await _plantRepository.FindByAsync(plantId, i => i.Include(p => p.Images), true);

        return plantAndImages?.MapTo<Plant, PlantDtoResponse>();
    }

    public async Task<Plant?> FindByDomainObjectAsync(Expression<Func<Plant, bool>> where, Func<IQueryable<Plant>, IIncludableQueryable<Plant, object>>? include = null, bool AsNoTracking = false) =>
        await _plantRepository.FindByPredicateAsync(where, include, AsNoTracking);
}
