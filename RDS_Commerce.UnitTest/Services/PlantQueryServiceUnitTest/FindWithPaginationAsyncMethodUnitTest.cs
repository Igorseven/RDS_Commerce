using Moq;
using RDS_Commerce.Business.Handler.PaginationSettings;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.UnitTest.Builders;
using RDS_Commerce.UnitTest.Services.PlantQueryServiceUnitTest.Base;
using RDS_Commerce.UnitTest.Services.PlantServices.Base;
using RDS_Commerce.UnitTest.Tools;

namespace RDS_Commerce.UnitTest.Services.PlantQueryServiceUnitTest;
public class FindWithPaginationAsyncMethodUnitTest : PlantQueryServiceSetup
{
    public static IEnumerable<object[]> GetAllPlantsWithPagination()
    {

        var plantList = new List<Plant>
        {
            PlantBuilder.NewObject().DomainBuild(),
            PlantBuilder.NewObject().WithId(101).WithName("Rosa").DomainBuild(),
            PlantBuilder.NewObject().WithId(105).WithName("Valis").DomainBuild(),
            PlantBuilder.NewObject().WithId(99).WithName("Ramosx").DomainBuild()
        };

        yield return new object[]
        {
            UtilTools.BuildPageList(plantList)
        };

    }

    [Theory]
    [Trait("Sucess", "Return plant list")]
    [MemberData(nameof(GetAllPlantsWithPagination))]
    public async Task FindAllWithPaginationAsync_ReturnPlants(PageList<Plant> plants)
    {
        const int PAGE_NUMBER = 1;
        const int PAGE_SIZE = 10;
        var pageParams = UtilTools.BuildPageParams(PAGE_NUMBER, PAGE_SIZE);

        _plantRepository.Setup(pr => pr.FindByWithPaginationAsync(pageParams, UtilTools.BuildQueryableIncludeFunc<Plant>(), true)).ReturnsAsync(plants);

        var serviceResult = await _plantQueryService.FindAllWithPaginationAsync(pageParams);

        _plantRepository.Verify(pr => pr.FindByWithPaginationAsync(pageParams, UtilTools.BuildQueryableIncludeFunc<Plant>(), true), Times.Once());
        Assert.NotNull(serviceResult);
        Assert.True(serviceResult.TotalCount == 4);
    }

    [Fact]
    [Trait("Sucess", "Return empty list")]
    public async Task FindAllWithPaginationAsync_EmptyList_ReturnNull()
    {
        const int PAGE_NUMBER = 1;
        const int PAGE_SIZE = 10;
        var pageParams = UtilTools.BuildPageParams(PAGE_NUMBER, PAGE_SIZE);
        _plantRepository.Setup(pr => pr.FindByWithPaginationAsync(pageParams, UtilTools.BuildQueryableIncludeFunc<Plant>(), true));

        var serviceResult = await _plantQueryService.FindAllWithPaginationAsync(pageParams);

        _plantRepository.Verify(pr => pr.FindByWithPaginationAsync(pageParams, UtilTools.BuildQueryableIncludeFunc<Plant>(), true), Times.Once());
        Assert.Null(serviceResult);
    }
}
