using Moq;
using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.ApplicationServices.Services;
using RDS_Commerce.Business.Handler.ValidationSettings.EntitiesValidation;
using RDS_Commerce.Business.Interfaces.OthersContracts;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;

namespace RDS_Commerce.UnitTest.Services.PlantServices.Base;
public abstract class PlantServiceBaseUnitTest
{
    protected Mock<INotificationHandler> _notification;
    protected Mock<IPlantRepository> _plantRepository;
    protected PlantValidation _validatePlant;
    protected PlantService _service;
    public PlantServiceBaseUnitTest()
    {
        _notification = new Mock<INotificationHandler>();
        _plantRepository = new Mock<IPlantRepository>();
        _validatePlant = new PlantValidation();

        _service = new PlantService(_plantRepository.Object,
                                    _notification.Object,
                                    _validatePlant);

        AutoMapperFactoryConfigurations.Initialize();
    }
}
