using Moq;
using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.ApplicationServices.Services.OrderServices;
using RDS_Commerce.ApplicationServices.Services.PlantServices;
using RDS_Commerce.Business.Handler.ValidationSettings.EntitiesValidation;
using RDS_Commerce.Business.Interfaces.OthersContracts;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;

namespace RDS_Commerce.UnitTest.Services.PlantServices.Base;
public abstract class PlantServiceBaseUnitTest
{
    protected readonly Mock<INotificationHandler> _notification;
    protected readonly Mock<IPlantRepository> _plantRepository;
    protected readonly Mock<IPurchaseOrderQueryService> _purchaseOrderQueryService;
    protected readonly PlantValidation _validatePlant;
    protected readonly PlantCommandService _service;
    public PlantServiceBaseUnitTest()
    {
        _notification = new Mock<INotificationHandler>();
        _plantRepository = new Mock<IPlantRepository>();
        _purchaseOrderQueryService = new Mock<IPurchaseOrderQueryService>();
        _validatePlant = new PlantValidation();

        _service = new PlantCommandService(_plantRepository.Object,
                                    _notification.Object,
                                    _validatePlant,
                                    _purchaseOrderQueryService.Object);

        AutoMapperFactoryConfigurations.Initialize();
    }
}
