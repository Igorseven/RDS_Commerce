using Moq;
using RDS_Commerce.ApplicationServices.Dtos.Request.PlantRequest;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.UnitTest.Builders;
using RDS_Commerce.UnitTest.Services.PlantImageServices.Base;
using RDS_Commerce.UnitTest.Tools;

namespace RDS_Commerce.UnitTest.Services.PlantImageServices;
public class UpdateMainImageAsyncMethodUnitTest : PlantImageServiceBaseUnitTest
{

    [Fact]
    [Trait("Success", "Update main image")]
    public async Task UpdateMainImageAsync_ReturnTrue()
    {
        var updateRequest = new PlantDtoForUpdateMainImage
        {
            PlantId = 12,
            PlantImageId = 16
        };

        var currentMainImage = PlantImageBuilder.NewObject().DomainBuild();
        var newMainImage = PlantImageBuilder.NewObject().WithId(updateRequest.PlantImageId).DomainBuild();

        var imgages = new List<PlantImage>()
        {
            currentMainImage,
            newMainImage
        };

        _plantImageRepository.Setup(r => r.FindByPredicateAsync(UtilTools.BuildPredicateFunc<PlantImage>(), false, false)).ReturnsAsync(currentMainImage);
        _plantImageRepository.Setup(r => r.FindByAsync(updateRequest.PlantImageId, false, false)).ReturnsAsync(newMainImage);
        _plantImageRepository.Setup(r => r.UpdateImageSeveralplantsAsync(imgages)).ReturnsAsync(true);

        var serviceResult = await _service.UpdateMainImageAsync(updateRequest);

        Assert.True(serviceResult);
        _notificationHandler.Verify(r => r.CreateNotification("Notification", "Notification"), Times.Never());
        _plantImageRepository.Verify(r => r.FindByPredicateAsync(UtilTools.BuildPredicateFunc<PlantImage>(), false, false), Times.Once);
        _plantImageRepository.Verify(r => r.FindByAsync(updateRequest.PlantImageId, false, false), Times.Once);
        _plantImageRepository.Verify(r => r.UpdateImageSeveralplantsAsync(imgages), Times.Once);

    }


    [Fact]
    [Trait("Failed", "Pland not found")]
    public async Task UpdateMainImageAsync_PlantNotFound_ReturnFalse()
    {
        var updateRequest = new PlantDtoForUpdateMainImage
        {
            PlantId = 12,
            PlantImageId = 16
        };

        var currentMainImage = PlantImageBuilder.NewObject().DomainBuild();
        var newMainImage = PlantImageBuilder.NewObject().WithId(updateRequest.PlantImageId).DomainBuild();

        var imgages = new List<PlantImage>()
        {
            currentMainImage,
            newMainImage
        };

        _plantImageRepository.Setup(r => r.FindByPredicateAsync(UtilTools.BuildPredicateFunc<PlantImage>(), false, false));
        _plantImageRepository.Setup(r => r.FindByAsync(updateRequest.PlantImageId, false, false)).ReturnsAsync(newMainImage);
        _plantImageRepository.Setup(r => r.UpdateImageSeveralplantsAsync(imgages)).ReturnsAsync(true);

        var serviceResult = await _service.UpdateMainImageAsync(updateRequest);

        Assert.False(serviceResult);
        _plantImageRepository.Verify(r => r.FindByPredicateAsync(UtilTools.BuildPredicateFunc<PlantImage>(), false, false), Times.Once());
        _plantImageRepository.Verify(r => r.FindByAsync(updateRequest.PlantImageId, false, false), Times.Never());
        _plantImageRepository.Verify(r => r.UpdateImageSeveralplantsAsync(imgages), Times.Never());
    }
}
