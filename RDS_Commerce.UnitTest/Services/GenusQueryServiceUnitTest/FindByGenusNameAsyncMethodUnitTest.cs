using Moq;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.UnitTest.Builders;
using RDS_Commerce.UnitTest.Services.GenusQueryServiceUnitTest.Base;
using RDS_Commerce.UnitTest.Tools;

namespace RDS_Commerce.UnitTest.Services.GenusQueryServiceUnitTest;
public sealed class FindByGenusNameAsyncMethodUnitTest : GenusQueryServiceSetup
{
    [Fact]
    [Trait("Success", "Return Object")]
    public async Task FindByGenusNameAsync_PerfectSetting_ReturnGenusObject()
    {
        const string GENUS_NAME = "Equiveria de Prata";
        var genus = GenusBuilder.NewObject().WithGenusName(GENUS_NAME).DomainBuild();

        _genusRespository.Setup(g => g.FindByNameAsync(UtilTools.BuildPredicateFunc<Genus>(), true).Result).Returns(genus);

        var serviceResult = await _genusQueryService.FindByGenusNameAsync(GENUS_NAME);

        Assert.NotNull(serviceResult);
        _genusRespository.Verify(g => g.FindByNameAsync(UtilTools.BuildPredicateFunc<Genus>(), true), Times.Once());
    }

    [Fact]
    [Trait("Success", "Not found")]
    public async Task FindByGenusNameAsync_NotFound_ReturnNull()
    {
        const string GENUS_NAME = "Lua Negra";
        var genus = GenusBuilder.NewObject().WithGenusName(GENUS_NAME).DomainBuild();

        _genusRespository.Setup(g => g.FindByNameAsync(UtilTools.BuildPredicateFunc<Genus>(), true).Result);

        var serviceResult = await _genusQueryService.FindByGenusNameAsync(GENUS_NAME);

        Assert.Null(serviceResult);
        _genusRespository.Verify(g => g.FindByNameAsync(UtilTools.BuildPredicateFunc<Genus>(), true), Times.Once());
    }
}
