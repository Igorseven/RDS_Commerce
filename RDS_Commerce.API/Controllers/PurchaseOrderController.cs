using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RDS_Commerce.ApplicationServices.Dtos.Request.OrderPlantRequest;
using RDS_Commerce.ApplicationServices.Dtos.Request.PurchaseOrderRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.PurchaseOrderResponse;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.Business.Handler.NotificationSettings;

namespace RDS_Commerce.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class PurchaseOrderController : ControllerBase
{
    private readonly IPurchaseOrderCommandService _purchaseOrderCommandService;
    private readonly IPurchaseOrderQueryService _purchaseOrderQueryService;

    public PurchaseOrderController(IPurchaseOrderCommandService purchaseOrderCommandService, 
                           IPurchaseOrderQueryService purchaseOrderQueryService)
    {
        _purchaseOrderCommandService = purchaseOrderCommandService;
        _purchaseOrderQueryService = purchaseOrderQueryService;
    }

    [HttpPost("add_plant_in_purchase_order")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<bool> AddNewPlantInOrderAsync(OrderPlantDtoForAddPlantInOrder orderPlantDtoForAddPlantInOrder) =>
        await _purchaseOrderCommandService.AddPlantToOrderAsync(orderPlantDtoForAddPlantInOrder);

    [AllowAnonymous]
    [HttpGet("find_by_order")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<PurchaseOrderDtoSearchResponse?> GetByPurchaseOrderAsync(int orderId) => 
        await _purchaseOrderQueryService.FindByOrderAsync(orderId);
}
