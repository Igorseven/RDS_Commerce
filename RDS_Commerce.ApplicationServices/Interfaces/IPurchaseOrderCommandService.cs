using RDS_Commerce.ApplicationServices.Dtos.Request.OrderPlantRequest;
using RDS_Commerce.ApplicationServices.Dtos.Request.PurchaseOrderRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.BillingResponse;

namespace RDS_Commerce.ApplicationServices.Interfaces;
public interface IPurchaseOrderCommandService : IDisposable
{
    Task<bool> OrderUpdateAsync(PurchaseOrderDtoForUpdate orderDtoForUpdate);
    Task<bool> AddPlantToOrderAsync(OrderPlantDtoForAddPlantInOrder orderPlantDtoForAddPlantInOrder);
    Task<bool> UpdateRequestWithWebhookResponse(WebhookChargeResponse webhookChargeResponse);
}
