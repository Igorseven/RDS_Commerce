namespace RDS_Commerce.Domain.Entities;
public sealed class PlantImage : FileImage
{
    public bool MainImage { get; set; }
    public int PlantId { get; set; }
}
