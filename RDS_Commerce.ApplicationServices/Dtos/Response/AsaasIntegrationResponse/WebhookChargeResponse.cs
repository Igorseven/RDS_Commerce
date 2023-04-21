using RDS_Commerce.Domain.Enums;
using System.Text.Json.Serialization;

namespace RDS_Commerce.ApplicationServices.Dtos.Response.BillingResponse;
public sealed class WebhookChargeResponse
{
    [JsonPropertyName("event")]
    public EWebhookEvent Event { get; set; }

    [JsonPropertyName("payment")]
    public PaymentWebhookResponse Payment { get; set; }

    [JsonPropertyName("return")]
    public string? Return { get; set; }
}
