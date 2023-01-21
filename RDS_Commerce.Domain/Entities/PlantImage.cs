namespace RDS_Commerce.Domain.Entities;
public sealed class PlantImage
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public string FileExtension { get; set; }
    public byte[] FileBytes { get; set; }
    public bool MainImage { get; set; } = false;
    public DateTime RegistrationDate { get; set; }

    public int PlantId { get; set; }
}
