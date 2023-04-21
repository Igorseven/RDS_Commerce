using Moq;
using RDS_Commerce.ApplicationServices.Dtos.Request.PlantRequest;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Domain.Enums;
using RDS_Commerce.UnitTest.Services.PlantServices.Base;
using RDS_Commerce.UnitTest.Tools;

namespace RDS_Commerce.UnitTest.Services.PlantCommandServiceUnitTest;
public class SaveAsyncMethodUnitTest : PlantServiceBaseUnitTest
{
    public static IEnumerable<object[]> GetPlantSaveRequestToRegisterPerfectSetting()
    {
        yield return new object[]
        {
            new PlantDtoForRegister
            {
                Name = "Plant name",
                Description = "description the plant.",
                PlantType = EPlantType.Special,
                Quantity = 3,
                Price = 150.50m,
                FileImage = UtilTools.BuildIFormFile()
            }
        };
    }

    [Theory]
    [Trait("Success", "Create Plant")]
    [MemberData(nameof(GetPlantSaveRequestToRegisterPerfectSetting))]
    public async Task SaveAsync_PerfectSetting_ReturnTrue(PlantDtoForRegister plantSave)
    {
        _plantRepository.Setup(pr => pr.ExistInTheDatabaseAsync(UtilTools.BuildPredicateFunc<Plant>())).ReturnsAsync(false);
        _plantRepository.Setup(pr => pr.SaveAsync(It.IsAny<Plant>())).ReturnsAsync(true);

        var serviceResult = await _service.CreatePlantAsync(plantSave);

        _plantRepository.Verify(pr => pr.ExistInTheDatabaseAsync(UtilTools.BuildPredicateFunc<Plant>()), Times.Once());
        _plantRepository.Verify(pr => pr.SaveAsync(It.IsAny<Plant>()), Times.Once());
        Assert.True(serviceResult);
    }

    public static IEnumerable<object[]> GetPlantSaveRequestToRegisterExistingNameInDb()
    {
        yield return new object[]
        {
            new PlantDtoForRegister
            {
                Name = "Plant name",
                Description = "description the plant.",
                PlantType = EPlantType.Special,
                Quantity = 3,
                Price = 150.50m,
                FileImage = UtilTools.BuildIFormFile()
            }
        };
    }

    [Theory]
    [Trait("Failed", "There is the name in the db")]
    [MemberData(nameof(GetPlantSaveRequestToRegisterExistingNameInDb))]
    public async Task SaveAsync_ThereIsTheNameInTheDb_ReturnFalse(PlantDtoForRegister plantSave)
    {
        _plantRepository.Setup(pr => pr.ExistInTheDatabaseAsync(UtilTools.BuildPredicateFunc<Plant>())).ReturnsAsync(true);

        var serviceResult = await _service.CreatePlantAsync(plantSave);

        _plantRepository.Verify(pr => pr.ExistInTheDatabaseAsync(UtilTools.BuildPredicateFunc<Plant>()), Times.Once());
        _plantRepository.Verify(pr => pr.SaveAsync(It.IsAny<Plant>()), Times.Never());
        Assert.False(serviceResult);
    }
}
