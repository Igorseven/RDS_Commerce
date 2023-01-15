using Moq;
using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.ApplicationServices.Services;
using RDS_Commerce.Business.Handler.ValidationSettings.EntitiesValidation;
using RDS_Commerce.Business.Interfaces.OthersContracts;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;

namespace RDS_Commerce.UnitTest.Services.PlantImageServices.Base;
public abstract class PlantImageServiceBaseUnitTest
{
    protected Mock<IPlantImageRepository> _plantImageRepository;
    protected Mock<INotificationHandler> _notificationHandler;
    protected PlantImageValidation _validation;
    protected PlantImageService _service;

    public PlantImageServiceBaseUnitTest()
    {
        _plantImageRepository = new Mock<IPlantImageRepository>();
        _notificationHandler = new Mock<INotificationHandler>();
        _validation = new PlantImageValidation();
        _service = new PlantImageService(_notificationHandler.Object,
                                         _validation,
                                         _plantImageRepository.Object
                                         );

        AutoMapperFactoryConfigurations.Initialize();

    }
}
