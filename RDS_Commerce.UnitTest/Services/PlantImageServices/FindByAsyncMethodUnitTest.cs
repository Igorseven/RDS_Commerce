using Moq;
using RDS_Commerce.UnitTest.Builders;
using RDS_Commerce.UnitTest.Services.PlantImageServices.Base;

namespace RDS_Commerce.UnitTest.Services.PlantImageServices;
public sealed class FindByAsyncMethodUnitTest : PlantImageServiceBaseUnitTest
{
    [Fact]
	[Trait("Success", "Find image")]
	public async Task FindByAsync_ReturnImage()
	{
		const int  PLANT_IMAGE_ID = 100;
		var plantImage = PlantImageBuilder.NewObject().DomainBuild();

		_plantImageRepository.Setup(r => r.FindByAsync(PLANT_IMAGE_ID, true, true)).ReturnsAsync(plantImage);

		var serviceResult = await _service.FindByAsync(PLANT_IMAGE_ID);

		Assert.NotNull(serviceResult);
		_plantImageRepository.Verify(r => r.FindByAsync(PLANT_IMAGE_ID, true, true), Times.Once());

	}


    [Fact]
    [Trait("Failed", "Not found image")]
    public async Task FindByAsync_ReturnNull()
    {
        const int PLANT_IMAGE_ID = 100;
        var plantImage = PlantImageBuilder.NewObject().DomainBuild();

        _plantImageRepository.Setup(r => r.FindByAsync(PLANT_IMAGE_ID, true, true));

        var serviceResult = await _service.FindByAsync(PLANT_IMAGE_ID);

        Assert.Null(serviceResult);
        _plantImageRepository.Verify(r => r.FindByAsync(PLANT_IMAGE_ID, true, true), Times.Once());

    }
}
