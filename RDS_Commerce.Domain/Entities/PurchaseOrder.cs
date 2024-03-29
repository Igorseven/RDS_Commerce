﻿using RDS_Commerce.Domain.Entities.Base;
using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.Domain.Entities;
public sealed class PurchaseOrder : BaseEntity
{
    public EOrderStatus OrderStatus { get; set; }
    public decimal Amount { get; set; }

    public Guid ClientId { get; set; }
    public Client Client { get; set; }
    public List<OrderPlant> OrderPlants { get; set; }
}
