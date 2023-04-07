namespace RDS_Commerce.Domain.Entities;
public sealed class ClientCardInfo
{
    public int ClientCardInfoId { get; set; }
    public DateTime InclusionDate { get; set; }
    public string CreditCardNumber { get; set; }
    public string CreditCardBrand { get; set; }
    public string CreditCardToken { get; set; }
    public bool IsActive { get; set; }

    public int ClientId { get; set; }
    public Client Client { get; set; }
}
