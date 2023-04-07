using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.ApplicationServices.Dtos.Request.PlantRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.PlantImageResponse;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.Business.Extensions;
using RDS_Commerce.Business.Interfaces.OthersContracts;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.ApplicationServices.Services.PlantImageServices;
public sealed class PlantImageCommandService : BaseService<PlantImage>, IPlantImageCommandService
{
    private readonly IPlantImageRepository _plantImageRepository;

    public PlantImageCommandService(INotificationHandler notification,
                             IValidate<PlantImage> validate,
                             IPlantImageRepository plantImageRepository
                             )
        : base(notification, validate)
    {
        _plantImageRepository = plantImageRepository;
    }

    public void Dispose() => _plantImageRepository.Dispose();



    public async Task<bool> UpdateMainImageAsync(PlantDtoForUpdateMainImage updateRequest)
    {
        var currentMainImage = await _plantImageRepository.FindByPredicateAsync(pi => pi.PlantId == updateRequest.PlantId && pi.MainImage, false, false);

        if (currentMainImage is null)
            return _notification.CreateNotification("Imagem", EMessage.NotFound.GetDescription().FormatTo($"Imagem principal"));

        var newMainImage = await _plantImageRepository.FindByAsync(updateRequest.PlantImageId, false, false);

        if (newMainImage is null)
            return _notification.CreateNotification("Imagem", EMessage.NotFound.GetDescription().FormatTo($"Imagem {updateRequest.PlantImageId}"));

        newMainImage.MainImage = true;
        currentMainImage.MainImage = false;

        var images = new List<PlantImage>()
        {
            currentMainImage,
            newMainImage
        };

        return await _plantImageRepository.UpdateImageSeveralplantsAsync(images);
    }
}
