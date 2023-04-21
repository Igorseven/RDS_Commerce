using System.Text.Json.Serialization;

namespace RDS_Commerce.ApplicationServices.Dtos.Response.BillingResponse;
public sealed class CustomerResponse
{
    [JsonPropertyName("object")]
    public string Object { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("dateCreated")]
    public string DateCreated { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("phone")]
    public string Phone { get; set; }

    [JsonPropertyName("mobilePhone")]
    public string MobilePhone { get; set; }

    [JsonPropertyName("address")]
    public string Address { get; set; }

    [JsonPropertyName("addressNumber")]
    public string AddressNumber { get; set; }

    [JsonPropertyName("complement")]
    public string Complement { get; set; }

    [JsonPropertyName("province")]
    public string Province { get; set; }

    [JsonPropertyName("postalCode")]
    public string PostalCode { get; set; }

    [JsonPropertyName("cpfCnpj")]
    public string CpfCnpj { get; set; }

    [JsonPropertyName("personType")]
    public string PersonType { get; set; }

    [JsonPropertyName("deleted")]
    public bool Deleted { get; set; }

    [JsonPropertyName("additionalEmails")]
    public string AdditionalEmails { get; set; }

    [JsonPropertyName("externalReference")]
    public string ExternalReference { get; set; }

    [JsonPropertyName("notificationDisabled")]
    public bool NotificationDisabled { get; set; }

    [JsonPropertyName("city")]
    public int City { get; set; }

    [JsonPropertyName("state")]
    public string State { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("observations")]
    public string Observations { get; set; }
}
