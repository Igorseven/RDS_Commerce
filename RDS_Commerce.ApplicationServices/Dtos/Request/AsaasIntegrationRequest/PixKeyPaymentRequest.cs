using System.Text.Json.Serialization;

namespace RDS_Commerce.ApplicationServices.Dtos.Request.AsaasIntegrationRequest;
public sealed class PixKeyPaymentRequest
{
    [JsonPropertyName("addressKey")]
    public string AddressKey { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }

    [JsonPropertyName("format")]
    public string Format { get; set; } = "ALL";

    [JsonPropertyName("expirationDate")]
    public DateTime ExpirationDate { get; set; }

    [JsonPropertyName("expirationSeconds")]
    public int ExpirationSeconds { get; set; }
}
