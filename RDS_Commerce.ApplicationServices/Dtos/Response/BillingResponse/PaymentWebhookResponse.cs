using RDS_Commerce.Domain.Enums;
using System.Text.Json.Serialization;

namespace RDS_Commerce.ApplicationServices.Dtos.Response.BillingResponse;
public sealed class PaymentWebhookResponse
{
    [JsonPropertyName("object")]
    public string Object { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("dateCreated")]
    public string DateCreated { get; set; }

    [JsonPropertyName("customer")]
    public string Customer { get; set; }

    [JsonPropertyName("subscription")]
    public string Subscription { get; set; }

    [JsonPropertyName("installment")]
    public string Installment { get; set; }

    [JsonPropertyName("paymentLink")]
    public string? PaymentLink { get; set; }

    [JsonPropertyName("dueDate")]
    public string DueDate { get; set; }

    [JsonPropertyName("originalDueDate")]
    public string OriginalDueDate { get; set; }

    [JsonPropertyName("value")]
    public decimal Value { get; set; }

    [JsonPropertyName("netValue")]
    public decimal? NetValue { get; set; }

    [JsonPropertyName("pixTransaction")]
    public object? PixTransaction { get; set; }

    [JsonPropertyName("originalValue")]
    public object? OriginalValue { get; set; }///===========> type ?

    [JsonPropertyName("interestValue")]
    public object? InterestValue { get; set; }///===========> type?

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("externalReference")]
    public string? ExternalReference { get; set; }

    [JsonPropertyName("billingType")]
    public EBillingType BillingType { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("confirmedDate")]
    public string ConfirmedDate { get; set; }

    [JsonPropertyName("paymentDate")]
    public string? PaymentDate { get; set; }

    [JsonPropertyName("clientPaymentDate")]
    public string ClientPaymentDate { get; set; }

    [JsonPropertyName("creditDate")]
    public string CreditDate { get; set; }

    [JsonPropertyName("estimatedCreditDate")]
    public string EstimatedCreditDate { get; set; }

    [JsonPropertyName("invoiceUrl")]
    public string? InvoiceUrl { get; set; }

    [JsonPropertyName("bankSlipUrl")]
    public object? BankSlipUrl { get; set; } ///===========> type?

    [JsonPropertyName("transactionReceiptUrl")]
    public string? TransactionReceiptUrl { get; set; }

    [JsonPropertyName("invoiceNumber")]
    public string? InvoiceNumber { get; set; }

    [JsonPropertyName("deleted")]
    public bool Deleted { get; set; }

    [JsonPropertyName("anticipated")]
    public bool Anticipated { get; set; }

    [JsonPropertyName("lastInvoiceViewedDate")]
    public string LastInvoiceViewedDate { get; set; }

    [JsonPropertyName("lastBankSlipViewedDate")]
    public object? LastBankSlipViewedDate { get; set; } // ========> type?

    [JsonPropertyName("postalService")]
    public bool PostalService { get; set; }

    [JsonPropertyName("creditCard")]
    public CreditCardResponse CreditCard { get; set; }

    [JsonPropertyName("discount")]
    public DiscountResponse Discount { get; set; }

    [JsonPropertyName("fine")]
    public FineResponse Fine { get; set; }

    [JsonPropertyName("interest")]
    public InterestResponse Interest { get; set; }

    [JsonPropertyName("split")]
    public List<SplitResponse> Split { get; set; }

    [JsonPropertyName("chargeback")]
    public ChargebackResponse Chargeback { get; set; }

    [JsonPropertyName("refunds")]
    public object? Refunds { get; set; } // >>>>>>>>>> type?
}
