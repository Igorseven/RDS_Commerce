using RDS_Commerce.Domain.Entities;

namespace RDS_Commerce.UnitTest.Builders.FileImageBuilders;
public sealed class PlantImageBuilder
{
    private int _id = new Bogus.Faker().Random.Int(1, 150);
    private DateTime _registrationDate = DateTime.Now;
    private bool _mainImage = false;
    private int _plantId = new Bogus.Faker().Random.Int(1, 250);
    private string _fileName = "planta_imagem";
    private string _fileExtension = ".pdf";
    private byte[] _fileBytes = new byte[0];


    public static PlantImageBuilder NewObject() => new();

    public PlantImage DomainBuild()
    {
        return new PlantImage()
        {
            Id = _id,
            RegistrationDate = _registrationDate,
            MainImage = _mainImage,
            FileBytes = _fileBytes,
            FileExtension = _fileExtension,
            FileName = _fileName,
            PlantId = _plantId,
        };
    }

    public List<PlantImage> DomainListBuild()
    {
        return new List<PlantImage>()
        {
            PlantImageBuilder.NewObject().WithMainImage(true).DomainBuild(),
            PlantImageBuilder.NewObject().DomainBuild()
        };
    }

    public PlantImageBuilder WithId(int plantImageId)
    {
        _id = plantImageId;
        return this;
    }

    public PlantImageBuilder WithMainImage(bool mainImage)
    {
        _mainImage = mainImage;
        return this;
    }
    public PlantImageBuilder WithFileName(string fileName)
    {
        _fileName = fileName;
        return this;
    }

    public PlantImageBuilder WithFileExtension(string fileExtension)
    {
        _fileExtension = fileExtension;
        return this;
    }

}
