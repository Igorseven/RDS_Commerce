using Bogus.Extensions;
using RDS_Commerce.Business.Handler.ValidationSettings.EntitiesValidation;
using RDS_Commerce.UnitTest.Builders;

namespace RDS_Commerce.UnitTest.Validations;
public sealed class GenusValidationUnitTest
{
    private readonly GenusValidation _genusValidation;

	public GenusValidationUnitTest()
	{
		_genusValidation = new();
	}


	[Fact]
	[Trait("Success", "Create new Genus")]
	public async Task GenusValidation_ReturnTrue()
	{
		var genus = GenusBuilder.NewObject().DomainBuild();

		var validationResponse = await _genusValidation.ValidationAsync(genus);

		Assert.True(validationResponse.Valid);
	}

    public static IEnumerable<object[]> GetInvalidGanusName()
	{
		return new List<object[]>
		{
			new object[] {new Bogus.Faker().Commerce.ProductName().ClampLength(0, 1) },
			new object[] {new Bogus.Faker().Commerce.ProductName().ClampLength(81, 100) },
		};
	}


    [Theory]
    [Trait("Fail", "Invalid length")]
    [MemberData(nameof(GetInvalidGanusName))]
    public async Task GenusValidation_InvalidGenusName_ReturnFalse(string genusName)
    {
        var genus = GenusBuilder.NewObject().WithGenusName(genusName).DomainBuild();

        var validationResponse = await _genusValidation.ValidationAsync(genus);

        Assert.False(validationResponse.Valid);
    }


    public static IEnumerable<object[]> GetInvalidSpecie()
    {
        return new List<object[]>
        {
            new object[] {new Bogus.Faker().Commerce.ProductName().ClampLength(0, 1) },
            new object[] {new Bogus.Faker().Commerce.ProductName().ClampLength(81, 100) },
        };
    }


    [Theory]
    [Trait("Fail", "Invalid length")]
    [MemberData(nameof(GetInvalidSpecie))]
    public async Task GenusValidation_InvalidSpecie_ReturnFalse(string specie)
    {
        var genus = GenusBuilder.NewObject().WithSpecie(specie).DomainBuild();

        var validationResponse = await _genusValidation.ValidationAsync(genus);

        Assert.False(validationResponse.Valid);
    }
}
