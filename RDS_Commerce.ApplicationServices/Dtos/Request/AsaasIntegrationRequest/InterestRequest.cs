using System.Text.Json.Serialization;

namespace RDS_Commerce.ApplicationServices.Dtos.Request.AsaasIntegrationRequest;
public sealed class InterestRequest
{
    [JsonPropertyName("value")]
    public double? Value { get; set; }
}
