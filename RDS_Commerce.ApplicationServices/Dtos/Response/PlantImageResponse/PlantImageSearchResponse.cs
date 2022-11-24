namespace RDS_Commerce.ApplicationServices.Dtos.Response.PlantImageResponse;
public sealed class PlantImageSearchResponse
{
    public int Id { get; set; }
    public bool MainImage { get; set; }
    public string FileName { get; set; }
    public string FileExtension { get; set; }
    public byte[] FileBytes { get; set; }
}
