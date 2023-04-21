using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.ApplicationServices.Dtos.Request.PaymentHistoryRequest;
public sealed class PaymentHistoryDtoForRegister
{
    public EBillingType PaymentType { get; set; }
    public string PaymentDescription { get; set; }
    public int? InstallmentNumber { get; set; }
    public decimal PyamentValue { get; set; }
    public string Status { get; set; }
    public DateTime ConfirmedDate { get; set; }
    public DateTime PaymentDate { get; set; }
    public object? PixTransaction { get; set; }

    public string CustomerId { get; set; }
}
