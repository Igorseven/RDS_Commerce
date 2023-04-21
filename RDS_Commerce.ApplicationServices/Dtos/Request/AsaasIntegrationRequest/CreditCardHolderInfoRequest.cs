using System.Text.Json.Serialization;

namespace RDS_Commerce.ApplicationServices.Dtos.Request.AsaasIntegrationRequest;
public class CreditCardHolderInfoRequest
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("cpfCnpj")]
    public string CpfCnpj { get; set; }

    [JsonPropertyName("postalCode")]
    public string PostalCode { get; set; }

    [JsonPropertyName("addressNumber")]
    public string AddressNumber { get; set; }

    [JsonPropertyName("addressComplement")]
    public object AddressComplement { get; set; }

    [JsonPropertyName("phone")]
    public string Phone { get; set; }

    [JsonPropertyName("mobilePhone")]
    public string MobilePhone { get; set; }
}