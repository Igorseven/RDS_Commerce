using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.ApplicationServices.Dtos.Request.PlantRequest;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.Business.Extensions;
using RDS_Commerce.Business.Handler.NotificationSettings;
using RDS_Commerce.Business.Interfaces.OthersContracts;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.ApplicationServices.Services.PlantServices;
public sealed class PlantCommandService : BaseService<Plant>, IPlantCommandService
{
    private readonly IPlantRepository _plantRepository;
    private readonly IPurchaseOrderQueryService _purchaseOrderQueryService;

    public PlantCommandService(IPlantRepository plantRepository,
                               INotificationHandler notification,
                               IValidate<Plant> validate,
                               IPurchaseOrderQueryService purchaseOrderQueryService)
        : base(notification, validate)
    {
        _plantRepository = plantRepository;
        _purchaseOrderQueryService = purchaseOrderQueryService;
    }

    public void Dispose() => _plantRepository.Dispose();

    public async Task<bool> CreatePlantAsync(PlantDtoForRegister saveRequest)
    {
        if (await _plantRepository.ExistInTheDatabaseAsync(p => p.Name == saveRequest.Name))
            return _notification.CreateNotification("Nome da planta", EMessage.Exist.GetDescription().FormatTo("Planta"));

        var plant = saveRequest.MapTo<PlantDtoForRegister, Plant>();

        SetMainImage(saveRequest.FileImage, plant);

        if (await EntityValidationAsync(plant))
            return await _plantRepository.SaveAsync(plant);

        return false;
    }

    public async Task UpdateStockAsync(int orderId)
    {
        var paidOrder = await _purchaseOrderQueryService.FindByDomainObjectAsync(o => o.Id== orderId,
                                                                                 i => i.Include(p => p.OrderPlants)
                                                                                 .ThenInclude(po => po.Plant), false);

        if (paidOrder is null)
        {
            _notification.CreateNotification(new DomainNotification("Order", EMessage.NotFound.GetDescription().FormatTo("Order")));
            return;
        }

        var plantUpdatStok = new List<Plant>();

        foreach (var orderPlant in paidOrder.OrderPlants)
        {
            var platWithUpdate = orderPlant.Plant;
            platWithUpdate.Quantity -= orderPlant.Quantity;

            plantUpdatStok.Add(platWithUpdate);
        }

        await _plantRepository.UpdateMutipleObjectsAsync(plantUpdatStok);
    }

    public async Task<bool> UpdatePlantAsync(PlantDtoForUpdate updateRequest)
    {
        if (await _plantRepository.ExistInTheDatabaseAsync(p => p.Id != updateRequest.PlantId && p.Name == updateRequest.Name))
            return _notification.CreateNotification("Nome da planta", EMessage.Exist.GetDescription().FormatTo("Planta"));

        var plant = await _plantRepository.FindByAsync(updateRequest.PlantId, i => i.Include(p => p.Images), false);
        if (plant is null)
            return _notification.CreateNotification("Planta não encontrada", EMessage.NotFound.GetDescription().FormatTo("Planta"));

        SetPlantUpdate(plant, updateRequest);

        if (await EntityValidationAsync(plant))
            return await _plantRepository.UpdateAsync(plant);

        return false;
    }

    private static void SetPlantUpdate(Plant plant, PlantDtoForUpdate updateRequest)
    {
        plant.Name = updateRequest.Name;
        plant.Price = updateRequest.Price;
        plant.Quantity = updateRequest.Amount;
        plant.PlantType = updateRequest.PlantType;
        plant.Description = updateRequest.Description;
        plant.VaseSize = updateRequest.VaseSize;
        plant.GenusId = updateRequest.GenusId;
    }

    public async Task<bool> InsertOtherImagesAsync(PlantDtoForUpdateImages updateRequest)
    {
        var plant = await _plantRepository.FindByAsync(updateRequest.PlantId, i => i.Include(p => p.Images), false);
        if (plant is null)
            return _notification.CreateNotification("Planta não encontrada", EMessage.NotFound.GetDescription().FormatTo("Planta"));

        var amountOfImages = plant.Images.Count + updateRequest.FormFileImages.Count;
        const int MAXIMUM_AMOUNT = 7;

        if (amountOfImages > MAXIMUM_AMOUNT)
            return _notification.CreateNotification("Limite de inserção de imagens", EMessage.LimitedValue.GetDescription().FormatTo("7"));

        SetMutipleImages(updateRequest.FormFileImages, plant);

        if (await EntityValidationAsync(plant))
            return await _plantRepository.UpdateAsync(plant);

        return false;
    }

    public async Task<bool> DeleteAsync(int plantId)
    {
        var plant = await _plantRepository.FindByAsync(plantId, i => i.Include(p => p.Images), false);

        if (plant is null)
            return _notification.CreateNotification("Planta não encontrada", EMessage.NotFound.GetDescription().FormatTo("Planta"));

        if (plant.Quantity > 0)
            return _notification.CreateNotification("Planta", "Essa planta não pode ser excluida por tem saldo em estoque.");

        return await _plantRepository.DeleteAsync(plantId);
    }

    private static void SetMutipleImages(List<IFormFile> formFiles, Plant plant)
    {
        foreach (var file in formFiles)
        {
            if (file is not null)
            {
                var newImage = file.BuildPlantFileImage();
                plant.Images.Add(newImage!);
            }
        }
    }

    private static void SetMainImage(IFormFile formFile, Plant plant)
    {
        var mainImage = formFile.BuildPlantFileImage();

        mainImage!.MainImage = true;

        plant.Images = new List<PlantImage>
        {
            { mainImage }
        };
    }

}
