using System.Text.Json.Serialization;

namespace RDS_Commerce.ApplicationServices.Dtos.Response.BillingResponse;
public sealed class SplitResponse
{
    [JsonPropertyName("walletId")]
    public string WalletId { get; set; }

    [JsonPropertyName("fixedValue")]
    public int FixedValue { get; set; }

    [JsonPropertyName("percentualValue")]
    public int? PercentualValue { get; set; }
}
