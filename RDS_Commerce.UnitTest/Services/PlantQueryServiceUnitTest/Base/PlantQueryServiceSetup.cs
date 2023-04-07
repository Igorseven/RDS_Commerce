using Moq;
using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.ApplicationServices.Services.PlantServices;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;

namespace RDS_Commerce.UnitTest.Services.PlantQueryServiceUnitTest.Base;
public abstract class PlantQueryServiceSetup
{
    protected readonly Mock<IPlantRepository> _plantRepository;
    protected readonly PlantQueryService _plantQueryService;

    public PlantQueryServiceSetup()
	{
        _plantRepository = new Mock<IPlantRepository>();
        _plantQueryService = new PlantQueryService(_plantRepository.Object);


        AutoMapperFactoryConfigurations.Initialize();
    }
}
