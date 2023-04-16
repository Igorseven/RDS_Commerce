using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.ApplicationServices.Dtos.Arguments;
public sealed class PixPayment
{
    public Guid UserId { get; set; }
    public int OrderId { get; set; }
    public EBillingType PaymentType { get; set; }
}
