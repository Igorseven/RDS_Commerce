using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RDS_Commerce.ApplicationServices.Dtos.Response.BillingResponse;
public sealed class PixKeyPaymentResponse
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("encodedImage")]
    public string EncodedImage { get; set; }

    [JsonPropertyName("payload")]
    public string Payload { get; set; }

    [JsonPropertyName("expirationDate")]
    public string ExpirationDate { get; set; }
}
