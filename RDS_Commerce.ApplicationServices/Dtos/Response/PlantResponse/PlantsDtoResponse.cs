﻿using RDS_Commerce.ApplicationServices.Dtos.Response.GenusResponse;
using RDS_Commerce.ApplicationServices.Dtos.Response.PlantImageResponse;
using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.ApplicationServices.Dtos.Response.PlantResponse;
public sealed class PlantsDtoResponse
{
    public int PlantId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public int VaseSize { get; set; }
    public EPlantType PlantType { get; set; }
    public GenusDtoResponse Genus { get; set; }
    public PlantImageDtoResponse MainImage { get; set; }
}
