using System.Text.Json.Serialization;

namespace RDS_Commerce.ApplicationServices.Dtos.Response.BillingResponse;
public sealed class ChargebackResponse
{
    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("reason")]
    public string Reason { get; set; }
}
