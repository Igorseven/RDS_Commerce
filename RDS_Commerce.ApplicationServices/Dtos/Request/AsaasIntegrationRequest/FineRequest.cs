using System.Text.Json.Serialization;

namespace RDS_Commerce.ApplicationServices.Dtos.Request.AsaasIntegrationRequest;
public sealed class FineRequest
{
    [JsonPropertyName("value")]
    public double? Value { get; set; }
}
