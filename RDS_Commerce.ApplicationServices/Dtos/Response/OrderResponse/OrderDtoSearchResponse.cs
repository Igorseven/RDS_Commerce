using RDS_Commerce.ApplicationServices.Dtos.Response.OrderPlantResponse;

namespace RDS_Commerce.ApplicationServices.Dtos.Response.OrderResponse;
public sealed class OrderDtoSearchResponse
{
    public int OrderId { get; set; }
    public decimal Amount { get; set; }
    public List<OrderPlantDtoSearchResponse> OrderPlantDtoSearchResponses { get; set; }
}
