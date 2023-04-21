using System.Text.Json.Serialization;

namespace RDS_Commerce.ApplicationServices.Dtos.Response.BillingResponse;
public sealed class DiscountResponse
{
    [JsonPropertyName("value")]
    public double Value { get; set; }

    [JsonPropertyName("dueDateLimitDays")]
    public int DueDateLimitDays { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}
