using Moq;
using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.ApplicationServices.Services;
using RDS_Commerce.Business.Handler.PaginationSettings;
using RDS_Commerce.Business.Handler.ValidationSettings.EntitiesValidation;
using RDS_Commerce.Business.Interfaces.OthersContracts;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.UnitTest.Builders.PlantBuilders;
using RDS_Commerce.UnitTest.Tools;

namespace RDS_Commerce.UnitTest.Services.PlantServices;
public sealed class PlantQueryCommandsServiceUnitTest
{
    private Mock<INotificationHandler> _notification;
    private Mock<IPlantRepository> _plantRepository;
    private PlantValidation _validatePlant;
    private PlantService _service;
    public PlantQueryCommandsServiceUnitTest()
    {
        _notification = new Mock<INotificationHandler>();
        _plantRepository = new Mock<IPlantRepository>();
        _validatePlant = new PlantValidation();

        _service = new PlantService(_plantRepository.Object,
                                    _notification.Object,
                                    _validatePlant);

        AutoMapperFactoryConfigurations.Initialize();
    }

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
            UtilTools.BuildPageList<Plant>(plantList)
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

        var serviceResult = await _service.FindAllWithPaginationAsync(pageParams);

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

        var serviceResult = await _service.FindAllWithPaginationAsync(pageParams);

        _plantRepository.Verify(pr => pr.FindByWithPaginationAsync(pageParams, UtilTools.BuildQueryableIncludeFunc<Plant>(), true), Times.Once());
        Assert.Null(serviceResult);
    }
}

