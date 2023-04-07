using Moq;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.UnitTest.Builders;
using RDS_Commerce.UnitTest.Services.GenusQueryServiceUnitTest.Base;
using RDS_Commerce.UnitTest.Tools;

namespace RDS_Commerce.UnitTest.Services.GenusQueryServiceUnitTest;
public class FindByIdAsyncMethodUnitTest : GenusQueryServiceSetup
{
    [Fact]
    [Trait("Success", "Return object")]
    public async Task FindByIdAsync_PerfectSetting_returnGenusObject()
    {
        const int GENUS_ID = 502;
        var genus = GenusBuilder.NewObject().WithGenusId(GENUS_ID).DomainBuild();

        _genusRespository.Setup(g => g.FindByIdAsync(GENUS_ID, UtilTools.BuildQueryableIncludeFunc<Genus>(), true).Result).Returns(genus);

        var serviceResult = await _genusQueryService.FindByIdAsync(GENUS_ID);

        Assert.NotNull(serviceResult);
        _genusRespository.Verify(g => g.FindByIdAsync(GENUS_ID, UtilTools.BuildQueryableIncludeFunc<Genus>(), true), Times.Once());
    }


    [Fact]
    [Trait("Success", "Not found")]
    public async Task FindByIdAsync_NotFound_returnNull()
    {
        const int GENUS_ID = 310;
        var genus = GenusBuilder.NewObject().WithGenusId(GENUS_ID).DomainBuild();

        _genusRespository.Setup(g => g.FindByIdAsync(GENUS_ID, UtilTools.BuildQueryableIncludeFunc<Genus>(), true));

        var serviceResult = await _genusQueryService.FindByIdAsync(GENUS_ID);

        Assert.Null(serviceResult);
        _genusRespository.Verify(g => g.FindByIdAsync(GENUS_ID, UtilTools.BuildQueryableIncludeFunc<Genus>(), true), Times.Once());
    }
}
