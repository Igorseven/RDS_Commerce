namespace RDS_Commerce.ApplicationServices.Dtos.Response.PaymentHandlerResponse;
public sealed class PaymentHandlerDtoForSearchResponse
{
    public int PaymentHanlderId { get; set; }
    public string PaymentDescription { get; set; }
    public string PixKey { get; set; }
    public int? Discount { get; set; }
}
