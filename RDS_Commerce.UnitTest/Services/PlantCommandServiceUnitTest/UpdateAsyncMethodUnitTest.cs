using Moq;
using RDS_Commerce.ApplicationServices.Dtos.Request.PlantRequest;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Domain.Enums;
using RDS_Commerce.UnitTest.Builders;
using RDS_Commerce.UnitTest.Services.PlantServices.Base;
using RDS_Commerce.UnitTest.Tools;

namespace RDS_Commerce.UnitTest.Services.PlantCommandServiceUnitTest;
public class UpdateAsyncMethodUnitTest : PlantServiceBaseUnitTest
{
    public static IEnumerable<object[]> GetPlantUpdateRequest()
    {
        yield return new object[]
        {
            new PlantDtoForUpdate
            {
                PlantId = 15,
                Name = "Plant name",
                Description = "description the plant.",
                PlantType = EPlantType.Special,
                Amount = 3,
                Price = 150.50m
            }
        };
    }

    [Theory]
    [Trait("Success", "Update Plant")]
    [MemberData(nameof(GetPlantUpdateRequest))]
    public async Task UpdateAsync_ReturnTrue(PlantDtoForUpdate plantUpdate)
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
    public async Task UpdateAsync_ExistName_ReturnFalse(PlantDtoForUpdate plantUpdate)
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
    public async Task UpdateAsync_NotFound_ReturnFalse(PlantDtoForUpdate plantUpdate)
    {
        _plantRepository.Setup(pr => pr.ExistInTheDatabaseAsync(UtilTools.BuildPredicateFunc<Plant>())).ReturnsAsync(false);
        _plantRepository.Setup(pr => pr.UpdateAsync(It.IsAny<Plant>())).ReturnsAsync(false);

        var serviceResult = await _service.UpdateAsync(plantUpdate);

        _plantRepository.Verify(pr => pr.ExistInTheDatabaseAsync(UtilTools.BuildPredicateFunc<Plant>()), Times.Once());
        _plantRepository.Verify(pr => pr.FindByAsync(plantUpdate.PlantId, UtilTools.BuildQueryableIncludeFunc<Plant>(), false), Times.Once());
        _plantRepository.Verify(pr => pr.UpdateAsync(It.IsAny<Plant>()), Times.Never());
        Assert.False(serviceResult);
    }
}
