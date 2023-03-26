using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RDS_Commerce.ApplicationServices.Dtos.Arguments;
using RDS_Commerce.ApplicationServices.Dtos.Request.ManagerRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.ManagerResponse;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.Business.Handler.NotificationSettings;

namespace RDS_Commerce.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ManagerController : ControllerBase
{
    private readonly IManagerService _managerService;

    public ManagerController(IManagerService managerService)
    {
        _managerService = managerService;
    }

    [AllowAnonymous]
    [HttpPost("manager_register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<bool> CreateAccountAsync([FromBody] ManagerDtoForRegister managerDtoForRegister) =>
        await _managerService.CreateManagerAccountAsync(managerDtoForRegister);

    [AllowAnonymous]
    [HttpPost("manager_login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<ManagerDtoLoginResponse?> LoginAsync(UserLogin userLogin) => await _managerService.LoginAsync(userLogin);

}
