using RDS_Commerce.ApplicationServices.Dtos.Request.AsaasIntegrationRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.BillingResponse;

namespace RDS_Commerce.ApplicationServices.Interfaces;
public interface IAsaasIntegrationCommandService
{
    Task<bool> CreateCardPurchaseAsync(BillingPaymentRequest request);
    Task<PixKeyPaymentResponse?> CreatePaymentWithPixAsync(PixKeyPaymentRequest pixKeyPaymentRequest);
    Task<WebhookChargeResponse> ChargeResponseAsync(WebhookChargeResponse request);
}
