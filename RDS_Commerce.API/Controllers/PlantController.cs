using Microsoft.AspNetCore.Mvc;
using RDS_Commerce.ApplicationServices.Dtos.Request.PlantRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.PlantResponse;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.Business.Handler.NotificationSettings;
using RDS_Commerce.Business.Handler.PaginationSettings;

namespace RDS_Commerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class PlantController : ControllerBase
{
    private readonly IPlantCommandService _plantService;
    private readonly IPlantQueryService _plantQueryService;

    public PlantController(IPlantCommandService plantService,
                           IPlantQueryService plantQueryService)
    {
        _plantService = plantService;
        _plantQueryService = plantQueryService;
    }

    [RequestSizeLimit(5_000_000)]
    [HttpPost("plant_save")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<bool> PlantSaveAsync([FromForm] PlantDtoForRegister saveRequest) =>
        await _plantService.SaveAsync(saveRequest);

    [HttpPut("plant_update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<bool> PlantUpdateAsync([FromBody] PlantDtoForUpdate updateRequest) =>
        await _plantService.UpdateAsync(updateRequest);

    [RequestSizeLimit(5_000_000)]
    [HttpPut("plant_update_images")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<bool> PlantImagesUpdateAsync([FromForm] PlantDtoForUpdateImages updateRequest) =>
        await _plantService.InsertOtherImagesAsync(updateRequest);

    [HttpDelete("plant_delete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<bool> PlantDeleteAsync([FromQuery] int plantId) =>
       await _plantService.DeleteAsync(plantId);

    [HttpGet("find_by_plant")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<PlantDtoResponse?> FindByPlantAsync([FromQuery] int plantId) =>
       await _plantQueryService.FindByAsync(plantId);

    [HttpGet("find_plants_with_pagination")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<PageList<PlantsDtoResponse>>? FindPlantsToPaginationAsync([FromQuery] PageParams pageParams) =>
       await _plantQueryService.FindAllWithPaginationAsync(pageParams)!;
}
