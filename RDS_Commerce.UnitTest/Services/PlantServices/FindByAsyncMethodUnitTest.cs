using Moq;
using RDS_Commerce.Business.Handler.PaginationSettings;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.UnitTest.Builders;
using RDS_Commerce.UnitTest.Services.PlantServices.Base;
using RDS_Commerce.UnitTest.Tools;

namespace RDS_Commerce.UnitTest.Services.PlantServices;
public sealed class FindByAsyncMethodUnitTest : PlantServiceBaseUnitTest
{
    [Fact]
    [Trait("Sucess", "Return plant")]
    public async Task FindByAsync_ReturnPlantById()
    {
        const int PLANT_ID = 85;
        var plant = PlantBuilder.NewObject().WithId(PLANT_ID).DomainBuild();
        _plantRepository.Setup(pr => pr.FindByAsync(PLANT_ID, UtilTools.BuildQueryableIncludeFunc<Plant>(), true)).ReturnsAsync(plant);

        var serviceResult = await _service.FindByAsync(PLANT_ID);

        _plantRepository.Verify(pr => pr.FindByAsync(PLANT_ID, UtilTools.BuildQueryableIncludeFunc<Plant>(), true), Times.Once());
        Assert.NotNull(serviceResult);
    }

    [Fact]
    [Trait("Failed", "Not found plant")]
    public async Task FindByAsync_NotFoundPlant_ReturnNull()
    {
        const int PLANT_ID = 85;
        var plant = PlantBuilder.NewObject().WithId(PLANT_ID).DomainBuild();
        _plantRepository.Setup(pr => pr.FindByAsync(PLANT_ID, UtilTools.BuildQueryableIncludeFunc<Plant>(), true));

        var serviceResult = await _service.FindByAsync(PLANT_ID);

        _plantRepository.Verify(pr => pr.FindByAsync(PLANT_ID, UtilTools.BuildQueryableIncludeFunc<Plant>(), true), Times.Once());
        Assert.Null(serviceResult);
    }

    
}

