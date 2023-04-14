namespace RDS_Commerce.Domain.Entities;
public sealed class PaymentHandler
{
    public int PaymentHanlderId { get; set; }
    public string PaymentDescription { get; set; }
    public string PixKey { get; set; }
    public int? Discount { get; set; }
}
