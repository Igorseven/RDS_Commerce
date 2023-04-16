using RDS_Commerce.ApplicationServices.Dtos.Request.BillingRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.BillingResponse;

namespace RDS_Commerce.ApplicationServices.Interfaces;
public interface IBillingCommandService
{
    Task<bool> CreateCreditPurchaseAsync(BillingPaymentRequest request);
    Task<WebhookChargeResponse> ChargeResponseAsync(WebhookChargeResponse request);
    Task<PixKeyPaymentResponse?> CreatePaymentWithPixAsync(PixKeyPaymentRequest pixKeyPaymentRequest);
}
