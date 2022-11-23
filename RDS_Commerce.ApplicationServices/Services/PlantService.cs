using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.ApplicationServices.Dtos.Request.PlantRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.PlantResponse;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.ApplicationServices.Services.Base;
using RDS_Commerce.Business.Extensions;
using RDS_Commerce.Business.Handler.PaginationSettings;
using RDS_Commerce.Business.Handler.ValidationSettings;
using RDS_Commerce.Business.Interfaces.OthersContracts;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS_Commerce.ApplicationServices.Services;
public sealed class PlantService : BaseService<Plant>, IPlantService
{
    private readonly IPlantRepository _plantRepository;

    public PlantService(IPlantRepository plantRepository,
                        INotificationHandler notification,
                        IValidate<Plant> validate
                        )
        : base(notification, validate)
    {
        _plantRepository = plantRepository;
    }

    public async Task<PageList<PlantFindWithPaginationResponse>>? FindAllAsync(PageParams pageParams)
    {
        var plants = await _plantRepository.FindByWithPaginationAsync(pageParams, i => i.Include(p => p.Images), true)!;

        return plants.MapTo<PageList<Plant>, PageList<PlantFindWithPaginationResponse>>();
    }

    public async Task<PlantFindByResponse?> FindByAsync(int plantId)
    {
        var plantAndImages = await _plantRepository.FindByAsync(plantId, i => i.Include(p => p.Images), true);

        return plantAndImages?.MapTo<Plant, PlantFindByResponse>();
    }

    public async Task<bool> SaveAsync(PlantSaveRequest saveRequest)
    {
        if (await _plantRepository.ExistInTheDatabaseAsync(p => p.Name == saveRequest.Name))
            return _notification.CreateNotification("Nome da planta", EMessage.Exist.GetDescription().FormatTo("Planta"));

        var plant = saveRequest.MapTo<PlantSaveRequest, Plant>();

        SetMainImage(saveRequest.FileImage, plant);

        if (!await EntityValidationAsync(plant))
            return await _plantRepository.SaveAsync(plant);
        else
            return false;
    }

    public async Task<bool> UpdateAsync(PlantUpdateRequest updateRequest)
    {
        if (await _plantRepository.ExistInTheDatabaseAsync(p => p.Id != updateRequest.PlantId && p.Name == updateRequest.Name))
            return _notification.CreateNotification("Nome da planta", EMessage.Exist.GetDescription().FormatTo("Planta"));

        var plant = await _plantRepository.FindByAsync(updateRequest.PlantId, i => i.Include(p => p.Images), false);
        if (plant is null)
            return _notification.CreateNotification("Planta não encontrada", EMessage.NotFound.GetDescription().FormatTo("Planta"));

        var plantUpdate = updateRequest.MapTo(plant);

        if (!await EntityValidationAsync(plant))
            return await _plantRepository.UpdateAsync(plant);
        else
            return false;
    }

    public async Task<bool> UpdateImagesAsync(PlantUpdateImagesRequest updateRequest)
    {
        var plant = await _plantRepository.FindByAsync(updateRequest.PlantId, i => i.Include(p => p.Images), false);
        if (plant is null)
            return _notification.CreateNotification("Planta não encontrada", EMessage.NotFound.GetDescription().FormatTo("Planta"));

        SetMutipleImages(updateRequest.FormFileImages, plant);

        if (!await EntityValidationAsync(plant))
            return await _plantRepository.UpdateAsync(plant);
        else
            return false;
    }

    public async Task<bool> UpdateMainImageAsync(PlantUpdateMainImageRequest updateRequest)
    {
        var plant = await _plantRepository.FindByAsync(updateRequest.PlantId, i => i.Include(p => p.Images), false);
        if (plant is null)
            return _notification.CreateNotification("Planta não encontrada", EMessage.NotFound.GetDescription().FormatTo("Planta"));

        var oldPlant = plant.Images.Find(p => p.MainImage);
        var newPlant = plant.Images.Find(p => p.Id == updateRequest.PlantId);

        if (oldPlant is not null && newPlant is not null)
        {
            oldPlant.MainImage = false;
            newPlant.MainImage = true;
            List<PlantImage> images = new()
            {
                { oldPlant },
                { newPlant }
            };

            plant.Images.AddRange(images);

            return await _plantRepository.UpdateAsync(plant);
        }
        else
            return _notification.CreateNotification("Planta não encontrada", EMessage.NotFound.GetDescription().FormatTo("Planta"));
    }

    public async Task<bool> DeleteAsync(int plantId)
    {
        if (!await _plantRepository.ExistInTheDatabaseAsync(p => p.Id == plantId))
            return _notification.CreateNotification("Planta não encontrada", EMessage.NotFound.GetDescription().FormatTo("Planta"));

        return await _plantRepository.DeleteAsync(plantId);
    }

    private void SetMutipleImages(List<IFormFile> formFiles, Plant plant)
    {
        foreach (var file in formFiles)
        {
            plant.Images.Add((PlantImage)file.BuildFileImage());
        }
    }

    private void SetMainImage(IFormFile formFile, Plant plant)
    {
        var mainImage = (PlantImage)formFile.BuildFileImage();

        mainImage.MainImage = true;

        plant.Images = new List<PlantImage>
        {
            { mainImage }
        };
    }
}
