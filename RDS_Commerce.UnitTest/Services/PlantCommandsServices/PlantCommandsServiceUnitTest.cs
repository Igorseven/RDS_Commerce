using Moq;
using RDS_Commerce.ApplicationServices.Services;
using RDS_Commerce.Business.Interfaces.OthersContracts;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;

namespace RDS_Commerce.UnitTest.Services.PlantCommandsServices;
public sealed class PlantCommandsServiceUnitTest
{
    private Mock<INotificationHandler> _notification;
    private Mock<IPlantRepository> _plantRepository;
    private Mock<IValidate<Plant>> _validate;
    private PlantService _service;
    public PlantCommandsServiceUnitTest()
    {
        _notification = new Mock<INotificationHandler>();
        _plantRepository = new Mock<IPlantRepository>();
        _validate = new Mock<IValidate<Plant>>();

        _service = new PlantService(_plantRepository.Object,
                                    _notification.Object,
                                    _validate.Object);
    }


}
