using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.UnitTest.Builders;
public class GenusBuilder
{
    private int _genusId = 101;
    private string _genusName = "EKIVERIA";
    private string _apecie = "Lua de prata";
    private readonly DateTime _registrationDate = DateTime.Now;
    private List<Plant> _plants = new();


    public static GenusBuilder NewObject()
    {
        return new GenusBuilder();
    }

    public Genus DomainBuild()
    {
        return new()
        {
            Id = _genusId,
            GenusName = _genusName,
            Specie = _apecie,
            RegistrationDate = _registrationDate,
            Plants = _plants
        };
    }

    public GenusBuilder WithGenusId(int genusId)
    {
        _genusId = genusId;
        return this;
    }

    public GenusBuilder WithGenusName(string genusName)
    {
        _genusName = genusName;
        return this;
    }

    public GenusBuilder WithSpecie(string specie)
    {
        _apecie = specie;
        return this;
    }


    public GenusBuilder WithPlants(bool hasPlants)
    {
        if (hasPlants)
        {
            _plants = new()
            {
                new Plant
                {
                    Id = 2,
                    Amount = 1,
                    Name = "Planta",
                    PlantType = EPlantType.Special,
                    Price = 50.70m,
                    VaseSize = 10,
                    Description = "Uma grande planta",
                    RegistrationDate = DateTime.Now
                }
            };
                
        }

        return this;
    }
}
