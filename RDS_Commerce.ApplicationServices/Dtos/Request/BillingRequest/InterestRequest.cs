﻿using System.Text.Json.Serialization;

namespace RDS_Commerce.ApplicationServices.Dtos.Request.BillingRequest;
public sealed class InterestRequest
{
    [JsonPropertyName("value")]
    public double? Value { get; set; }
}
