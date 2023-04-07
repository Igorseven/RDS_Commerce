using Moq;
using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.ApplicationServices.Services.GenusServices;
using RDS_Commerce.Business.Handler.ValidationSettings.EntitiesValidation;
using RDS_Commerce.Business.Interfaces.OthersContracts;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;

namespace RDS_Commerce.UnitTest.Services.GenusCommandServiceUnitTest.Base;
public abstract class GenusServiceBaseUnitTest
{
    protected readonly Mock<IGenusRespository> _genusRespository;
    protected readonly Mock<INotificationHandler> _notificationHandler;
    protected readonly GenusValidation _validation;
    protected readonly GenusCommandService _genusCommandService;

    public GenusServiceBaseUnitTest()
    {
        _genusRespository = new Mock<IGenusRespository>();
        _notificationHandler = new Mock<INotificationHandler>();
        _validation = new GenusValidation();

        _genusCommandService = new GenusCommandService(_notificationHandler.Object,
                                         _validation,
                                         _genusRespository.Object);

        AutoMapperFactoryConfigurations.Initialize();
    }
}
