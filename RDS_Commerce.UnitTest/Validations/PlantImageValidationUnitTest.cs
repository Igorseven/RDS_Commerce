using Bogus.Extensions;
using RDS_Commerce.Business.Handler.ValidationSettings.EntitiesValidation;
using RDS_Commerce.UnitTest.Builders;

namespace RDS_Commerce.UnitTest.Validations;
public sealed class PlantImageValidationUnitTest
{
    private PlantImageValidation _plantImageValidation;

	public PlantImageValidationUnitTest()
	{
		_plantImageValidation= new ();
	}

	[Fact]
	[Trait("Success", "Valid data")]
	public async Task PlantImageValidation_ReturnTrue()
	{
		var plantImage = PlantImageBuilder.NewObject().DomainBuild();

		var responseResult = await _plantImageValidation.ValidationAsync(plantImage);

		Assert.True(responseResult.Valid);
    }

    public static IEnumerable<object[]> GetInvalidFileName()
	{
		return new List<object[]>
		{
			new object[] {new Bogus.Faker().Commerce.ProductName().ClampLength(0, 1)},
			new object[] {new Bogus.Faker().Commerce.ProductName().ClampLength(41, 42)}
		};
	}

    [Theory]
    [Trait("Failed", "Invalid length FileName")]
	[MemberData(nameof(GetInvalidFileName))]
    public async Task PlantImageValidation_InvalidFileName_ReturnFalse(string fileName)
    {
        var plantImage = PlantImageBuilder.NewObject().WithFileName(fileName).DomainBuild();

        var responseResult = await _plantImageValidation.ValidationAsync(plantImage);

        Assert.False(responseResult.Valid);
    }

    public static IEnumerable<object[]> GetInvalidFileExtension()
    {
        return new List<object[]>
        {
            new object[] {new Bogus.Faker().Commerce.ProductName().ClampLength(0, 1)},
            new object[] {new Bogus.Faker().Commerce.ProductName().ClampLength(11, 12)}
        };
    }

    [Theory]
    [Trait("Failed", "Invalid length FileExtension")]
    [MemberData(nameof(GetInvalidFileExtension))]
    public async Task PlantImageValidation_InvalidExtension_ReturnFalse(string fileExtension)
    {
        var plantImage = PlantImageBuilder.NewObject().WithFileExtension(fileExtension).DomainBuild();

        var responseResult = await _plantImageValidation.ValidationAsync(plantImage);

        Assert.False(responseResult.Valid);
    }

    [Fact]
    [Trait("Failed", "Invalid values")]
    public async Task PlantImageValidation_IsEmpty_ReturnFalse()
    {
        var plantImage = PlantImageBuilder.NewObject()
                                          .WithFileExtension("")
                                          .WithFileName("")
                                          .DomainBuild();

        var responseResult = await _plantImageValidation.ValidationAsync(plantImage);

        Assert.False(responseResult.Valid);
    }
}
