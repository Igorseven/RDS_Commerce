using RDS_Commerce.ApplicationServices.Dtos.Response.PlantResponse;

namespace RDS_Commerce.ApplicationServices.Dtos.Response.OrderPlantResponse;
public sealed class OrderPlantDtoSearchResponse
{
    public int PlantId { get; set; }
    public int OrderId { get; set; }
    public int Quantity { get; set; }

    public PlantDtoForCheckPlantAvailabilityResponse Plant { get; set; }
}
