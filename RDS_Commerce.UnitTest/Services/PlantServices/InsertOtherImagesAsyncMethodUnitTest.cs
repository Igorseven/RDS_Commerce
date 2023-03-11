using Microsoft.AspNetCore.Http;
using Moq;
using RDS_Commerce.ApplicationServices.Dtos.Request.PlantRequest;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.UnitTest.Builders;
using RDS_Commerce.UnitTest.Services.PlantServices.Base;
using RDS_Commerce.UnitTest.Tools;

namespace RDS_Commerce.UnitTest.Services.PlantServices;
public sealed class InsertOtherImagesAsyncMethodUnitTest : PlantServiceBaseUnitTest
{
    public static IEnumerable<object[]> GetImages()
    {
        yield return new object[]
        {
            new PlantDtoForUpdateImages
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
    public async Task InsertOtherImagesAsync_ReturnTrue(PlantDtoForUpdateImages plantUpdateImages)
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
    public async Task InsertOtherImagesAsync_ExceededMaxImageAmount_ReturnFalse(PlantDtoForUpdateImages plantUpdateImages)
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
    public async Task InsertOtherImagesAsync_NotFoundPlant_ReturnFalse(PlantDtoForUpdateImages plantUpdateImages)
    {
        var plant = PlantBuilder.NewObject().WithId(plantUpdateImages.PlantId).DomainBuild();
        _plantRepository.Setup(pr => pr.FindByAsync(plantUpdateImages.PlantId, UtilTools.BuildQueryableIncludeFunc<Plant>(), false));

        var serviceResult = await _service.InsertOtherImagesAsync(plantUpdateImages);

        _plantRepository.Verify(pr => pr.FindByAsync(plantUpdateImages.PlantId, UtilTools.BuildQueryableIncludeFunc<Plant>(), false), Times.Once());
        _plantRepository.Verify(pr => pr.UpdateAsync(It.IsAny<Plant>()), Times.Never());
        Assert.False(serviceResult);
    }

    
}
