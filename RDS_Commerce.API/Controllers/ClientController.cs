using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RDS_Commerce.ApplicationServices.Dtos.Arguments;
using RDS_Commerce.ApplicationServices.Dtos.Request.ClientRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.ClientResponse;
using RDS_Commerce.ApplicationServices.Dtos.Response.PlantResponse;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.Business.Handler.NotificationSettings;

namespace RDS_Commerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IClientCommandService _clientCommandService;
    private readonly IClientQueryService _clientQueryService;

    public ClientController(IClientCommandService clientService,
                            IClientQueryService clientQueryService)
    {
        _clientCommandService = clientService;
        _clientQueryService = clientQueryService;
    }


    [AllowAnonymous]
    [HttpPost("client_login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<ClientDtoForLoginResponse?> LoginAsync(UserLogin userLogin) => await _clientCommandService.LoginAsync(userLogin);

    [AllowAnonymous]
    [HttpPost("client_register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<bool> CreateClientAsync(ClientDtoForRegister clientDtoForRegister) => await _clientCommandService.RegisterClientAsync(clientDtoForRegister);


    [HttpPut("client_update_for_purchase")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<bool> UpdateDataToMakePurcheseAsync(ClientDtoForUpdateToPayment clientDtoForUpdateToPayment) => 
        await _clientCommandService.UpdateClientDataToMakePurchesesAsync(clientDtoForUpdateToPayment);

    

}
