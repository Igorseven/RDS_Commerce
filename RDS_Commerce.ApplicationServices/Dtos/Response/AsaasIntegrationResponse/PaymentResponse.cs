using System.Text.Json.Serialization;

namespace RDS_Commerce.ApplicationServices.Dtos.Response.BillingResponse;
public sealed class PaymentResponse
{
    [JsonPropertyName("errors")]
    public List<ErrorResponse> Errors { get; set; }

    [JsonPropertyName("object")]
    public string Object { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("dateCreated")]
    public string DateCreated { get; set; }

    [JsonPropertyName("customer")]
    public string Customer { get; set; }

    [JsonPropertyName("paymentLink")]
    public object PaymentLink { get; set; }

    [JsonPropertyName("dueDate")]
    public string DueDate { get; set; }

    [JsonPropertyName("value")]
    public decimal Value { get; set; }

    [JsonPropertyName("netValue")]
    public decimal NetValue { get; set; }

    [JsonPropertyName("billingType")]
    public string BillingType { get; set; }

    [JsonPropertyName("pixTransaction")]
    public object PixTransaction { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("externalReference")]
    public string ExternalReference { get; set; }

    [JsonPropertyName("originalValue")]
    public object OriginalValue { get; set; }

    [JsonPropertyName("interestValue")]
    public object InterestValue { get; set; }

    [JsonPropertyName("originalDueDate")]
    public string OriginalDueDate { get; set; }

    [JsonPropertyName("paymentDate")]
    public string PaymentDate { get; set; }

    [JsonPropertyName("clientPaymentDate")]
    public string ClientPaymentDate { get; set; }

    [JsonPropertyName("creditDate")]
    public string CreditDate { get; set; }

    [JsonPropertyName("estimatedCreditDate")]
    public string EstimatedCreditDate { get; set; }

    [JsonPropertyName("transactionReceiptUrl")]
    public object TransactionReceiptUrl { get; set; }

    [JsonPropertyName("nossoNumero")]
    public string NossoNumero { get; set; }

    [JsonPropertyName("invoiceUrl")]
    public string InvoiceUrl { get; set; }

    [JsonPropertyName("bankSlipUrl")]
    public string BankSlipUrl { get; set; }

    [JsonPropertyName("invoiceNumber")]
    public string InvoiceNumber { get; set; }

    [JsonPropertyName("deleted")]
    public bool Deleted { get; set; }

    [JsonPropertyName("lastInvoiceViewedDate")]
    public object LastInvoiceViewedDate { get; set; }

    [JsonPropertyName("lastBankSlipViewedDate")]
    public object LastBankSlipViewedDate { get; set; }

    [JsonPropertyName("postalService")]
    public bool PostalService { get; set; }

    [JsonPropertyName("anticipated")]
    public bool Anticipated { get; set; }

    [JsonPropertyName("refunds")]
    public object Refunds { get; set; }

    [JsonPropertyName("creditCard")]
    public CreditCardResponse CreditCard { get; set; }
}
