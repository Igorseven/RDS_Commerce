using Microsoft.EntityFrameworkCore;
using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.ApplicationServices.Dtos.Arguments;
using RDS_Commerce.ApplicationServices.Dtos.Request.OrderPlantRequest;
using RDS_Commerce.ApplicationServices.Dtos.Request.PurchaseOrderRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.BillingResponse;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.Business.Extensions;
using RDS_Commerce.Business.Interfaces.OthersContracts;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.ApplicationServices.Services.OrderServices;
public sealed class PurchaseOrderCommandService : IPurchaseOrderCommandService
{
    private readonly IPurchaseOrderRepository _purchaseOrderRepository;
    private readonly INotificationHandler _notification;
    private readonly IPlantQueryService _plantQueryService;

    public PurchaseOrderCommandService(IPurchaseOrderRepository purchaseOrderRepository,
                                       INotificationHandler notification,
                                       IPlantQueryService plantQueryService)
    {
        _purchaseOrderRepository = purchaseOrderRepository;
        _notification = notification;
        _plantQueryService = plantQueryService;
    }

    public void Dispose() => _purchaseOrderRepository.Dispose();

    // notificar usuario usuário sobre disponibilidade de produtos.
    // criar gatilho de baixa de estoque ao finalizar um pedido.

    public async Task<bool> UpdateRequestWithWebhookResponse(WebhookChargeResponse webhookChargeResponse)
    {

        //Receber notificação do webHook e atualizar status do pedido.
      

        return false;
    }
        

    public Task<bool> OrderUpdateAsync(PurchaseOrderDtoForUpdate orderDtoForUpdate)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AddPlantToOrderAsync(OrderPlantDtoForAddPlantInOrder orderPlantDtoForAddPlantInOrder)
    {
        var order = await _purchaseOrderRepository.FindByPredicateAsync(o => o.ClientId == orderPlantDtoForAddPlantInOrder.ClientId &&
                                                                        o.OrderStatus == EOrderStatus.UnderConstruction,
                                                                        i => i.Include(o => o.OrderPlants), false);

        if (order is null)
            return await CreateNewOrderAsync(orderPlantDtoForAddPlantInOrder);
        else
            return await UpdateOrderAsync(order, orderPlantDtoForAddPlantInOrder);
    }

    private async Task<bool> CreateNewOrderAsync(OrderPlantDtoForAddPlantInOrder orderPlantDtoForAddPlantInOrder)
    {
        var plant = await _plantQueryService.FindByDomainObjectAsync(p => p.Id == orderPlantDtoForAddPlantInOrder.PlantId, null, false);

        if (plant is null)
            return _notification.CreateNotification("Planta", EMessage.NotFound.GetDescription().FormatTo("Planta"));

        var orderPlant = orderPlantDtoForAddPlantInOrder.MapTo<OrderPlantDtoForAddPlantInOrder, OrderPlant>();

        orderPlant.Plant = plant;

        var order = new PurchaseOrder
        {
            ClientId = orderPlantDtoForAddPlantInOrder.ClientId,
            OrderStatus = EOrderStatus.UnderConstruction,
            Amount = plant.Price * orderPlant.Quantity,
            OrderPlants = new List<OrderPlant> 
            { 
                orderPlant 
            }
        };

        return await _purchaseOrderRepository.SaveAsync(order);
    }

    private async Task<bool> UpdateOrderAsync(PurchaseOrder order, OrderPlantDtoForAddPlantInOrder orderPlantDtoForAddPlantInOrder)
    {
        var plant = await _plantQueryService.FindByDomainObjectAsync(p => p.Id == orderPlantDtoForAddPlantInOrder.PlantId, null, false);

        if (plant is null) 
            return _notification.CreateNotification("Planta", EMessage.NotFound.GetDescription().FormatTo("Planta"));

        var orderPlant = orderPlantDtoForAddPlantInOrder.MapTo<OrderPlantDtoForAddPlantInOrder, OrderPlant>();

        orderPlant.Plant = plant;
        orderPlant.OrderId = order.Id;

        order.Amount = order.Amount.AddAmountValue(orderPlant.Quantity, plant.Price);
        order.OrderPlants.Add(orderPlant);

        return await _purchaseOrderRepository.UpdateAsync(order);
    }
}
