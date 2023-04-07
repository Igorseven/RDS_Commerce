using System.Text.Json.Serialization;

namespace RDS_Commerce.ApplicationServices.Dtos.Response.BillingResponse;
public sealed class InterestResponse
{
    [JsonPropertyName("value")]
    public double Value { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}
