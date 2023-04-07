using Moq;
using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.ApplicationServices.Services.PlantImageServices;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;

namespace RDS_Commerce.UnitTest.Services.PlantImageQueryServiceUnitTest.Base;
public abstract class PlantImageQueryServiceSetup
{
    protected readonly Mock<IPlantImageRepository> _plantImageRepository;
	protected readonly PlantImageQueryService _plantImageQueryService;

    public PlantImageQueryServiceSetup()
	{
        _plantImageRepository = new Mock<IPlantImageRepository>();
        _plantImageQueryService = new PlantImageQueryService(_plantImageRepository.Object);

        AutoMapperFactoryConfigurations.Initialize();
    }
}
