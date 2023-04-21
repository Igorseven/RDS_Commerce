using System.Text.Json.Serialization;

namespace RDS_Commerce.ApplicationServices.Dtos.Response.AsaasIntegrationResponse;
public sealed class ChargebackResponse
{
    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("reason")]
    public string Reason { get; set; }
}
