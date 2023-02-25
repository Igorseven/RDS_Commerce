using Moq;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.UnitTest.Builders;
using RDS_Commerce.UnitTest.Services.GenusServices.Base;
using RDS_Commerce.UnitTest.Tools;

namespace RDS_Commerce.UnitTest.Services.GenusServices;
public class DeleteGeneusAsyncMethodUnitTest : GenusServiceBaseUnitTest
{

    [Fact]
    [Trait("Success", "Perfect Setting")]
    public async Task DeleteGeneusAsync_PerfectSetting_ReturnTrue()
    {
         const int GENUS_ID = 10;
        var genus = GenusBuilder.NewObject().WithGenusId(GENUS_ID).DomainBuild();

        _genusRespository.Setup(g => g.FindByIdAsync(GENUS_ID, UtilTools.BuildQueryableIncludeFunc<Genus>(), true).Result).Returns(genus);
        _genusRespository.Setup(g => g.DeleteAsync(It.IsAny<int>()).Result).Returns(true);

        var serviceResult = await _genusService.DeleteGeneusAsync(GENUS_ID);

        Assert.True(serviceResult);
        _genusRespository.Verify(g => g.FindByIdAsync(GENUS_ID, UtilTools.BuildQueryableIncludeFunc<Genus>(), true), Times.Once());
        _genusRespository.Verify(g => g.DeleteAsync(It.IsAny<int>()), Times.Once());
    }


    [Fact]
    [Trait("Failed", "Has plants")]
    public async Task DeleteGeneusAsync_HasPlants_ReturnFalse()
    {
        const int GENUS_ID = 10;
        var genus = GenusBuilder.NewObject().WithGenusId(GENUS_ID).WithPlants(true).DomainBuild();

        _genusRespository.Setup(g => g.FindByIdAsync(GENUS_ID, UtilTools.BuildQueryableIncludeFunc<Genus>(), true).Result).Returns(genus);

        var serviceResult = await _genusService.DeleteGeneusAsync(GENUS_ID);

        Assert.False(serviceResult);
        _genusRespository.Verify(g => g.FindByIdAsync(GENUS_ID, UtilTools.BuildQueryableIncludeFunc<Genus>(), true), Times.Once());
        _genusRespository.Verify(g => g.DeleteAsync(It.IsAny<int>()), Times.Never());
    }


    [Fact]
    [Trait("Failed", "Genus not found")]
    public async Task DeleteGeneusAsync_NotFound_ReturnFalse()
    {
        const int GENUS_ID = 10;

        _genusRespository.Setup(g => g.FindByIdAsync(GENUS_ID, UtilTools.BuildQueryableIncludeFunc<Genus>(), true).Result);

        var serviceResult = await _genusService.DeleteGeneusAsync(GENUS_ID);

        Assert.False(serviceResult);
        _genusRespository.Verify(g => g.FindByIdAsync(GENUS_ID, UtilTools.BuildQueryableIncludeFunc<Genus>(), true), Times.Once());
        _genusRespository.Verify(g => g.DeleteAsync(It.IsAny<int>()), Times.Never());
    }
}
