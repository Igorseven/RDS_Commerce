using System.Text.Json.Serialization;

namespace RDS_Commerce.ApplicationServices.Dtos.Request.BillingRequest;
public class CreditCardRequest
{
    [JsonPropertyName("holderName")]
    public string HolderName { get; set; }

    [JsonPropertyName("number")]
    public string Number { get; set; }

    [JsonPropertyName("expiryMonth")]
    public string ExpiryMonth { get; set; }

    [JsonPropertyName("expiryYear")]
    public string ExpiryYear { get; set; }

    [JsonPropertyName("ccv")]
    public string Ccv { get; set; }
}
