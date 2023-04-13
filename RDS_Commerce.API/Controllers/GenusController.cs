using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RDS_Commerce.ApplicationServices.Dtos.Request.GenusRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.GenusResponse;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.Business.Handler.NotificationSettings;

namespace RDS_Commerce.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class GenusController : ControllerBase
{
    private readonly IGenusCommandService _genusCommandService;
    private readonly IGenusQueryService _genusQueryService;

    public GenusController(IGenusCommandService genusCommandService, IGenusQueryService genusQueryService)
    {
        _genusCommandService = genusCommandService;
        _genusQueryService = genusQueryService;
    }


    [HttpPost("genus_save")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<bool> GenusSaveAsyn([FromBody] GenusDtoForRegister saveRequest) =>
        await _genusCommandService.CreateNewGenusAsync(saveRequest);

    [AllowAnonymous]
    [HttpPut("genus_update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<bool> GenusUpdatAsync([FromBody] GenusDtoForUpdate updateRequest) =>
        await _genusCommandService.UpdateGenusAsync(updateRequest);


    [AllowAnonymous]
    [HttpGet("find_by_genus")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<GenusDtoResponse?> GetGenusByIdAsync([FromQuery] int genusId) => 
        await _genusQueryService.FindByIdAsync(genusId);

    [AllowAnonymous]
    [HttpGet("find_genus_byname")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<GenusDtoResponse?> GetGenusByNameAsync([FromQuery] string genusName) =>
        await _genusQueryService.FindByGenusNameAsync(genusName);
}
