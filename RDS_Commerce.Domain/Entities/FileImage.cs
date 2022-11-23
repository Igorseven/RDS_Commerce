namespace RDS_Commerce.Domain.Entities;
public class FileImage
{
    public int Id { get; set; }
    public DateTime RegistrationDate { get; set; }
    public string FileName { get; set; }
    public string FileExtension { get; set; }
    public byte[] FileBytes { get; set; }
}
