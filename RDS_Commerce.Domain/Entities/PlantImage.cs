using RDS_Commerce.Domain.Entities.BaseEntities;

namespace RDS_Commerce.Domain.Entities;
public sealed class PlantImage : BaseEntity
{
    public string FileName { get; set; }
    public string FileExtension { get; set; }
    public byte[] FileBytes { get; set; }

    public int PlantId { get; set; }
}
