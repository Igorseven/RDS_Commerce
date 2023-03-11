using Moq;
using RDS_Commerce.ApplicationServices.Dtos.Request.GenusRequest;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.UnitTest.Services.GenusServices.Base;
using RDS_Commerce.UnitTest.Tools;

namespace RDS_Commerce.UnitTest.Services.GenusServices;
public class CreateNewGenusAsyncMethodUnitTest : GenusServiceBaseUnitTest
{

    public static IEnumerable<Object[]> GetGenusSaveRequest()
    {
        yield return new Object[]
        {
            new GenusDtoForRegister
            {
                GenusName = "Gênero da Planta",
                Specie = "Espécie da Planta"
            }
        };
    }

    [Theory]
    [Trait("Success", "Perfect setting")]
    [MemberData(nameof(GetGenusSaveRequest))]
    public async Task CreateNewGenusAsync_PerfectSetting_ReturnTrue(GenusDtoForRegister genusSaveRequest)
    {

        _genusRespository.Setup(g => g.ExistInTheDatabaseAsync(UtilTools.BuildPredicateFunc<Genus>()).Result).Returns(false);
        _genusRespository.Setup(g => g.SaveAsync(It.IsAny<Genus>()).Result).Returns(true);

        var serviceResult = await _genusService.CreateNewGenusAsync(genusSaveRequest);

        Assert.True(serviceResult);
        _genusRespository.Verify(g => g.ExistInTheDatabaseAsync(UtilTools.BuildPredicateFunc<Genus>()), Times.Once());
        _genusRespository.Verify(g => g.SaveAsync(It.IsAny<Genus>()), Times.Once());
    }


    public static IEnumerable<Object[]> GetGenusSaveRequestThereIsTheNameInTheDb()
    {
        yield return new Object[]
        {
            new GenusDtoForRegister
            {
                GenusName = "Gênero da Planta",
                Specie = "Espécie da Planta"
            }
        };
    }

    [Theory]
    [Trait("Failed", "There is the name in the db")]
    [MemberData(nameof(GetGenusSaveRequestThereIsTheNameInTheDb))]
    public async Task CreateNewGenusAsync_ThereIsTheNameInTheDb_ReturnFalse(GenusDtoForRegister genusSaveRequest)
    {

        _genusRespository.Setup(g => g.ExistInTheDatabaseAsync(UtilTools.BuildPredicateFunc<Genus>()).Result).Returns(true);

        var serviceResult = await _genusService.CreateNewGenusAsync(genusSaveRequest);

        Assert.False(serviceResult);
        _genusRespository.Verify(g => g.ExistInTheDatabaseAsync(UtilTools.BuildPredicateFunc<Genus>()), Times.Once());
        _genusRespository.Verify(g => g.SaveAsync(It.IsAny<Genus>()), Times.Never());
    }
}
