using Moq;
using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.ApplicationServices.Services;
using RDS_Commerce.Business.Handler.ValidationSettings.EntitiesValidation;
using RDS_Commerce.Business.Interfaces.OthersContracts;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;

namespace RDS_Commerce.UnitTest.Services.GenusServices.Base;
public abstract class GenusServiceBaseUnitTest
{
    protected Mock<IGenusRespository> _genusRespository;
    protected Mock<INotificationHandler> _notificationHandler;
    protected GenusValidation _validation;
    protected GenusService _genusService;

    public GenusServiceBaseUnitTest()
    {
        _genusRespository = new Mock<IGenusRespository>();
        _notificationHandler = new Mock<INotificationHandler>();
        _validation = new GenusValidation();

        _genusService = new GenusService(_notificationHandler.Object,
                                         _validation,
                                         _genusRespository.Object);

        AutoMapperFactoryConfigurations.Initialize();
    }
}
