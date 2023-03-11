using Moq;
using RDS_Commerce.ApplicationServices.Dtos.Request.GenusRequest;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.UnitTest.Builders;
using RDS_Commerce.UnitTest.Services.GenusServices.Base;
using RDS_Commerce.UnitTest.Tools;

namespace RDS_Commerce.UnitTest.Services.GenusServices;
public class UpdateGenusAsyncMethodUnitTest : GenusServiceBaseUnitTest
{

    public static IEnumerable<Object[]> DtoPerfectSetting()
    {
        yield return new Object[]
        {
            new GenusDtoForUpdate
            {
                GenusId = 11,
                GenusName = "Gênero da Planta",
                Specie = "Espécie da Planta"
            }
        };
    }

    [Theory]
    [Trait("Success", "Perfect setting")]
    [MemberData(nameof(DtoPerfectSetting))]
    public async Task UpdateGenusAsync_PerfectSetting_ReturnTrue(GenusDtoForUpdate genusUpdateRequest)
    {
        var genus = GenusBuilder.NewObject().WithGenusId(genusUpdateRequest.GenusId).DomainBuild();

        _genusRespository.Setup(g => g.ExistInTheDatabaseAsync(UtilTools.BuildPredicateFunc<Genus>()).Result).Returns(false);
        _genusRespository.Setup(g => g.FindByIdAsync(genusUpdateRequest.GenusId, null, false).Result).Returns(genus);
        _genusRespository.Setup(g => g.UpdateAsync(It.IsAny<Domain.Entities.Genus>()).Result).Returns(true);

        var serviceResult = await _genusService.UpdateGenusAsync(genusUpdateRequest);

        Assert.True(serviceResult);
        _genusRespository.Verify(g => g.FindByIdAsync(genusUpdateRequest.GenusId, null, false), Times.Once());
        _genusRespository.Verify(g => g.UpdateAsync(It.IsAny<Domain.Entities.Genus>()), Times.Once());
    }


    public static IEnumerable<Object[]> DtoForScenerioThereIsTheNameInTheDb()
    {
        yield return new Object[]
        {
            new GenusDtoForUpdate
            {
                GenusId = 11,
                GenusName = "Nome repetido",
                Specie = "Espécie da Planta"
            }
        };
    }

    [Theory]
    [Trait("Failed", "There is the name in the db")]
    [MemberData(nameof(DtoForScenerioThereIsTheNameInTheDb))]
    public async Task UpdateGenusAsync_ThereIsTheNameInTheDb_ReturnFalse(GenusDtoForUpdate genusUpdateRequest)
    {
        _genusRespository.Setup(g => g.ExistInTheDatabaseAsync(UtilTools.BuildPredicateFunc<Genus>()).Result).Returns(true);

        var serviceResult = await _genusService.UpdateGenusAsync(genusUpdateRequest);

        Assert.False(serviceResult);
        _genusRespository.Verify(g => g.ExistInTheDatabaseAsync(UtilTools.BuildPredicateFunc<Genus>()), Times.Once());
        _genusRespository.Verify(g => g.FindByIdAsync(genusUpdateRequest.GenusId, null, false), Times.Never());
        _genusRespository.Verify(g => g.UpdateAsync(It.IsAny<Genus>()), Times.Never());
    }


    public static IEnumerable<Object[]> DtoForScenerioNotFound()
    {
        yield return new Object[]
        {
            new GenusDtoForUpdate
            {
                GenusId = 1001,
                GenusName = "Gênero da Planta",
                Specie = "Espécie da Planta"
            }
        };
    }

    [Theory]
    [Trait("Failed", "Genus not found")]
    [MemberData(nameof(DtoForScenerioNotFound))]
    public async Task UpdateGenusAsync_GenusNotFound_ReturnFalse(GenusDtoForUpdate genusUpdateRequest)
    {
        _genusRespository.Setup(g => g.ExistInTheDatabaseAsync(UtilTools.BuildPredicateFunc<Genus>()).Result).Returns(false);
        _genusRespository.Setup(g => g.FindByIdAsync(genusUpdateRequest.GenusId, null, false).Result);

        var serviceResult = await _genusService.UpdateGenusAsync(genusUpdateRequest);

        Assert.False(serviceResult);
        _genusRespository.Verify(g => g.ExistInTheDatabaseAsync(UtilTools.BuildPredicateFunc<Genus>()), Times.Once());
        _genusRespository.Verify(g => g.FindByIdAsync(genusUpdateRequest.GenusId, null, false), Times.Once());
        _genusRespository.Verify(g => g.UpdateAsync(It.IsAny<Genus>()), Times.Never());
    }
}
