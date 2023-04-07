using System.Text.Json.Serialization;

namespace RDS_Commerce.ApplicationServices.Dtos.Request.BillingRequest;
public class PaymentRequest
{
    [JsonPropertyName("customer")]
    public string Customer { get; set; }

    [JsonPropertyName("billingType")]
    public string BillingType { get; set; }

    [JsonPropertyName("dueDate")]
    public string DueDate { get; set; }

    [JsonPropertyName("value")]
    public decimal Value { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("externalReference")]
    public string ExternalReference { get; set; }

    [JsonPropertyName("creditCard")]
    public CreditCardRequest CreditCard { get; set; }

    [JsonPropertyName("creditCardHolderInfo")]
    public CreditCardHolderInfoRequest CreditCardHolderInfo { get; set; }

    [JsonPropertyName("creditCardToken")]
    public string CreditCardToken { get; set; }

    [JsonPropertyName("postalService")]
    public bool PostalService { get; set; } = false;
}
