using Moq;
using RDS_Commerce.ApplicationServices.Dtos.Request.PlantRequest;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Domain.Enums;
using RDS_Commerce.UnitTest.Services.PlantServices.Base;
using RDS_Commerce.UnitTest.Tools;

namespace RDS_Commerce.UnitTest.Services.PlantServices;
public class SaveAsyncMethodUnitTest : PlantServiceBaseUnitTest
{
    public static IEnumerable<object[]> GetPlantSaveRequestToRegister()
    {
        yield return new object[]
        {
            new PlantDtoForRegister
            {
                Name = "Plant name",
                Description = "description the plant.",
                PlantType = EPlantType.Special,
                Amount = 3,
                Price = 150.50m,
                Specie = "Specie",
                FileImage = UtilTools.BuildIFormFile()
            }
        };
    }

    [Theory]
    [Trait("Success", "Create Plant")]
    [MemberData(nameof(GetPlantSaveRequestToRegister))]
    public async Task SaveAsync_PerfectSetting_ReturnTrue(PlantDtoForRegister plantSave)
    {
        _plantRepository.Setup(pr => pr.ExistInTheDatabaseAsync(UtilTools.BuildPredicateFunc<Plant>())).ReturnsAsync(false);
        _plantRepository.Setup(pr => pr.SaveAsync(It.IsAny<Plant>())).ReturnsAsync(true);

        var serviceResult = await _service.SaveAsync(plantSave);

        _plantRepository.Verify(pr => pr.ExistInTheDatabaseAsync(UtilTools.BuildPredicateFunc<Plant>()), Times.Once());
        _plantRepository.Verify(pr => pr.SaveAsync(It.IsAny<Plant>()), Times.Once());
        Assert.True(serviceResult);
    }

    [Theory]
    [Trait("Failed", "There is the name in the db")]
    [MemberData(nameof(GetPlantSaveRequestToRegister))]
    public async Task SaveAsync_ThereIsTheNameInTheDb_ReturnFalse(PlantDtoForRegister plantSave)
    {
        _plantRepository.Setup(pr => pr.ExistInTheDatabaseAsync(UtilTools.BuildPredicateFunc<Plant>())).ReturnsAsync(true);

        var serviceResult = await _service.SaveAsync(plantSave);

        _plantRepository.Verify(pr => pr.ExistInTheDatabaseAsync(UtilTools.BuildPredicateFunc<Plant>()), Times.Once());
        _plantRepository.Verify(pr => pr.SaveAsync(It.IsAny<Plant>()), Times.Never());
        Assert.False(serviceResult);
    }
}
