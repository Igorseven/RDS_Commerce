﻿using Microsoft.EntityFrameworkCore;
using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.ApplicationServices.Dtos.Arguments;
using RDS_Commerce.ApplicationServices.Dtos.Request.OrderPlantRequest;
using RDS_Commerce.ApplicationServices.Dtos.Request.PurchaseOrderRequest;
using RDS_Commerce.ApplicationServices.Handlers.Factories.Payment;
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
    private readonly IPaymentFactory _paymentFactory;
    private readonly IPlantQueryService _plantQueryService;

    public PurchaseOrderCommandService(IPurchaseOrderRepository purchaseOrderRepository,
                                       INotificationHandler notification,
                                       IPaymentFactory paymentFactory,
                                       IPlantQueryService plantQueryService)
    {
        _purchaseOrderRepository = purchaseOrderRepository;
        _notification = notification;
        _paymentFactory = paymentFactory;
        _plantQueryService = plantQueryService;
    }

    public void Dispose() => _purchaseOrderRepository.Dispose();

    // notificar usuario usuário sobre disponibilidade de produtos.
    // criar gatilho de baixa de estoque ao finalizar um pedido.

    public async Task<bool> FinalizeOrderAsync(OrderForExecutePayment orderForExecutePayment)
    {

        // criar obsever para verificar se o pedido já foi pago...
        if (await _paymentFactory.CreateNewPaymentAsync(orderForExecutePayment))
        {
            var order = await _purchaseOrderRepository.FindByPredicateAsync(o => o.Id == orderForExecutePayment.OrderId, null, false);

            order!.OrderStatus = Domain.Enums.EOrderStatus.PaidOut;

            return await _purchaseOrderRepository.UpdateAsync(order);
        }

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
