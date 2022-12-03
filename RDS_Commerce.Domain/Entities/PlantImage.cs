namespace RDS_Commerce.Domain.Entities;
public sealed class PlantImage : FileImage
{
    public bool MainImage { get; set; } = false;
    public int PlantId { get; set; }
}
