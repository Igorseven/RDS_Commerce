using Microsoft.EntityFrameworkCore;
using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.ApplicationServices.Dtos.Arguments;
using RDS_Commerce.ApplicationServices.Dtos.Request.ClientRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.ClientResponse;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.ApplicationServices.Services.Base;
using RDS_Commerce.Business.Interfaces.OthersContracts;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;

namespace RDS_Commerce.ApplicationServices.Services;
public sealed class ClientService : BaseService<Client>, IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly IAuthenticationTokenService _authenticationTokenService;
    private readonly IAccountIdentityService _accountIdentityService;

    public ClientService(INotificationHandler notification,
                         IValidate<Client> validate,
                         IClientRepository clientRepository,
                         IAuthenticationTokenService authenticationTokenService,
                         IAccountIdentityService accountIdentityService)
        : base(notification, validate)
    {
        _clientRepository = clientRepository;
        _authenticationTokenService = authenticationTokenService;
        _accountIdentityService = accountIdentityService;
    }


    public async Task<bool> RegisterClientAsync(ClientDtoForRegister clientDtoForRegister)
    {
        if (clientDtoForRegister.Password != clientDtoForRegister.ConfirmPassword)
            return _notification.CreateNotification("Senha", "Confirmação de senha não confere com a senha.");

        var client = clientDtoForRegister.MapTo<ClientDtoForRegister, Client>();

        if (!await EntityValidationAsync(client)) return false;

        if (!await _accountIdentityService.CreateIdentityAccountAsync(client.AccountIdentity)) return false;

        return await _clientRepository.SaveAsync(client);
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

    public void Dispose() => _clientRepository.Dispose();
}
