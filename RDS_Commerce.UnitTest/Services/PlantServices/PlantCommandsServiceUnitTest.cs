using Microsoft.AspNetCore.Http;
using Moq;
using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.ApplicationServices.Dtos.Request.PlantRequest;
using RDS_Commerce.ApplicationServices.Services;
using RDS_Commerce.Business.Handler.ValidationSettings.EntitiesValidation;
using RDS_Commerce.Business.Interfaces.OthersContracts;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Domain.Enums;
using RDS_Commerce.UnitTest.Builders.PlantBuilders;
using RDS_Commerce.UnitTest.Tools;

namespace RDS_Commerce.UnitTest.Services.PlantServices;
public sealed class PlantCommandsServiceUnitTest
{
    private Mock<INotificationHandler> _notification;
    private Mock<IPlantRepository> _plantRepository;
    private PlantValidation _validatePlant;
    private PlantService _service;
    public PlantCommandsServiceUnitTest()
    {
        _notification = new Mock<INotificationHandler>();
        _plantRepository = new Mock<IPlantRepository>();
        _validatePlant = new PlantValidation();

        _service = new PlantService(_plantRepository.Object,
                                    _notification.Object,
                                    _validatePlant);

        AutoMapperFactoryConfigurations.Initialize();
    }

    public static IEnumerable<object[]> GetPlantSaveRequestToRegister()
    {
        yield return new object[]
        {
            new PlantSaveRequest
            {
                Name = "Plant name",
                Description = "description the plant.",
                ProductType = EProductType.Special,
                Amount = 3,
                Price = 150.50m,
                Specie = "Specie",
                FileImage = UtilTools.BuildIFormFile()
            }
        };
    }

    [Theory]
    [Trait("Sucess", "Create Plant")]
    [MemberData(nameof(GetPlantSaveRequestToRegister))]
    public async Task SaveAsync_ReturnTrue(PlantSaveRequest plantSave)
    {
        _plantRepository.Setup(pr => pr.ExistInTheDatabaseAsync(UtilTools.BuildPredicateFunc<Plant>())).ReturnsAsync(false);
        _plantRepository.Setup(pr => pr.SaveAsync(It.IsAny<Plant>())).ReturnsAsync(true);

        var serviceResult = await _service.SaveAsync(plantSave);

        _plantRepository.Verify(pr => pr.ExistInTheDatabaseAsync(UtilTools.BuildPredicateFunc<Plant>()), Times.Once());
        _plantRepository.Verify(pr => pr.SaveAsync(It.IsAny<Plant>()), Times.Once());
        Assert.True(serviceResult);
    }

    [Theory]
    [Trait("Failed", "Exist name in Db")]
    [MemberData(nameof(GetPlantSaveRequestToRegister))]
    public async Task SaveAsync_HasExist_ReturnFalse(PlantSaveRequest plantSave)
    {
        _plantRepository.Setup(pr => pr.ExistInTheDatabaseAsync(UtilTools.BuildPredicateFunc<Plant>())).ReturnsAsync(true);

        var serviceResult = await _service.SaveAsync(plantSave);

        _plantRepository.Verify(pr => pr.ExistInTheDatabaseAsync(UtilTools.BuildPredicateFunc<Plant>()), Times.Once());
        _plantRepository.Verify(pr => pr.SaveAsync(It.IsAny<Plant>()), Times.Never());
        Assert.False(serviceResult);
    }


    public static IEnumerable<object[]> GetPlantUpdateRequest()
    {
        yield return new object[]
        {
            new PlantUpdateRequest
            {
                PlantId = 15,
                Name = "Plant name",
                Description = "description the plant.",
                ProductType = EProductType.Special,
                Amount = 3,
                Price = 150.50m,
                Specie = "Specie"
            }
        };
    }

    [Theory]
    [Trait("Success", "Update Plant")]
    [MemberData(nameof(GetPlantUpdateRequest))]
    public async Task UpdateAsync_ReturnTrue(PlantUpdateRequest plantUpdate)
    {
        var plant = PlantBuilder.NewObject().DomainBuild();
        _plantRepository.Setup(pr => pr.ExistInTheDatabaseAsync(UtilTools.BuildPredicateFunc<Plant>())).ReturnsAsync(false);
        _plantRepository.Setup(pr => pr.FindByAsync(plantUpdate.PlantId, UtilTools.BuildQueryableIncludeFunc<Plant>(), false)).ReturnsAsync(plant);
        _plantRepository.Setup(pr => pr.UpdateAsync(It.IsAny<Plant>())).ReturnsAsync(true);

        var serviceResult = await _service.UpdateAsync(plantUpdate);

        _plantRepository.Verify(pr => pr.ExistInTheDatabaseAsync(UtilTools.BuildPredicateFunc<Plant>()), Times.Once());
        _plantRepository.Verify(pr => pr.FindByAsync(plantUpdate.PlantId, UtilTools.BuildQueryableIncludeFunc<Plant>(), false), Times.Once());
        _plantRepository.Verify(pr => pr.UpdateAsync(It.IsAny<Plant>()), Times.Once());
        Assert.True(serviceResult);
    }


    [Theory]
    [Trait("Failed", "Exist name in db")]
    [MemberData(nameof(GetPlantUpdateRequest))]
    public async Task UpdateAsync_ExistName_ReturnFalse(PlantUpdateRequest plantUpdate)
    {
        var plant = PlantBuilder.NewObject().DomainBuild();
        _plantRepository.Setup(pr => pr.ExistInTheDatabaseAsync(UtilTools.BuildPredicateFunc<Plant>())).ReturnsAsync(true);
        _plantRepository.Setup(pr => pr.FindByAsync(plantUpdate.PlantId, UtilTools.BuildQueryableIncludeFunc<Plant>(), false)).ReturnsAsync(plant);
        _plantRepository.Setup(pr => pr.UpdateAsync(It.IsAny<Plant>())).ReturnsAsync(false);

        var serviceResult = await _service.UpdateAsync(plantUpdate);

        _plantRepository.Verify(pr => pr.ExistInTheDatabaseAsync(UtilTools.BuildPredicateFunc<Plant>()), Times.Once());
        _plantRepository.Verify(pr => pr.FindByAsync(plantUpdate.PlantId, UtilTools.BuildQueryableIncludeFunc<Plant>(), false), Times.Never());
        _plantRepository.Verify(pr => pr.UpdateAsync(It.IsAny<Plant>()), Times.Never());
        Assert.False(serviceResult);
    }

    [Theory]
    [Trait("Failed", "Not found")]
    [MemberData(nameof(GetPlantUpdateRequest))]
    public async Task UpdateAsync_NotFound_ReturnFalse(PlantUpdateRequest plantUpdate)
    {
        _plantRepository.Setup(pr => pr.ExistInTheDatabaseAsync(UtilTools.BuildPredicateFunc<Plant>())).ReturnsAsync(false);
        _plantRepository.Setup(pr => pr.UpdateAsync(It.IsAny<Plant>())).ReturnsAsync(false);

        var serviceResult = await _service.UpdateAsync(plantUpdate);

        _plantRepository.Verify(pr => pr.ExistInTheDatabaseAsync(UtilTools.BuildPredicateFunc<Plant>()), Times.Once());
        _plantRepository.Verify(pr => pr.FindByAsync(plantUpdate.PlantId, UtilTools.BuildQueryableIncludeFunc<Plant>(), false), Times.Once());
        _plantRepository.Verify(pr => pr.UpdateAsync(It.IsAny<Plant>()), Times.Never());
        Assert.False(serviceResult);
    }

    public static IEnumerable<object[]> GetImages()
    {
        yield return new object[]
        {
            new PlantUpdateImagesRequest
            {
                PlantId = 101,
                FormFileImages = new List<IFormFile>
                {
                    UtilTools.BuildIFormFile(),
                    UtilTools.BuildIFormFile(),
                    UtilTools.BuildIFormFile(),
                    UtilTools.BuildIFormFile(),
                    UtilTools.BuildIFormFile()
                }
            }
        };
    }

    [Theory]
    [Trait("Success", "Insert multiple images")]
    [MemberData(nameof(GetImages))]
    public async Task InsertOtherImagesAsync_ReturnTrue(PlantUpdateImagesRequest plantUpdateImages)
    {
        var plant = PlantBuilder.NewObject().WithId(plantUpdateImages.PlantId).DomainBuild();
        _plantRepository.Setup(pr => pr.FindByAsync(plantUpdateImages.PlantId, UtilTools.BuildQueryableIncludeFunc<Plant>(), false)).ReturnsAsync(plant);
        _plantRepository.Setup(pr => pr.UpdateAsync(It.IsAny<Plant>())).ReturnsAsync(true);

        var serviceResult = await _service.InsertOtherImagesAsync(plantUpdateImages);

        _plantRepository.Verify(pr => pr.FindByAsync(plantUpdateImages.PlantId, UtilTools.BuildQueryableIncludeFunc<Plant>(), false), Times.Once());
        _plantRepository.Verify(pr => pr.UpdateAsync(It.IsAny<Plant>()), Times.Once());
        Assert.True(serviceResult);
    }

    [Theory]
    [Trait("Failed", "Exceeded maximum image amount")]
    [MemberData(nameof(GetImages))]
    public async Task InsertOtherImagesAsync_ExceededMaxImageAmount_ReturnFalse(PlantUpdateImagesRequest plantUpdateImages)
    {
        var plant = PlantBuilder.NewObject().WithId(plantUpdateImages.PlantId).DomainBuild();
        var newImage = UtilTools.BuildIFormFile();
        plantUpdateImages.FormFileImages.Add(newImage);
        _plantRepository.Setup(pr => pr.FindByAsync(plantUpdateImages.PlantId, UtilTools.BuildQueryableIncludeFunc<Plant>(), false)).ReturnsAsync(plant);
        _plantRepository.Setup(pr => pr.UpdateAsync(It.IsAny<Plant>())).ReturnsAsync(false);

        var serviceResult = await _service.InsertOtherImagesAsync(plantUpdateImages);

        _plantRepository.Verify(pr => pr.FindByAsync(plantUpdateImages.PlantId, UtilTools.BuildQueryableIncludeFunc<Plant>(), false), Times.Once());
        _plantRepository.Verify(pr => pr.UpdateAsync(It.IsAny<Plant>()), Times.Never());
        Assert.False(serviceResult);
    }


    [Theory]
    [Trait("Failed", "Not found Plant")]
    [MemberData(nameof(GetImages))]
    public async Task InsertOtherImagesAsync_NotFoundPlant_ReturnFalse(PlantUpdateImagesRequest plantUpdateImages)
    {
        var plant = PlantBuilder.NewObject().WithId(plantUpdateImages.PlantId).DomainBuild();
        _plantRepository.Setup(pr => pr.FindByAsync(plantUpdateImages.PlantId, UtilTools.BuildQueryableIncludeFunc<Plant>(), false));

        var serviceResult = await _service.InsertOtherImagesAsync(plantUpdateImages);

        _plantRepository.Verify(pr => pr.FindByAsync(plantUpdateImages.PlantId, UtilTools.BuildQueryableIncludeFunc<Plant>(), false), Times.Once());
        _plantRepository.Verify(pr => pr.UpdateAsync(It.IsAny<Plant>()), Times.Never());
        Assert.False(serviceResult);
    }

    [Fact]
    [Trait("Success", "Remove plant")]
    public async Task DeleteAsync_ReturnTrue()
    {
        const int PLANT_ID = 101;
        _plantRepository.Setup(pr => pr.ExistInTheDatabaseAsync(UtilTools.BuildPredicateFunc<Plant>())).ReturnsAsync(true);
        _plantRepository.Setup(pr => pr.DeleteAsync(PLANT_ID)).ReturnsAsync(true);

        var serviceResult = await _service.DeleteAsync(PLANT_ID);

        _plantRepository.Verify(pr => pr.ExistInTheDatabaseAsync(UtilTools.BuildPredicateFunc<Plant>()), Times.Once());
        _plantRepository.Verify(pr => pr.DeleteAsync(PLANT_ID), Times.Once());
        Assert.True(serviceResult);
    }

    [Fact]
    [Trait("Failed", "Not found Plant")]
    public async Task DeleteAsync_NotFountPlant_ReturnFalse()
    {
        const int PLANT_ID = 101;
        _plantRepository.Setup(pr => pr.ExistInTheDatabaseAsync(UtilTools.BuildPredicateFunc<Plant>())).ReturnsAsync(false);

        var serviceResult = await _service.DeleteAsync(PLANT_ID);

        _plantRepository.Verify(pr => pr.ExistInTheDatabaseAsync(UtilTools.BuildPredicateFunc<Plant>()), Times.Once());
        _plantRepository.Verify(pr => pr.DeleteAsync(PLANT_ID), Times.Never());
        Assert.False(serviceResult);
    }
}
