using RDS_Commerce.ApplicationServices.Dtos.Request.BillingRequest;
using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.ApplicationServices.Dtos.Arguments;
public sealed class OrderForExecutePayment
{
    public Guid UserId { get; set; }
    public int OrderId { get; set; }
    public int? NumberOfInstallment { get; set; }
    public EBillingType PaymentType { get; set; }
    public CreditCardSaveRequest CreditCardSaveRequest { get; set; }
}
