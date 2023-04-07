using Moq;
using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.ApplicationServices.Services.GenusServices;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;

namespace RDS_Commerce.UnitTest.Services.GenusQueryServiceUnitTest.Base;
public abstract class GenusQueryServiceSetup
{
    protected readonly Mock<IGenusRespository> _genusRespository;
    protected readonly GenusQueryService _genusQueryService;

    public GenusQueryServiceSetup()
    {
        _genusRespository = new Mock<IGenusRespository>();
        _genusQueryService = new GenusQueryService(_genusRespository.Object);

        AutoMapperFactoryConfigurations.Initialize();
    }
}
