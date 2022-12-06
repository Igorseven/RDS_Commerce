using Bogus.Extensions;
using RDS_Commerce.Business.Handler.ValidationSettings.EntitiesValidation;
using RDS_Commerce.UnitTest.Builders.PlantBuilders;

namespace RDS_Commerce.UnitTest.Validations;
public sealed class PlantValidationUnitTest
{
    private readonly PlantValidation _plantValidate;

    public PlantValidationUnitTest()
    {
        _plantValidate = new();
    }

    [Fact]
    [Trait("Success", "Valid data")]
    public async Task PlantValidantion_ReturnTrue()
    {
        var plant = PlantBuilder.NewObject().DomainBuild();

        var responseResult = await _plantValidate.ValidationAsync(plant);

        Assert.True(responseResult.Valid);
    }

    [Fact]
    [Trait("Success", "Valid data")]
    public async Task PlantValidantion_ValidWithDescriptionEmpty_ReturnTrue()
    {
        var plant = PlantBuilder.NewObject().WithDescription("").DomainBuild();

        var responseResult = await _plantValidate.ValidationAsync(plant);

        Assert.True(responseResult.Valid);
    }

    public static IEnumerable<object[]> GetInvalidName()
    {
        return new List<object[]>
        {
            new object[] {new Bogus.Faker().Commerce.ProductName().ClampLength(0, 1) },
            new object[] {new Bogus.Faker().Commerce.ProductName().ClampLength(61, 62) },

        };
    }


    [Theory]
    [Trait("Failed", "Invalid length name")]
    [MemberData(nameof(GetInvalidName))]
    public async Task PlantValidantion_InvalidName_ReturnFalse(string name)
    {
        var plant = PlantBuilder.NewObject().WithName(name).DomainBuild();

        var responseResult = await _plantValidate.ValidationAsync(plant);

        Assert.False(responseResult.Valid);
    }


    public static IEnumerable<object[]> GetInvalidDescription()
    {
        return new List<object[]>
        {
            new object[] {new Bogus.Faker().Commerce.ProductDescription().ClampLength(0, 2) },
            new object[] {new Bogus.Faker().Commerce.ProductDescription().ClampLength(501, 502) },
        };
    }


    [Theory]
    [Trait("Failed", "Invalid length description")]
    [MemberData(nameof(GetInvalidDescription))]
    public async Task PlantValidantion_InvalidDescription_ReturnFalse(string description)
    {
        var plant = PlantBuilder.NewObject().WithDescription(description).DomainBuild();

        var responseResult = await _plantValidate.ValidationAsync(plant);

        Assert.False(responseResult.Valid);
    }


    public static IEnumerable<object[]> GetInvalidSpecie()
    {
        return new List<object[]>
        {
            new object[] {new Bogus.Faker().Commerce.ProductDescription().ClampLength(0, 1) },
            new object[] {new Bogus.Faker().Commerce.ProductDescription().ClampLength(61, 62) },
        };
    }


    [Theory]
    [Trait("Failed", "Invalid length specie")]
    [MemberData(nameof(GetInvalidSpecie))]
    public async Task PlantValidantion_InvalidSpecie_ReturnFalse(string specie)
    {
        var plant = PlantBuilder.NewObject().WithSpecie(specie).DomainBuild();

        var responseResult = await _plantValidate.ValidationAsync(plant);

        Assert.False(responseResult.Valid);
    }


    [Fact]
    [Trait("Failed", "Invalid value price")]
    public async Task PlantValidantion_InvalidPrice_ReturnFalse()
    {
        var invalidPrice = -1.0m;

        var plant = PlantBuilder.NewObject().WithPrice(invalidPrice).DomainBuild();

        var responseResult = await _plantValidate.ValidationAsync(plant);

        Assert.False(responseResult.Valid);
    }

    [Fact]
    [Trait("Failed", "Invalid value amount")]
    public async Task PlantValidantion_InvalidAmount_ReturnFalse()
    {
        var invalidAmount = -1;

        var plant = PlantBuilder.NewObject().WithAmount(invalidAmount).DomainBuild();

        var responseResult = await _plantValidate.ValidationAsync(plant);

        Assert.False(responseResult.Valid);
    }
}
