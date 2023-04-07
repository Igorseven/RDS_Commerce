using System.Text.Json.Serialization;

namespace RDS_Commerce.ApplicationServices.Dtos.Request.BillingRequest;
public class CustomerRequest
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("phone")]
    public string Phone { get; set; }

    [JsonPropertyName("mobilePhone")]
    public string MobilePhone { get; set; }

    [JsonPropertyName("cpfCnpj")]
    public string CpfCnpj { get; set; }

    [JsonPropertyName("postalCode")]
    public string PostalCode { get; set; }

    [JsonPropertyName("address")]
    public string Address { get; set; }

    [JsonPropertyName("addressNumber")]
    public string AddressNumber { get; set; }

    [JsonPropertyName("complement")]
    public string Complement { get; set; }

    [JsonPropertyName("province")]
    public string Province { get; set; }

    [JsonPropertyName("externalReference")]
    public string ExternalReference { get; set; }

    [JsonPropertyName("notificationDisabled")]
    public bool NotificationDisabled { get; set; }

    [JsonPropertyName("additionalEmails")]
    public string AdditionalEmails { get; set; }

    [JsonPropertyName("municipalInscription")]
    public string MunicipalInscription { get; set; }

    [JsonPropertyName("stateInscription")]
    public string StateInscription { get; set; }

    [JsonPropertyName("observations")]
    public string Observations { get; set; }
}
