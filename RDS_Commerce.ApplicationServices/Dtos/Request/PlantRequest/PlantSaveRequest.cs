using Microsoft.AspNetCore.Http;
using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.ApplicationServices.Dtos.Request.PlantRequest;
public sealed class PlantSaveRequest
{
    public string Name { get; set; }
    public string Specie { get; set; }
    public string? Description { get; set; }
    public int Amount { get; set; }
    public decimal Price { get; set; }
    public EProductType ProductType { get; set; }

    public List<IFormFile> FileImages { get; set; }
}
