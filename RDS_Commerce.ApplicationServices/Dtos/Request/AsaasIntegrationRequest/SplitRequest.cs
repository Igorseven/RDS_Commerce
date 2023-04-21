using System.Text.Json.Serialization;

namespace RDS_Commerce.ApplicationServices.Dtos.Request.AsaasIntegrationRequest;
public sealed class SplitRequest
{
    [JsonPropertyName("walletId")]
    public string WalletId { get; set; }

    [JsonPropertyName("fixedValue")]
    public double? FixedValue { get; set; }

    [JsonPropertyName("percentualValue")]
    public double? PercentualValue { get; set; }
}
