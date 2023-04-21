using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.ApplicationServices.Dtos.Arguments;
using RDS_Commerce.ApplicationServices.Dtos.Request.AsaasIntegrationRequest;
using RDS_Commerce.ApplicationServices.Dtos.Request.ClientRequest;
using RDS_Commerce.ApplicationServices.Dtos.Request.ShippingAddressRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.BillingResponse;
using RDS_Commerce.ApplicationServices.Dtos.Response.ClientResponse;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.Business.Extensions;
using RDS_Commerce.Business.Interfaces.OthersContracts;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Domain.Enums;
using System.Net.Http.Json;

namespace RDS_Commerce.ApplicationServices.Services.ClientServices;
public sealed class ClientCommandService : BaseService<Client>, IClientCommandService
{
    private readonly IClientRepository _clientRepository;
    private readonly IAuthenticationTokenService _authenticationTokenService;
    private readonly IAccountIdentityService _accountIdentityService;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;

    public ClientCommandService(INotificationHandler notification,
                                IValidate<Client> validate,
                                IClientRepository clientRepository,
                                IAuthenticationTokenService authenticationTokenService,
                                IAccountIdentityService accountIdentityService,
                                IHttpClientFactory httpClientFactory,
                                IConfiguration configuration)
        : base(notification, validate)
    {
        _clientRepository = clientRepository;
        _authenticationTokenService = authenticationTokenService;
        _accountIdentityService = accountIdentityService;
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }

    public async Task<ClientDtoForLoginResponse?> LoginAsync(UserLogin userLogin)
    {
        if (!await _accountIdentityService.SignPasswordAsync(userLogin)) return null;

        var client = await _clientRepository.FindByPredicateASync(c => c.AccountIdentity.NormalizedUserName == userLogin.Login!.ToUpper(),
                                                                  i => i.Include(c => c.AccountIdentity), true);

        if (client is not null)
        {
            return new ClientDtoForLoginResponse
            {
                Role = client.Role,
                Token = await _authenticationTokenService.GenerateTokenAsync(client)
            };
        }

        return null;
    }

    public async Task<bool> RegisterClientAsync(ClientDtoForRegister clientDtoForRegister)
    {
        if (clientDtoForRegister.Password != clientDtoForRegister.ConfirmPassword)
            return _notification.CreateNotification("Senha", "Confirmação de senha não confere com a senha.");

        var client = clientDtoForRegister.MapTo<ClientDtoForRegister, Client>();

        SetClientRegister(client, clientDtoForRegister);

        if (!await EntityValidationAsync(client)) return false;

        if (!await _accountIdentityService.CreateIdentityAccountAsync(client.AccountIdentity)) return false;

        return await _clientRepository.SaveAsync(client);
    }

    private static void SetClientRegister(Client client, ClientDtoForRegister clientDtoForRegister)
    {
        client.DocumentNumber = clientDtoForRegister.DocumentCpf.RemoveCaracters();
        client.AccountIdentity.PhoneNumber = clientDtoForRegister.CellPhone.RemoveCaracters();
        client.ShippingAddresses = new List<ShippingAddress>();
        client.Orders = new List<PurchaseOrder>();
        client.Role = ERole.Consumer;
    }


    public async Task<bool> UpdateClientDataToMakePurchesesAsync(ClientDtoForUpdateToPayment clientDtoForUpdateToPayment)
    {
        var client = await _clientRepository.FindByIdASync(clientDtoForUpdateToPayment.UserId, i => i.Include(sa => sa.ShippingAddresses)!, false);

        if (client is null)
            return _notification.CreateNotification("Cliente", EMessage.NotFound.GetDescription().FormatTo("Cliente"));

        var address = clientDtoForUpdateToPayment.shippingAddressDtoForRegister.MapTo<ShippingAddressDtoForRegister, ShippingAddress>();

        client.ShippingAddresses?.Add(address);

        if (!await EntityValidationAsync(client)) return false;

        var clientAsaasRegisterResponse = await CreateBillingClient(client);

        if (clientAsaasRegisterResponse is null) return false;

        client.CustomerId = clientAsaasRegisterResponse.Id;

        if (await _clientRepository.UpdateAsync(client)) 
            return true;

        return false;
    }

    private async Task<CustomerResponse?> CreateBillingClient(Client client)
    {
        var customer = client.MapTo<Client, CustomerRequest>();

        var httpClient = _httpClientFactory.CreateClient("AsaasHttpClient");
        httpClient.DefaultRequestHeaders.Add("access_token", _configuration["AsasConfig:ApiKey"]);

        var response = await httpClient.PostAsJsonAsync("customers", customer);

        if (response.StatusCode == System.Net.HttpStatusCode.OK) 
            return await response.Content.ReadFromJsonAsync<CustomerResponse>();
        else 
            return null;
    }

    public void Dispose() => _clientRepository.Dispose();
}
