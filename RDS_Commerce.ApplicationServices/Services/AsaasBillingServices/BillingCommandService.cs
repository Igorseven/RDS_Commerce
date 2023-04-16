using Microsoft.Extensions.Configuration;
using RDS_Commerce.ApplicationServices.Dtos.Request.BillingRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.BillingResponse;
using RDS_Commerce.ApplicationServices.Interfaces;
using System.Net.Http.Json;

namespace RDS_Commerce.ApplicationServices.Services.AsaasBillingServices;
public sealed class BillingCommandService : IBillingCommandService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IClientQueryService _clientQueryService;
    private readonly IConfiguration _configuration;

    public BillingCommandService(IHttpClientFactory httpClientFactory,
                                 IClientQueryService clientQueryService,
                                 IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _clientQueryService = clientQueryService;
        _configuration = configuration;
    }

    public Task<WebhookChargeResponse> ChargeResponseAsync(WebhookChargeResponse request)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CreateCreditPurchaseAsync(BillingPaymentRequest billingRequest)
    {
        var client = await _clientQueryService.FindByDomainObjectAsync(c => c.UserId == billingRequest.ClientId, null, true);

        billingRequest.PaymentRequest.Customer = client!.CustomerId!;
        billingRequest.PaymentRequest.DueDate = DateTime.Now.ToString("yyyy-MM-dd");

        var httpClient = _httpClientFactory.CreateClient("AsaasHttpClient");
        httpClient.DefaultRequestHeaders.Add("access_token", _configuration["AsasConfig:ApiKey"]);

        var response = await httpClient.PostAsJsonAsync("payments", billingRequest.PaymentRequest);

        var paymentResponse = await response.Content.ReadFromJsonAsync<PaymentResponse>();

        if (response.StatusCode == System.Net.HttpStatusCode.OK) return true;

        return false;
    }


    public async Task<PixKeyPaymentResponse?> CreatePaymentWithPixAsync(PixKeyPaymentRequest pixKeyPaymentRequest)
    {
        var httpClient = _httpClientFactory.CreateClient("AsaasHttpClient");
        httpClient.DefaultRequestHeaders.Add("access_token", _configuration["AsasConfig:ApiKey"]);

        var response = await httpClient.PostAsJsonAsync("pix/qrCodes/static", pixKeyPaymentRequest);

        var PixKeyResponse = await response.Content.ReadFromJsonAsync<PixKeyPaymentResponse>();

        if (response.Content is null) return null;

        return PixKeyResponse;
    }
}
