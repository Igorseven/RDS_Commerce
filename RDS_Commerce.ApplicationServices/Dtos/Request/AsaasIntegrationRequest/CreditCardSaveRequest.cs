namespace RDS_Commerce.ApplicationServices.Dtos.Request.AsaasIntegrationRequest;
public sealed class CreditCardSaveRequest
{
    public string HolderName { get; set; }
    public string Number { get; set; }
    public string ExpiryMonth { get; set; }
    public string ExpiryYear { get; set; }
    public string Ccv { get; set; }
}
