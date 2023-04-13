using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.UnitTest.Builders;
public sealed class PlantBuilder
{

    private int _id = 11;
    private DateTime _registrationDate = DateTime.Now;
    private string _name = "Rosa de Pedra";
    private string? _description = "Uma planta para teste";
    private int _amount = 3;
    private decimal _price = 100.50m;
    private EPlantType _productType = EPlantType.Special;
    private Genus _genus = GenusBuilder.NewObject().DomainBuild();
    private List<PlantImageBuilder> _images;


    public static PlantBuilder NewObject() => new();

    public Plant DomainBuild()
    {
        return new()
        {
            Id = _id,
            Name = _name,
            Quantity = _amount,
            Description = _description,
            Price = _price,
            PlantType = _productType,
            Genus = _genus,
            RegistrationDate = _registrationDate,
            Images = PlantImageBuilder.NewObject().DomainListBuild()
        };
    }

    public PlantBuilder WithId(int plantId)
    {
        _id = plantId;
        return this;
    }

    public PlantBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public PlantBuilder WithAmount(int amount)
    {
        _amount = amount;
        return this;
    }

    public PlantBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }

    public PlantBuilder WithPrice(decimal price)
    {
        _price = price;
        return this;
    }
    public PlantBuilder WithProducType(EPlantType productType)
    {
        _productType = productType;
        return this;
    }

    public PlantBuilder WithSpecie(int genusId, string genusName, string specie)
    {
        _genus = GenusBuilder.NewObject()
                             .WithGenusId(genusId)
                             .WithGenusName(genusName)
                             .WithSpecie(specie)
                             .DomainBuild();
        return this;
    }


}
