namespace RDS_Commerce.ApplicationServices.Dtos.Request.PaymentHandlerRequest;
public sealed class PaymentHandlerDtoForUpdate
{
    public int PaymentHanlderId { get; set; }
    public string PaymentDescription { get; set; }
    public string PixKey { get; set; }
    public int? Discount { get; set; }
}
