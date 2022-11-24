namespace RDS_Commerce.ApplicationServices.Dtos.Request.PlantImageRequest;
public sealed class PlantImageUpdateRequest
{
    public int Id { get; set; }
    public bool MainImage { get; set; }
    public string FileName { get; set; }
    public string FileExtension { get; set; }
    public byte[] FileBytes { get; set; }
}
