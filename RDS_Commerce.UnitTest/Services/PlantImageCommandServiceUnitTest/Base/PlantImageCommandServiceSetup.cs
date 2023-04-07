using Moq;
using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.ApplicationServices.Services.PlantImageServices;
using RDS_Commerce.Business.Handler.ValidationSettings.EntitiesValidation;
using RDS_Commerce.Business.Interfaces.OthersContracts;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;

namespace RDS_Commerce.UnitTest.Services.PlantImageCommandServiceUnitTest.Base;
public abstract class PlantImageCommandServiceSetup
{
    protected readonly Mock<IPlantImageRepository> _plantImageRepository;
    protected readonly Mock<INotificationHandler> _notificationHandler;
    protected readonly PlantImageValidation _validation;
    protected readonly PlantImageCommandService _service;

    public PlantImageCommandServiceSetup()
    {
        _plantImageRepository = new Mock<IPlantImageRepository>();
        _notificationHandler = new Mock<INotificationHandler>();
        _validation = new PlantImageValidation();
        _service = new PlantImageCommandService(_notificationHandler.Object,
                                         _validation,
                                         _plantImageRepository.Object
                                         );

        AutoMapperFactoryConfigurations.Initialize();

    }
}
