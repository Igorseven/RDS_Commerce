using System.Text.Json.Serialization;

namespace RDS_Commerce.ApplicationServices.Dtos.Response.BillingResponse;
public sealed class ErrorResponse
{
    [JsonPropertyName("code")]
    public string Code { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }
}
