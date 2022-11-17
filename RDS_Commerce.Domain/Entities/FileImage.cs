namespace RDS_Commerce.Domain.Entities;
public sealed class FileImage : BaseEntity
{
    public string FileName { get; set; }
    public string FileExtension { get; set; }
    public byte[] FileBytes { get; set; }
}
