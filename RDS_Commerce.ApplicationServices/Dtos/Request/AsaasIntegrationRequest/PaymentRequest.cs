using System.Text.Json.Serialization;

namespace RDS_Commerce.ApplicationServices.Dtos.Request.AsaasIntegrationRequest;
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


    [JsonPropertyName("installmentCount")]
    public int? InstallmentCount { get; set; }

    [JsonPropertyName("installmentValue")]
    public decimal? InstallmentValue { get; set; }

    [JsonPropertyName("discount")]
    public DiscountRequest? DiscountRequest { get; set; }

    [JsonPropertyName("interest")]
    public InterestRequest? InterestRequest { get; set; }

    [JsonPropertyName("fine")]
    public FineRequest? FineRequest { get; set; }

    [JsonPropertyName("split")]
    public List<SplitRequest>? SplitRequests { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("externalReference")]
    public string? ExternalReference { get; set; }

    [JsonPropertyName("creditCard")]
    public CreditCardRequest CreditCard { get; set; }

    [JsonPropertyName("creditCardHolderInfo")]
    public CreditCardHolderInfoRequest CreditCardHolderInfo { get; set; }

    [JsonPropertyName("creditCardToken")]
    public string CreditCardToken { get; set; }

    [JsonPropertyName("postalService")]
    public bool PostalService { get; set; } = false;
}
