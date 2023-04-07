using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RDS_Commerce.ApplicationServices.Dtos.Response.BillingResponse;
public sealed class CreditCardResponse
{
    [JsonPropertyName("creditCardNumber")]
    public string CreditCardNumber { get; set; }

    [JsonPropertyName("creditCardBrand")]
    public string CreditCardBrand { get; set; }

    [JsonPropertyName("creditCardToken")]
    public string CreditCardToken { get; set; }
}
