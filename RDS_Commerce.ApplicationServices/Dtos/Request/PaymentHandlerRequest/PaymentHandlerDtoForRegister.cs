namespace RDS_Commerce.ApplicationServices.Dtos.Request.PaymentHandlerRequest;
public sealed class PaymentHandlerDtoForRegister
{
    public string PaymentDescription { get; set; }
    public string PixKey { get; set; }
    public int? Discount { get; set; }
}
