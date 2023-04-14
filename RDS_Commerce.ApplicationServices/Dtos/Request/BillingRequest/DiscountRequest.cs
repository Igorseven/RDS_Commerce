using RDS_Commerce.Domain.Enums;
using System.Text.Json.Serialization;

namespace RDS_Commerce.ApplicationServices.Dtos.Request.BillingRequest;
public sealed class DiscountRequest
{
    [JsonPropertyName("value")]
    public double? Value { get; set; }

    [JsonPropertyName("dueDateLimitDays")]
    public int DueDateLimitDays { get; set; }

    [JsonPropertyName("type")]
    public ETypeOfDiscount TypeOfDiscount { get; set; } 


}
