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
    private readonly IPlantService _plantService;

    public PlantController(IPlantService plantService)
    {
        _plantService = plantService;
    }

    [RequestSizeLimit(5_000_000)]
    [HttpPost("plant_save")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<bool> PlantSaveAsync([FromForm] PlantSaveRequest saveRequest) =>
        await _plantService.SaveAsync(saveRequest);

    [HttpPut("plant_update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<bool> PlantUpdateAsync([FromBody] PlantUpdateRequest updateRequest) =>
        await _plantService.UpdateAsync(updateRequest);

    [RequestSizeLimit(5_000_000)]
    [HttpPut("plant_update_images")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<bool> PlantImagesUpdateAsync([FromForm] PlantUpdateImagesRequest updateRequest) =>
        await _plantService.InsertOtherImagesAsync(updateRequest);

    [HttpPut("plant_update_main_image")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<bool> PlantMainImageUpdateAsync([FromBody] PlantUpdateMainImageRequest updateRequest) =>
        await _plantService.UpdateMainImageAsync(updateRequest);

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
    public async Task<PlantSearchResponse?> FindByPlantAsync([FromQuery] int plantId) =>
       await _plantService.FindByAsync(plantId);

    [HttpGet("find_plants_homepage_with_pagination")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<PageList<PlantsSearchResponse?>> FindPlantsToPaginationAsync([FromQuery] PageParams pageParams) =>
       await _plantService.FindAllWithPaginationAsync(pageParams);
}
