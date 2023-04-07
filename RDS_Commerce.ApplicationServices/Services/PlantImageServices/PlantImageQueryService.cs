using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.ApplicationServices.Dtos.Response.PlantImageResponse;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;

namespace RDS_Commerce.ApplicationServices.Services.PlantImageServices;
public sealed class PlantImageQueryService : IPlantImageQueryService
{
    private readonly IPlantImageRepository _plantImageRepository;

    public PlantImageQueryService(IPlantImageRepository plantImageRepository)
    {
        _plantImageRepository = plantImageRepository;
    }

    public async Task<PlantImageDtoResponse?> FindByAsync(int plantImageId)
    {
        var plantImage = await _plantImageRepository.FindByAsync(plantImageId, true, true);

        return plantImage?.MapTo<PlantImage, PlantImageDtoResponse>();
    }
}
