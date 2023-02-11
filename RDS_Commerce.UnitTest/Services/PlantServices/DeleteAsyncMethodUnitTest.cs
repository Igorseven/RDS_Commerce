using Moq;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.UnitTest.Builders;
using RDS_Commerce.UnitTest.Services.PlantServices.Base;
using RDS_Commerce.UnitTest.Tools;

namespace RDS_Commerce.UnitTest.Services.PlantServices;
public class DeleteAsyncMethodUnitTest : PlantServiceBaseUnitTest
{
    [Fact]
    [Trait("Success", "Remove plant")]
    public async Task DeleteAsync_ReturnTrue()
    {
        const int PLANT_ID = 101;
        const int AMOUNT = 0;
        var plant = PlantBuilder.NewObject().WithId(PLANT_ID).WithAmount(AMOUNT).DomainBuild();

        _plantRepository.Setup(pr => pr.FindByAsync(PLANT_ID, UtilTools.BuildQueryableIncludeFunc<Plant>(), false)).ReturnsAsync(plant);
        _plantRepository.Setup(pr => pr.DeleteAsync(PLANT_ID)).ReturnsAsync(true);

        var serviceResult = await _service.DeleteAsync(PLANT_ID);

        _plantRepository.Verify(pr => pr.FindByAsync(PLANT_ID, UtilTools.BuildQueryableIncludeFunc<Plant>(), false), Times.Once());
        _plantRepository.Verify(pr => pr.DeleteAsync(PLANT_ID), Times.Once());
        Assert.True(serviceResult);
    }

    [Fact]
    [Trait("Failed", "Not found Plant")]
    public async Task DeleteAsync_NotFountPlant_ReturnFalse()
    {
        const int PLANT_ID = 101;

        _plantRepository.Setup(pr => pr.FindByAsync(PLANT_ID, UtilTools.BuildQueryableIncludeFunc<Plant>(), false));

        var serviceResult = await _service.DeleteAsync(PLANT_ID);

        _plantRepository.Verify(pr => pr.FindByAsync(PLANT_ID, UtilTools.BuildQueryableIncludeFunc<Plant>(), false), Times.Once());
        _plantRepository.Verify(pr => pr.DeleteAsync(PLANT_ID), Times.Never());
        Assert.False(serviceResult);
    }

    [Fact]
    [Trait("Failed", "Have balance")]
    public async Task DeleteAsync_HaveBalance_ReturnFalse()
    {
        const int PLANT_ID = 101;
        const int AMOUNT = 1;
        var plant = PlantBuilder.NewObject().WithId(PLANT_ID).WithAmount(AMOUNT).DomainBuild();

        _plantRepository.Setup(pr => pr.FindByAsync(PLANT_ID, UtilTools.BuildQueryableIncludeFunc<Plant>(), false)).ReturnsAsync(plant);

        var serviceResult = await _service.DeleteAsync(PLANT_ID);

        _plantRepository.Verify(pr => pr.FindByAsync(PLANT_ID, UtilTools.BuildQueryableIncludeFunc<Plant>(), false), Times.Once());
        _plantRepository.Verify(pr => pr.DeleteAsync(PLANT_ID), Times.Never());
        Assert.False(serviceResult);
    }
}
